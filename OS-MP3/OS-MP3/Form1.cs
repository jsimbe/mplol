using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS_MP3
{
    public partial class Form1 : Form
    {
        Seeker s = new Seeker();
        List<Request> requestPlot = new List<Request>();

        public Form1()
        {
            InitializeComponent();
            s.Init();
            formInit();
        }

        void formInit()
        {
            btnReset.Enabled = false;
            btnSimulate.Enabled = true;
            groupBox1.Enabled = true;
            btnEdit.Enabled = true;
            rbScan.Checked = true;

            lvRequest.Items.Clear();

            List<Request> requestList = s.GetRequestList();
            foreach (Request r in requestList)
            {
                ListViewItem lvi = new ListViewItem(r.RequestNumber.ToString());
                ListViewItem.ListViewSubItem arrivalTime = new ListViewItem.ListViewSubItem(lvi, r.ArrivalTime.ToString());
                ListViewItem.ListViewSubItem requestedTrack = new ListViewItem.ListViewSubItem(lvi, r.Track.ToString());
                arrivalTime.Name = "arrivalTime";
                requestedTrack.Name = "requestedTrack";
                lvi.SubItems.Add(arrivalTime);
                lvi.SubItems.Add(requestedTrack);
                lvi.Tag = r;

                lvRequest.Items.Add(lvi);
            }
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
            groupBox1.Enabled = false;
            btnEdit.Enabled = false;
            btnSimulate.Enabled = false;

            requestPlot = s.Simulate();

            chart1.DataSource = requestPlot;
            chart1.Series[0].XValueMember = "TimeAccessed";
            chart1.Series[0].YValueMembers = "Track";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.Series[0].ToolTip = "#VALX{d}";
            chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chart1.DataBind();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            s.Init();
            formInit();
            chart1.Series.Clear();
            chart1.Series.Add("series1");
        }

        private void rbScan_CheckedChanged(object sender, EventArgs e)
        {
            s.OptimizeStrategy = new Scan();
        }

        private void rbSSTF_CheckedChanged(object sender, EventArgs e)
        {
            s.OptimizeStrategy = new SSTF();
        }

        private void rbLook_CheckedChanged(object sender, EventArgs e)
        {
            //placeholder.
            s.OptimizeStrategy = new Scan();
        }

        private void lvRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRequest.SelectedItems.Count > 0)
            {
                Request request = lvRequest.FocusedItem.Tag as Request;
                txtArrivalTime.Text = request.ArrivalTime.ToString();
                txtLocation.Text = request.Track.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvRequest.SelectedItems.Count > 0)
            {
                Request request = lvRequest.FocusedItem.Tag as Request;
                request.Track = Int32.Parse(txtLocation.Text);
                request.ArrivalTime = Int32.Parse(txtArrivalTime.Text);

                lvRequest.FocusedItem.SubItems["arrivalTime"].Text = txtArrivalTime.Text;
                lvRequest.FocusedItem.SubItems["requestedTrack"].Text = txtLocation.Text;
            }
        }
    }
}
