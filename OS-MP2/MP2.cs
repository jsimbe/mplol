using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS_MP2
{
    public partial class MP2 : Form
    {

        Scheduler s = new Scheduler();
        

        public MP2()
        {
            InitializeComponent();
            formInit();
            //s.SchedulerBehaviour = new RR();
            
        }

        void formInit()
        {
            s.jobInit();
            s.waitingQueueInit();
            s.resetTime();
            lvJobs.Items.Clear();
            List<Job> jobList = s.GetJobList();

            foreach (Job j in jobList)
            {
                ListViewItem lvi = new ListViewItem(j.JobNumber.ToString());
                ListViewItem.ListViewSubItem arrivalTime = new ListViewItem.ListViewSubItem(lvi, j.ArrivalTime.ToString());
                ListViewItem.ListViewSubItem cpuCycle = new ListViewItem.ListViewSubItem(lvi, j.Cycle.ToString());
                ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem(lvi, j.JobType);
                arrivalTime.Name = "arrivalTime";
                cpuCycle.Name = "cpuCycle";
                type.Name = "type";
                lvi.SubItems.Add(arrivalTime);
                lvi.SubItems.Add(cpuCycle);
                lvi.SubItems.Add(type);
                lvi.Tag = j;

                lvJobs.Items.Add(lvi);

            }

            lblTime.Text = "";
            lblJobs.Text = "";

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            s.Simulate();
            lblTime.Text = s.timeline;
            lblJobs.Text = s.jobTimeLine;
            s.Compute();
            List<Job> finishedJobs = s.GetFinishedJobs();

            foreach (Job j in finishedJobs)
            {
                ListViewItem lvi = new ListViewItem(j.JobNumber.ToString());
                ListViewItem.ListViewSubItem TAT = new ListViewItem.ListViewSubItem(lvi, j.TurnaroundTime.ToString());
                ListViewItem.ListViewSubItem waitingTime = new ListViewItem.ListViewSubItem(lvi, j.WatingTime.ToString());
                lvi.SubItems.Add(TAT);
                lvi.SubItems.Add(waitingTime);
                lvCompute.Items.Add(lvi);

            }
        }

        private void lvJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvJobs.SelectedItems.Count > 0)
            {
                Job jobSelected = lvJobs.FocusedItem.Tag as Job;
                txtArrivalTime.Text = jobSelected.ArrivalTime.ToString();
                txtCPUCycle.Text = jobSelected.Cycle.ToString();
                txtJobType.Text = jobSelected.JobType.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Job jobSelected = lvJobs.FocusedItem.Tag as Job;
            jobSelected.ArrivalTime = Int32.Parse(txtArrivalTime.Text);
            jobSelected.Cycle = Int32.Parse(txtCPUCycle.Text);
            jobSelected.JobType = txtJobType.Text;

            //UI
            lvJobs.FocusedItem.SubItems["arrivalTime"].Text = txtArrivalTime.Text;
            lvJobs.FocusedItem.SubItems["cpuCycle"].Text = txtCPUCycle.Text;
            lvJobs.FocusedItem.SubItems["type"].Text = txtJobType.Text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblJobs.Text = "";
            lblTime.Text = "";
            formInit();
        }
    }
}
