using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Secs4Net;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal class SECSBase
    {
        public Action<ConnectionState> ConnectionChanged { get; internal set; }

        internal SecsGem? secsGem;
        internal HsmsConnection? connector;
        internal readonly BindingList<MessageWrapper> recvBuffer = new();
        internal readonly BindingList<MessageWrapper> sendBuffer = new();
        internal event EventHandler<PrimaryMessageWrapper> OnPrimaryMessageRecieve;
        private ISecsGemLogger _logger;
        private CancellationTokenSource _cancellationTokenSource = new();


        internal async void Active(SecsGemOptions secsGemOptions, RichTextBox? logRichTextBox = null)
        {
            _logger = new SECSLogger(logRichTextBox);
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
                //base.Invoke((MethodInvoker)delegate
                //{
                //    lbStatus.Text = _connector.State.ToString();
                //});
            };

            _ = connector.StartAsync(_cancellationTokenSource.Token);

            try
            {
                await foreach (PrimaryMessageWrapper primaryMessage in secsGem.GetPrimaryMessageAsync(_cancellationTokenSource.Token))
                {
                    OnPrimaryMessageRecieve?.Invoke(this, primaryMessage);
                    recvBuffer.Add(new MessageWrapper(primaryMessage.PrimaryMessage, primaryMessage.SecondaryMessage));

                }
            }
            catch (OperationCanceledException)
            {

            }

            //SecsMessage ms = new SecsMessage(1, 3)
            //{
            //    SecsItem = Item.L(
            //                    Item.A(),
            //                    Item.U2(),
            //                    Item.U2()
            //         )
            //};


            //SecsMessage ReplyMsg = await secsGem.SendAsync(ms);
            //ReplyMsg.SecsItem.Items[0].Items[1].FirstValue<byte>();
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
                SecsMessage secondaryMessage;
                secondaryMessage = await secsGem?.SendAsync(message, cancellationToken);
                sendBuffer.Add(new MessageWrapper(message, secondaryMessage));
                return secondaryMessage;
            });
        }
    }
}
