﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.Utilities;
using Microsoft.Extensions.Options;
using Secs4Net;
using Secs4Net.Sml;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal class SECSBase
    {
        public static event EventHandler<API.WebsocketSupport.ViewModel.SecsLogViewModel> OnPrimaryMsgSendOut;
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
        private LoggerBase Syslogger => Utility.SystemLogger;

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


            _logger = new SECSLogger(logRichTextBox, Utility.SysConfigs.Log.SyslogFolder, "SECS");
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
        internal async Task<SecsMessage> SendMsg(SecsMessage message, CancellationToken cancellationToken = default, string msg_name = null)
        {
            Task<SecsMessage> ret = await Task.Factory.StartNew(async () =>
            {
                try
                {
                    if (msg_name != null)
                        message.Name = msg_name;
                    MsgSendOutInvokeHandle(message, true);
                    SecsMessage? secondaryMessage = null;
                    secondaryMessage = await secsGem?.SendAsync(message, cancellationToken);
                    try
                    {
                        AddPrimaryMsgToSendBuffer(message, secondaryMessage);
                    }
                    catch (Exception ex)
                    {
                        Syslogger.Error("SECSBase SendAsync Error", ex);
                    }

                    MsgSendOutInvokeHandle(secondaryMessage, false);
                    return secondaryMessage;
                }
                catch (Exception ex)
                {
                    Syslogger.Error($"SECSBase SendAsync Error({ex.Message})", ex);
                    return SECSMessageHelper.S9F7_IllegalDataMsg();
                }
            });
            return await ret;
        }

        internal void MsgSendOutInvokeHandle(SecsMessage message, bool IsSend)
        {
            _ = Task.Factory.StartNew(() =>
            {
                try
                {
                    OnPrimaryMsgSendOut?.Invoke(this, new API.WebsocketSupport.ViewModel.SecsLogViewModel
                    {
                        Direction = $" {(IsSend ? $"CIM-->{name}" : $" {name}-->CIM ")}",
                        Time = DateTime.Now,
                        SxFx = $"S{message.S}F{message.F} {(message.ReplyExpected ? "W" : "")}",
                        Sml = message.ToSml()
                    });
                }
                catch (Exception ex)
                {
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
            if (SendBufferDgvTable.Created)
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
            else
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
            }

        }
    }
}
