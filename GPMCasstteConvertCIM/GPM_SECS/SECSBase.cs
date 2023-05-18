using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.Utilities;
using Microsoft.Extensions.Options;
using Secs4Net;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal class SECSBase
    {

        public Action<ConnectionState> ConnectionChanged { get; internal set; }
        public string name { get; }

        internal SecsGem? secsGem;
        internal HsmsConnection? connector;
        internal BindingList<PrimaryMessageWrapper> recvBuffer = new();
        internal BindingList<PrimaryMessageWrapper> sendBuffer = new();

        internal event EventHandler<PrimaryMessageWrapper> OnPrimaryMessageRecieve;
        internal event EventHandler MsgRecvBufferOnAdded;
        internal event EventHandler MsgSendBufferOnAdded;

        private ISecsGemLogger _logger;
        private CancellationTokenSource _cancellationTokenSource = new();

        private DataGridView? SendBufferDgvTable;
        private DataGridView? RevBufferDgvTable;

        internal SECSBase(string name)
        {
            this.name = name;
        }

        internal async void Active(SecsGemOptions secsGemOptions, RichTextBox? logRichTextBox = null, DataGridView SendBufferDgvTable = null, DataGridView RevBufferDgvTable = null)
        {
            this.SendBufferDgvTable = SendBufferDgvTable;
            this.RevBufferDgvTable = RevBufferDgvTable;

            if (this.SendBufferDgvTable != null)
            {
                this.SendBufferDgvTable.DataSource = this.sendBuffer;
            }
            if (this.RevBufferDgvTable != null)
            {
                this.RevBufferDgvTable.DataSource = this.recvBuffer;
            }


            _logger = new SECSLogger(logRichTextBox, Path.Combine(Utility.SysConfigs.Log.SyslogFolder, "SECS"));
            secsGem?.Dispose();

            if (connector is not null)
            {
                await connector.DisposeAsync();
            }

            var options = Options.Create(secsGemOptions);

            connector = new HsmsConnection(options, _logger);
            secsGem = new SecsGem(options, connector, _logger);
            connector.ConnectionChanged += delegate
            {
                ConnectionChanged(connector.State);
                var cs = connector.State.ToString();
                _logger.Info($"Connection State Change>{cs}");
            };

            _ = connector.StartAsync(_cancellationTokenSource.Token);

            try
            {
                await foreach (PrimaryMessageWrapper primaryMessage in secsGem.GetPrimaryMessageAsync(_cancellationTokenSource.Token))
                {
                    OnPrimaryMessageRecieve?.Invoke(this, primaryMessage);

                    if (primaryMessage.PrimaryMessage.ReplyExpected)
                    {
                        _ = Task.Factory.StartNew(async () =>
                        {
                            while (primaryMessage.SecondaryMessage == null)
                            {
                                await Task.Delay(1);
                            }

                            AddPrimaryMsgToRevBuffer(primaryMessage);

                        });

                    }
                    else
                    {
                        AddPrimaryMsgToRevBuffer(primaryMessage);

                    }

                }
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 主動發送訊息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<SecsMessage> SendAsync(SecsMessage message, CancellationToken cancellationToken = default)
        {
            return await Task.Run(async () =>
            {
                SecsMessage? secondaryMessage = null;
                try
                {
                    secondaryMessage = await secsGem?.SendAsync(message, cancellationToken);
                    try
                    {
                        AddPrimaryMsgToSendBuffer(message, secondaryMessage);
                    }
                    catch (Exception ex)
                    {

                    }
                    if (secondaryMessage.S == 6 && secondaryMessage.F == 12)
                    {
                        secondaryMessage.TryGetEventReportAckResult(out SECSMessageHelper.ACKC6 ack);
                        if (ack != SECSMessageHelper.ACKC6.Accpeted)
                        {
                            AlarmManager.AddWarning(ALARM_CODES.EVENT_REPORT_COMPLETED_BUT_ACK_IS_SYSTEM_ERROR_65, "SECS BASE");
                        }
                    }
                    return secondaryMessage;
                }
                catch (Exception ex)
                {
                    return secondaryMessage;
                }
            });
        }


        private void AddPrimaryMsgToRevBuffer(PrimaryMessageWrapper primaryMessage)
        {
            RevBufferDgvTable?.Invoke(new Action(() =>
            {
                if (recvBuffer.Count > 10)
                {
                    recvBuffer.Clear();
                }

                recvBuffer.Add(new PrimaryMessageWrapper()
                {
                    PrimaryMessage = primaryMessage.PrimaryMessage,
                    SecondaryMessage = primaryMessage.SecondaryMessage,
                });
                RevBufferDgvTable?.Invalidate();
            }));
        }

        private void AddPrimaryMsgToSendBuffer(SecsMessage primaryMsg, SecsMessage secondaryMessage)
        {
            SendBufferDgvTable?.Invoke(new Action(() =>
            {
                if (sendBuffer.Count > 10)
                {
                    sendBuffer.Clear();
                }
                sendBuffer.Add(new PrimaryMessageWrapper()
                {
                    PrimaryMessage = primaryMsg,
                    SecondaryMessage = secondaryMessage,
                });
                SendBufferDgvTable?.Invalidate();
            }));

        }
    }
}
