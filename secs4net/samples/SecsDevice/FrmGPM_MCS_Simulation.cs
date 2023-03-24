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
            SecsMessage rep = await _secsGem.SendAsync(new SecsMessage(2, 49)
            {
                SecsItem =
                Item.L(
                        Item.U4(),
                        Item.A("OBJSPEC"),
                        Item.A("TRANSFER"),
                        Item.L()
                    )
            });
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
    }
}
