namespace OS_MP3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lvRequest = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSSTF = new System.Windows.Forms.RadioButton();
            this.rbLook = new System.Windows.Forms.RadioButton();
            this.rbScan = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArrivalTime = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvRequest
            // 
            this.lvRequest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRequest.FullRowSelect = true;
            this.lvRequest.Location = new System.Drawing.Point(12, 12);
            this.lvRequest.MultiSelect = false;
            this.lvRequest.Name = "lvRequest";
            this.lvRequest.Size = new System.Drawing.Size(303, 219);
            this.lvRequest.TabIndex = 0;
            this.lvRequest.UseCompatibleStateImageBehavior = false;
            this.lvRequest.View = System.Windows.Forms.View.Details;
            this.lvRequest.SelectedIndexChanged += new System.EventHandler(this.lvRequest_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Arrival Time";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Location";
            this.columnHeader3.Width = 98;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(338, 321);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnSimulate.TabIndex = 1;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(511, 321);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chart1
            // 
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(321, 12);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(287, 219);
            this.chart1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSSTF);
            this.groupBox1.Controls.Add(this.rbLook);
            this.groupBox1.Controls.Add(this.rbScan);
            this.groupBox1.Location = new System.Drawing.Point(321, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rbSSTF
            // 
            this.rbSSTF.AutoSize = true;
            this.rbSSTF.Location = new System.Drawing.Point(190, 19);
            this.rbSSTF.Name = "rbSSTF";
            this.rbSSTF.Size = new System.Drawing.Size(52, 17);
            this.rbSSTF.TabIndex = 2;
            this.rbSSTF.TabStop = true;
            this.rbSSTF.Text = "SSTF";
            this.rbSSTF.UseVisualStyleBackColor = true;
            this.rbSSTF.CheckedChanged += new System.EventHandler(this.rbSSTF_CheckedChanged);
            // 
            // rbLook
            // 
            this.rbLook.AutoSize = true;
            this.rbLook.Location = new System.Drawing.Point(106, 19);
            this.rbLook.Name = "rbLook";
            this.rbLook.Size = new System.Drawing.Size(54, 17);
            this.rbLook.TabIndex = 1;
            this.rbLook.TabStop = true;
            this.rbLook.Text = "LOOK";
            this.rbLook.UseVisualStyleBackColor = true;
            this.rbLook.CheckedChanged += new System.EventHandler(this.rbLook_CheckedChanged);
            // 
            // rbScan
            // 
            this.rbScan.AutoSize = true;
            this.rbScan.Location = new System.Drawing.Point(17, 19);
            this.rbScan.Name = "rbScan";
            this.rbScan.Size = new System.Drawing.Size(54, 17);
            this.rbScan.TabIndex = 0;
            this.rbScan.TabStop = true;
            this.rbScan.Text = "SCAN";
            this.rbScan.UseVisualStyleBackColor = true;
            this.rbScan.CheckedChanged += new System.EventHandler(this.rbScan_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arrival Time:";
            // 
            // txtArrivalTime
            // 
            this.txtArrivalTime.Location = new System.Drawing.Point(83, 237);
            this.txtArrivalTime.Name = "txtArrivalTime";
            this.txtArrivalTime.Size = new System.Drawing.Size(42, 20);
            this.txtArrivalTime.TabIndex = 6;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(191, 238);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(49, 20);
            this.txtLocation.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Location:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(246, 238);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 365);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtArrivalTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.lvRequest);
            this.Name = "Form1";
            this.Text = "MP3 | Seek Strategy";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRequest;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSSTF;
        private System.Windows.Forms.RadioButton rbLook;
        private System.Windows.Forms.RadioButton rbScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArrivalTime;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
    }
}

