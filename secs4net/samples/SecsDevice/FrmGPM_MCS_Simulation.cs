using Secs4Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecsDevice
{
    public partial class FrmGPM_MCS_Simulation : Form
    {
        public SecsGem? _secsGem;
        public FrmGPM_MCS_Simulation(SecsGem? _secsGem)
        {
            this._secsGem = _secsGem;
            InitializeComponent();
        }

        private void FrmGPM_MCS_Simulation_Load(object sender, EventArgs e)
        {

        }

        private async void btnTransferMsgSend_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(_CreateS2F49TransgerMesg("M123123123", "source", "destine"));
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(new SecsMessage(2, 49)
            {
                SecsItem =
               Item.L(
                       Item.U4(),
                       Item.A("OBJSPEC"),
                       Item.A("NOTRANSFER"),
                       Item.L()
                   )
            });
        }
        internal void MCSPrimaryMessageHandle(PrimaryMessageWrapper primaryMessage)
        {
            if (primaryMessage.PrimaryMessage.S == 6 && primaryMessage.PrimaryMessage.F == 11)
            {
                primaryMessage.TryReplyAsync(new SecsMessage(6, 12)
                {
                    SecsItem = Item.B(0)
                });
            }
        }

        private async void btnS1F3_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(new SecsMessage(1, 3)
            {
                SecsItem =
                            Item.L(
                                    Item.U2(2001),
                                    Item.U2(2002),
                                    Item.U2(2003),
                                    Item.U2(2004),
                                    Item.U2(2005),
                                    Item.U2(2006),
                                    Item.U2(2007),
                                    Item.U2(2008),
                                    Item.U2(2009)
                                )
            });
        }

        private async void btnS2F41PortTypeChange_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(new SecsMessage(2, 41)
            {
                SecsItem =
                Item.L(
                        Item.A("PORTTYPECHG"),
                        Item.L(
                            Item.L(
                                   Item.A("PORTID"),
                                   Item.A("3F_AGVC02_PORT_2_1")
                            ),
                            Item.L(
                                   Item.A("PORTUNITTYPE"),
                                   Item.U2(1)
                            )
                       )
                  )
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(_CreateS2F49TransgerMesg("MHIGH000000", "SYL0271UL01", "LTHRACK002_SYS0016_12"));
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            SecsMessage rep = await _secsGem.SendAsync(_CreateS2F49TransgerMesg("MLOW3333333", "LTHRACK002_SYS0016_20", "LTHRACK002_SYS0016_12"));
        }

        private SecsMessage _CreateS2F49TransgerMesg(string commandID, string source, string destine)
        {
            return new SecsMessage(2, 49)
            {
                SecsItem =
                 Item.L(
                         Item.U4(),
                         Item.A("OBJSPEC"),
                         Item.A("TRANSFER"),
                         Item.L(
                                 Item.L(
                                         Item.A("COMMANDINFO"),
                                         Item.L(
                                                 Item.L(
                                                         Item.A("COMMANDID"),
                                                         Item.A(commandID)
                                                       ),
                                                 Item.L(
                                                         Item.A("PRIORITY"),
                                                         Item.U2(52)
                                                       )
                                               )
                                       ),
                                 Item.L(
                                         Item.A("TRANSFERINFO"),
                                         Item.L(
                                                 Item.L(
                                                         Item.A("CARRIERID"),
                                                         Item.A("M000617281")
                                                       ),
                                                 Item.L(
                                                         Item.A("SOURCE"),
                                                         Item.A(source)
                                                       ),
                                                 Item.L(
                                                         Item.A("DEST"),
                                                         Item.A(destine)
                                                       ),
                                                 Item.L(
                                                         Item.A("NEXTDEST"),
                                                         Item.A("")
                                                       )
                                               )
                                       ),
                                 Item.L(
                                         Item.A("TRANSFERINFO_CST"),
                                         Item.L(
                                                 Item.L(
                                                         Item.A("LOT_ID"),
                                                         Item.A("246SE007-04-00")
                                                       ),
                                                 Item.L(
                                                         Item.A("CDAPURGE_FLAG"),
                                                         Item.A("")
                                                       ),
                                                 Item.L(
                                                         Item.A("BINDINGTYPE"),
                                                         Item.U2(0)
                                                       ),
                                                 Item.L(
                                                         Item.A("BINDINGKEY"),
                                                         Item.A("202408141115029735904433")
                                                       ),
                                                 Item.L(
                                                         Item.A("LIFE_FIX_FLAG"),
                                                         Item.A("NO")
                                                       )
                                               )
                                       )
                               )
                     )
            };
        }
    }
}
