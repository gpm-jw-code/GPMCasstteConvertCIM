namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscConverterPortStatus
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labLoadRequestBit = new Label();
            labUnloadRequestBit = new Label();
            labPortExistBit = new Label();
            labPortStatusDown = new Label();
            label10 = new Label();
            labUpPosition = new Label();
            labDownPosition = new Label();
            labWaitIn = new Label();
            labWaitOut = new Label();
            label11 = new Label();
            label2 = new Label();
            labL_REQBit = new Label();
            labU_REQBit = new Label();
            labEQReadyBit = new Label();
            labBusyBit = new Label();
            labCIMHandshakingWithAGV = new Label();
            label7 = new Label();
            lab_AGV_Valid = new Label();
            lab_AGV_TR = new Label();
            lab_AGV_Busy = new Label();
            lab_AGV_Ready = new Label();
            lab_AGV_Compt = new Label();
            panel1 = new Panel();
            labCurrentPortMode = new Label();
            label5 = new Label();
            txbWIP_BCR_ID = new TextBox();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labUnloading = new Label();
            labLoading = new Label();
            labAutoStatus = new Label();
            labPortEventRepShow = new Label();
            panel2 = new Panel();
            txbPortID = new TextBox();
            label4 = new Label();
            labServiceStatusText = new Label();
            label3 = new Label();
            labPortTypeChgReq = new Label();
            txbOnPortID = new TextBox();
            label6 = new Label();
            labAGVReadyToTransfer = new Label();
            labLDULDStatus = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(labLoadRequestBit);
            flowLayoutPanel1.Controls.Add(labUnloadRequestBit);
            flowLayoutPanel1.Controls.Add(labPortExistBit);
            flowLayoutPanel1.Controls.Add(labPortStatusDown);
            flowLayoutPanel1.Controls.Add(label10);
            flowLayoutPanel1.Controls.Add(labUpPosition);
            flowLayoutPanel1.Controls.Add(labDownPosition);
            flowLayoutPanel1.Controls.Add(labWaitIn);
            flowLayoutPanel1.Controls.Add(labWaitOut);
            flowLayoutPanel1.Controls.Add(label11);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(labL_REQBit);
            flowLayoutPanel1.Controls.Add(labU_REQBit);
            flowLayoutPanel1.Controls.Add(labEQReadyBit);
            flowLayoutPanel1.Controls.Add(labBusyBit);
            flowLayoutPanel1.Controls.Add(labCIMHandshakingWithAGV);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(lab_AGV_Valid);
            flowLayoutPanel1.Controls.Add(lab_AGV_TR);
            flowLayoutPanel1.Controls.Add(lab_AGV_Busy);
            flowLayoutPanel1.Controls.Add(lab_AGV_Ready);
            flowLayoutPanel1.Controls.Add(lab_AGV_Compt);
            flowLayoutPanel1.Location = new Point(6, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(3);
            flowLayoutPanel1.Size = new Size(465, 148);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // labLoadRequestBit
            // 
            labLoadRequestBit.BackColor = SystemColors.AppWorkspace;
            labLoadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labLoadRequestBit.FlatStyle = FlatStyle.Flat;
            labLoadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoadRequestBit.ForeColor = Color.White;
            labLoadRequestBit.Location = new Point(4, 4);
            labLoadRequestBit.Margin = new Padding(1);
            labLoadRequestBit.Name = "labLoadRequestBit";
            labLoadRequestBit.Size = new Size(88, 20);
            labLoadRequestBit.TabIndex = 0;
            labLoadRequestBit.Text = "Load Request";
            labLoadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUnloadRequestBit
            // 
            labUnloadRequestBit.BackColor = SystemColors.AppWorkspace;
            labUnloadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labUnloadRequestBit.FlatStyle = FlatStyle.Flat;
            labUnloadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUnloadRequestBit.ForeColor = Color.White;
            labUnloadRequestBit.Location = new Point(94, 4);
            labUnloadRequestBit.Margin = new Padding(1);
            labUnloadRequestBit.Name = "labUnloadRequestBit";
            labUnloadRequestBit.Size = new Size(88, 20);
            labUnloadRequestBit.TabIndex = 1;
            labUnloadRequestBit.Text = "Unload Request";
            labUnloadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPortExistBit
            // 
            labPortExistBit.BackColor = SystemColors.AppWorkspace;
            labPortExistBit.BorderStyle = BorderStyle.FixedSingle;
            labPortExistBit.FlatStyle = FlatStyle.Flat;
            labPortExistBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortExistBit.ForeColor = Color.White;
            labPortExistBit.Location = new Point(184, 4);
            labPortExistBit.Margin = new Padding(1);
            labPortExistBit.Name = "labPortExistBit";
            labPortExistBit.Size = new Size(88, 20);
            labPortExistBit.TabIndex = 2;
            labPortExistBit.Text = "Port Exist";
            labPortExistBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPortStatusDown
            // 
            labPortStatusDown.BackColor = SystemColors.AppWorkspace;
            labPortStatusDown.BorderStyle = BorderStyle.FixedSingle;
            labPortStatusDown.FlatStyle = FlatStyle.Flat;
            labPortStatusDown.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortStatusDown.ForeColor = Color.White;
            labPortStatusDown.Location = new Point(274, 4);
            labPortStatusDown.Margin = new Padding(1);
            labPortStatusDown.Name = "labPortStatusDown";
            labPortStatusDown.Size = new Size(88, 20);
            labPortStatusDown.TabIndex = 23;
            labPortStatusDown.Text = "PORT_STATUS_DOWN";
            labPortStatusDown.TextAlign = ContentAlignment.MiddleCenter;
            labPortStatusDown.DoubleClick += labPortStatusDown_DoubleClick;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.FlatStyle = FlatStyle.Flat;
            label10.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(364, 4);
            label10.Margin = new Padding(1);
            label10.Name = "label10";
            label10.Size = new Size(88, 20);
            label10.TabIndex = 30;
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUpPosition
            // 
            labUpPosition.BackColor = SystemColors.AppWorkspace;
            labUpPosition.BorderStyle = BorderStyle.FixedSingle;
            labUpPosition.FlatStyle = FlatStyle.Flat;
            labUpPosition.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUpPosition.ForeColor = Color.White;
            labUpPosition.Location = new Point(4, 26);
            labUpPosition.Margin = new Padding(1);
            labUpPosition.Name = "labUpPosition";
            labUpPosition.Size = new Size(88, 20);
            labUpPosition.TabIndex = 21;
            labUpPosition.Text = "LD_UP_POS";
            labUpPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDownPosition
            // 
            labDownPosition.BackColor = SystemColors.AppWorkspace;
            labDownPosition.BorderStyle = BorderStyle.FixedSingle;
            labDownPosition.FlatStyle = FlatStyle.Flat;
            labDownPosition.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labDownPosition.ForeColor = Color.White;
            labDownPosition.Location = new Point(94, 26);
            labDownPosition.Margin = new Padding(1);
            labDownPosition.Name = "labDownPosition";
            labDownPosition.Size = new Size(88, 20);
            labDownPosition.TabIndex = 22;
            labDownPosition.Text = "LD_DOWN_POS";
            labDownPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labWaitIn
            // 
            labWaitIn.BackColor = SystemColors.AppWorkspace;
            labWaitIn.BorderStyle = BorderStyle.FixedSingle;
            labWaitIn.FlatStyle = FlatStyle.Flat;
            labWaitIn.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labWaitIn.ForeColor = Color.White;
            labWaitIn.Location = new Point(184, 26);
            labWaitIn.Margin = new Padding(1);
            labWaitIn.Name = "labWaitIn";
            labWaitIn.Size = new Size(88, 20);
            labWaitIn.TabIndex = 24;
            labWaitIn.Text = "Wait In";
            labWaitIn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labWaitOut
            // 
            labWaitOut.BackColor = SystemColors.AppWorkspace;
            labWaitOut.BorderStyle = BorderStyle.FixedSingle;
            labWaitOut.FlatStyle = FlatStyle.Flat;
            labWaitOut.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labWaitOut.ForeColor = Color.White;
            labWaitOut.Location = new Point(274, 26);
            labWaitOut.Margin = new Padding(1);
            labWaitOut.Name = "labWaitOut";
            labWaitOut.Size = new Size(88, 20);
            labWaitOut.TabIndex = 25;
            labWaitOut.Text = "Wait Out";
            labWaitOut.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.FlatStyle = FlatStyle.Flat;
            label11.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(364, 26);
            label11.Margin = new Padding(1);
            label11.Name = "label11";
            label11.Size = new Size(88, 20);
            label11.TabIndex = 31;
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(4, 48);
            label2.Margin = new Padding(1);
            label2.Name = "label2";
            label2.Size = new Size(448, 20);
            label2.TabIndex = 34;
            label2.Text = "Handshake-EQ";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // labL_REQBit
            // 
            labL_REQBit.BackColor = SystemColors.AppWorkspace;
            labL_REQBit.BorderStyle = BorderStyle.FixedSingle;
            labL_REQBit.FlatStyle = FlatStyle.Flat;
            labL_REQBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labL_REQBit.ForeColor = Color.White;
            labL_REQBit.Location = new Point(4, 70);
            labL_REQBit.Margin = new Padding(1);
            labL_REQBit.Name = "labL_REQBit";
            labL_REQBit.Size = new Size(88, 20);
            labL_REQBit.TabIndex = 6;
            labL_REQBit.Text = "L_REQ";
            labL_REQBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labU_REQBit
            // 
            labU_REQBit.BackColor = SystemColors.AppWorkspace;
            labU_REQBit.BorderStyle = BorderStyle.FixedSingle;
            labU_REQBit.FlatStyle = FlatStyle.Flat;
            labU_REQBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labU_REQBit.ForeColor = Color.White;
            labU_REQBit.Location = new Point(94, 70);
            labU_REQBit.Margin = new Padding(1);
            labU_REQBit.Name = "labU_REQBit";
            labU_REQBit.Size = new Size(88, 20);
            labU_REQBit.TabIndex = 7;
            labU_REQBit.Text = "U_REQ";
            labU_REQBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labEQReadyBit
            // 
            labEQReadyBit.BackColor = SystemColors.AppWorkspace;
            labEQReadyBit.BorderStyle = BorderStyle.FixedSingle;
            labEQReadyBit.FlatStyle = FlatStyle.Flat;
            labEQReadyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labEQReadyBit.ForeColor = Color.White;
            labEQReadyBit.Location = new Point(184, 70);
            labEQReadyBit.Margin = new Padding(1);
            labEQReadyBit.Name = "labEQReadyBit";
            labEQReadyBit.Size = new Size(88, 20);
            labEQReadyBit.TabIndex = 8;
            labEQReadyBit.Text = "READY";
            labEQReadyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labBusyBit
            // 
            labBusyBit.BackColor = SystemColors.AppWorkspace;
            labBusyBit.BorderStyle = BorderStyle.FixedSingle;
            labBusyBit.FlatStyle = FlatStyle.Flat;
            labBusyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labBusyBit.ForeColor = Color.White;
            labBusyBit.Location = new Point(274, 70);
            labBusyBit.Margin = new Padding(1);
            labBusyBit.Name = "labBusyBit";
            labBusyBit.Size = new Size(88, 20);
            labBusyBit.TabIndex = 11;
            labBusyBit.Text = "BUSY";
            labBusyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labCIMHandshakingWithAGV
            // 
            labCIMHandshakingWithAGV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labCIMHandshakingWithAGV.BackColor = Color.MidnightBlue;
            labCIMHandshakingWithAGV.FlatStyle = FlatStyle.Flat;
            labCIMHandshakingWithAGV.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labCIMHandshakingWithAGV.ForeColor = Color.White;
            labCIMHandshakingWithAGV.Location = new Point(364, 70);
            labCIMHandshakingWithAGV.Margin = new Padding(1);
            labCIMHandshakingWithAGV.Name = "labCIMHandshakingWithAGV";
            labCIMHandshakingWithAGV.Size = new Size(88, 20);
            labCIMHandshakingWithAGV.TabIndex = 46;
            labCIMHandshakingWithAGV.Text = "CIM HS";
            labCIMHandshakingWithAGV.TextAlign = ContentAlignment.MiddleCenter;
            labCIMHandshakingWithAGV.Visible = false;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(4, 92);
            label7.Margin = new Padding(1);
            label7.Name = "label7";
            label7.Size = new Size(448, 22);
            label7.TabIndex = 47;
            label7.Text = "Handshake-AGV";
            label7.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lab_AGV_Valid
            // 
            lab_AGV_Valid.BackColor = SystemColors.AppWorkspace;
            lab_AGV_Valid.BorderStyle = BorderStyle.FixedSingle;
            lab_AGV_Valid.FlatStyle = FlatStyle.Flat;
            lab_AGV_Valid.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lab_AGV_Valid.ForeColor = Color.White;
            lab_AGV_Valid.Location = new Point(4, 116);
            lab_AGV_Valid.Margin = new Padding(1);
            lab_AGV_Valid.Name = "lab_AGV_Valid";
            lab_AGV_Valid.Size = new Size(88, 20);
            lab_AGV_Valid.TabIndex = 29;
            lab_AGV_Valid.Text = "AGV_VALID";
            lab_AGV_Valid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_AGV_TR
            // 
            lab_AGV_TR.BackColor = SystemColors.AppWorkspace;
            lab_AGV_TR.BorderStyle = BorderStyle.FixedSingle;
            lab_AGV_TR.FlatStyle = FlatStyle.Flat;
            lab_AGV_TR.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lab_AGV_TR.ForeColor = Color.White;
            lab_AGV_TR.Location = new Point(94, 116);
            lab_AGV_TR.Margin = new Padding(1);
            lab_AGV_TR.Name = "lab_AGV_TR";
            lab_AGV_TR.Size = new Size(88, 20);
            lab_AGV_TR.TabIndex = 26;
            lab_AGV_TR.Text = "AGV_TR_REQ";
            lab_AGV_TR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_AGV_Busy
            // 
            lab_AGV_Busy.BackColor = SystemColors.AppWorkspace;
            lab_AGV_Busy.BorderStyle = BorderStyle.FixedSingle;
            lab_AGV_Busy.FlatStyle = FlatStyle.Flat;
            lab_AGV_Busy.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lab_AGV_Busy.ForeColor = Color.White;
            lab_AGV_Busy.Location = new Point(184, 116);
            lab_AGV_Busy.Margin = new Padding(1);
            lab_AGV_Busy.Name = "lab_AGV_Busy";
            lab_AGV_Busy.Size = new Size(88, 20);
            lab_AGV_Busy.TabIndex = 27;
            lab_AGV_Busy.Text = "AGV_BUSY";
            lab_AGV_Busy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_AGV_Ready
            // 
            lab_AGV_Ready.BackColor = SystemColors.AppWorkspace;
            lab_AGV_Ready.BorderStyle = BorderStyle.FixedSingle;
            lab_AGV_Ready.FlatStyle = FlatStyle.Flat;
            lab_AGV_Ready.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lab_AGV_Ready.ForeColor = Color.White;
            lab_AGV_Ready.Location = new Point(274, 116);
            lab_AGV_Ready.Margin = new Padding(1);
            lab_AGV_Ready.Name = "lab_AGV_Ready";
            lab_AGV_Ready.Size = new Size(88, 20);
            lab_AGV_Ready.TabIndex = 28;
            lab_AGV_Ready.Text = "AGV_READY";
            lab_AGV_Ready.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_AGV_Compt
            // 
            lab_AGV_Compt.BackColor = SystemColors.AppWorkspace;
            lab_AGV_Compt.BorderStyle = BorderStyle.FixedSingle;
            lab_AGV_Compt.FlatStyle = FlatStyle.Flat;
            lab_AGV_Compt.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lab_AGV_Compt.ForeColor = Color.White;
            lab_AGV_Compt.Location = new Point(364, 116);
            lab_AGV_Compt.Margin = new Padding(1);
            lab_AGV_Compt.Name = "lab_AGV_Compt";
            lab_AGV_Compt.Size = new Size(88, 20);
            lab_AGV_Compt.TabIndex = 33;
            lab_AGV_Compt.Text = "AGV_COMPT";
            lab_AGV_Compt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labCurrentPortMode);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(8, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 46);
            panel1.TabIndex = 33;
            // 
            // labCurrentPortMode
            // 
            labCurrentPortMode.BackColor = Color.Black;
            labCurrentPortMode.BorderStyle = BorderStyle.FixedSingle;
            labCurrentPortMode.Dock = DockStyle.Fill;
            labCurrentPortMode.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labCurrentPortMode.ForeColor = Color.White;
            labCurrentPortMode.Location = new Point(0, 18);
            labCurrentPortMode.Margin = new Padding(0);
            labCurrentPortMode.Name = "labCurrentPortMode";
            labCurrentPortMode.Size = new Size(165, 26);
            labCurrentPortMode.TabIndex = 1;
            labCurrentPortMode.Text = "label6";
            labCurrentPortMode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(0, 57, 155);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Top;
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(165, 18);
            label5.TabIndex = 0;
            label5.Text = "PORT TYPE";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbWIP_BCR_ID
            // 
            txbWIP_BCR_ID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbWIP_BCR_ID.BackColor = Color.Black;
            txbWIP_BCR_ID.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txbWIP_BCR_ID.ForeColor = Color.Yellow;
            txbWIP_BCR_ID.Location = new Point(99, 267);
            txbWIP_BCR_ID.Name = "txbWIP_BCR_ID";
            txbWIP_BCR_ID.ReadOnly = true;
            txbWIP_BCR_ID.Size = new Size(178, 23);
            txbWIP_BCR_ID.TabIndex = 26;
            txbWIP_BCR_ID.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 270);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 25;
            label1.Text = "BCR READ ID";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // labUnloading
            // 
            labUnloading.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labUnloading.BackColor = SystemColors.ControlDarkDark;
            labUnloading.BorderStyle = BorderStyle.FixedSingle;
            labUnloading.FlatStyle = FlatStyle.Flat;
            labUnloading.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUnloading.ForeColor = Color.White;
            labUnloading.Location = new Point(353, 80);
            labUnloading.Margin = new Padding(1);
            labUnloading.Name = "labUnloading";
            labUnloading.Size = new Size(58, 19);
            labUnloading.TabIndex = 35;
            labUnloading.Text = "Unloading";
            labUnloading.TextAlign = ContentAlignment.MiddleCenter;
            labUnloading.Visible = false;
            // 
            // labLoading
            // 
            labLoading.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labLoading.BackColor = SystemColors.ControlDarkDark;
            labLoading.BorderStyle = BorderStyle.FixedSingle;
            labLoading.FlatStyle = FlatStyle.Flat;
            labLoading.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoading.ForeColor = Color.White;
            labLoading.Location = new Point(413, 80);
            labLoading.Margin = new Padding(1);
            labLoading.Name = "labLoading";
            labLoading.Size = new Size(58, 19);
            labLoading.TabIndex = 36;
            labLoading.Text = "Loading";
            labLoading.TextAlign = ContentAlignment.MiddleCenter;
            labLoading.Visible = false;
            // 
            // labAutoStatus
            // 
            labAutoStatus.BackColor = Color.Orange;
            labAutoStatus.BorderStyle = BorderStyle.FixedSingle;
            labAutoStatus.FlatStyle = FlatStyle.Flat;
            labAutoStatus.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labAutoStatus.ForeColor = Color.White;
            labAutoStatus.Location = new Point(184, 6);
            labAutoStatus.Margin = new Padding(1);
            labAutoStatus.Name = "labAutoStatus";
            labAutoStatus.Size = new Size(101, 42);
            labAutoStatus.TabIndex = 37;
            labAutoStatus.Text = "MANUAL";
            labAutoStatus.TextAlign = ContentAlignment.MiddleCenter;
            labAutoStatus.DoubleClick += labAutoStatus_DoubleClick;
            // 
            // labPortEventRepShow
            // 
            labPortEventRepShow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labPortEventRepShow.BackColor = SystemColors.ActiveCaption;
            labPortEventRepShow.BorderStyle = BorderStyle.FixedSingle;
            labPortEventRepShow.FlatStyle = FlatStyle.Flat;
            labPortEventRepShow.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortEventRepShow.ForeColor = Color.White;
            labPortEventRepShow.Location = new Point(184, 54);
            labPortEventRepShow.Margin = new Padding(1);
            labPortEventRepShow.Name = "labPortEventRepShow";
            labPortEventRepShow.Size = new Size(95, 24);
            labPortEventRepShow.TabIndex = 38;
            labPortEventRepShow.Text = "Event Report ";
            labPortEventRepShow.TextAlign = ContentAlignment.MiddleCenter;
            labPortEventRepShow.Visible = false;
            labPortEventRepShow.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txbPortID);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(7, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 46);
            panel2.TabIndex = 39;
            // 
            // txbPortID
            // 
            txbPortID.BackColor = Color.Black;
            txbPortID.Dock = DockStyle.Fill;
            txbPortID.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            txbPortID.ForeColor = Color.Yellow;
            txbPortID.Location = new Point(0, 18);
            txbPortID.Name = "txbPortID";
            txbPortID.ReadOnly = true;
            txbPortID.Size = new Size(167, 24);
            txbPortID.TabIndex = 27;
            txbPortID.Text = "3F_AGVC02_PORT_2_1";
            txbPortID.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(0, 57, 155);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Top;
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(167, 18);
            label4.TabIndex = 0;
            label4.Text = "PORT ID";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labServiceStatusText
            // 
            labServiceStatusText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labServiceStatusText.AutoSize = true;
            labServiceStatusText.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labServiceStatusText.ForeColor = Color.Red;
            labServiceStatusText.Location = new Point(359, 293);
            labServiceStatusText.Name = "labServiceStatusText";
            labServiceStatusText.Size = new Size(144, 24);
            labServiceStatusText.TabIndex = 40;
            labServiceStatusText.Text = "Out Of Service";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(184, 84);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 41;
            label3.Text = "IO LINK";
            label3.Click += label3_Click;
            // 
            // labPortTypeChgReq
            // 
            labPortTypeChgReq.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labPortTypeChgReq.BackColor = Color.Firebrick;
            labPortTypeChgReq.BorderStyle = BorderStyle.FixedSingle;
            labPortTypeChgReq.FlatStyle = FlatStyle.Flat;
            labPortTypeChgReq.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labPortTypeChgReq.ForeColor = Color.White;
            labPortTypeChgReq.Location = new Point(340, 266);
            labPortTypeChgReq.Margin = new Padding(1);
            labPortTypeChgReq.Name = "labPortTypeChgReq";
            labPortTypeChgReq.Size = new Size(155, 24);
            labPortTypeChgReq.TabIndex = 42;
            labPortTypeChgReq.Text = "IN/OUPUT 模式切換";
            labPortTypeChgReq.TextAlign = ContentAlignment.MiddleCenter;
            labPortTypeChgReq.Visible = false;
            labPortTypeChgReq.Click += label2_Click_1;
            // 
            // txbOnPortID
            // 
            txbOnPortID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbOnPortID.BackColor = Color.Black;
            txbOnPortID.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txbOnPortID.ForeColor = Color.SlateGray;
            txbOnPortID.Location = new Point(99, 296);
            txbOnPortID.Name = "txbOnPortID";
            txbOnPortID.ReadOnly = true;
            txbOnPortID.Size = new Size(178, 23);
            txbOnPortID.TabIndex = 44;
            txbOnPortID.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(6, 299);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 43;
            label6.Text = "RPT MCS ID";
            // 
            // labAGVReadyToTransfer
            // 
            labAGVReadyToTransfer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labAGVReadyToTransfer.AutoSize = true;
            labAGVReadyToTransfer.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            labAGVReadyToTransfer.ForeColor = Color.White;
            labAGVReadyToTransfer.Location = new Point(380, 34);
            labAGVReadyToTransfer.Name = "labAGVReadyToTransfer";
            labAGVReadyToTransfer.Size = new Size(126, 23);
            labAGVReadyToTransfer.TabIndex = 45;
            labAGVReadyToTransfer.Text = "AGV 準備取放";
            labAGVReadyToTransfer.Visible = false;
            // 
            // labLDULDStatus
            // 
            labLDULDStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labLDULDStatus.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            labLDULDStatus.ForeColor = Color.White;
            labLDULDStatus.Location = new Point(353, 7);
            labLDULDStatus.Name = "labLDULDStatus";
            labLDULDStatus.Size = new Size(153, 23);
            labLDULDStatus.TabIndex = 46;
            labLDULDStatus.Text = "移載狀態錯誤";
            labLDULDStatus.TextAlign = ContentAlignment.MiddleRight;
            labLDULDStatus.Visible = false;
            // 
            // UscConverterPortStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Gray;
            Controls.Add(labLDULDStatus);
            Controls.Add(labAGVReadyToTransfer);
            Controls.Add(txbOnPortID);
            Controls.Add(label6);
            Controls.Add(labPortTypeChgReq);
            Controls.Add(label3);
            Controls.Add(labServiceStatusText);
            Controls.Add(panel2);
            Controls.Add(labPortEventRepShow);
            Controls.Add(labAutoStatus);
            Controls.Add(labLoading);
            Controls.Add(labUnloading);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(txbWIP_BCR_ID);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UscConverterPortStatus";
            Size = new Size(509, 321);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label labLoadRequestBit;
        private Label labUnloadRequestBit;
        private Label labPortExistBit;
        private Label labL_REQBit;
        private Label labU_REQBit;
        private Label labReadyBit;
        private Label labBusyBit;
        private Panel panel1;
        private Label labCurrentPortMode;
        private Label label5;
        private TextBox txbWIP_BCR_ID;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label labUpPosition;
        private Label labDownPosition;
        private Label labUnloading;
        private Label labLoading;
        private Label labAutoStatus;
        private Label labPortEventRepShow;
        private Panel panel2;
        private Label label4;
        private Label labServiceStatusText;
        private Label label3;
        private Label labPortStatusDown;
        private Label labEQReadyBit;
        private Label labPortTypeChgReq;
        private TextBox txbOnPortID;
        private Label label6;
        private Label labAGVReadyToTransfer;
        private Label labWaitIn;
        private Label labWaitOut;
        private TextBox txbPortID;
        private Label labCIMHandshakingWithAGV;
        private Label lab_AGV_Valid;
        private Label lab_AGV_TR;
        private Label lab_AGV_Busy;
        private Label lab_AGV_Ready;
        private Label label10;
        private Label label11;
        private Label lab_AGV_Compt;
        private Label label2;
        private Label label7;
        private Label labLDULDStatus;
    }
}
