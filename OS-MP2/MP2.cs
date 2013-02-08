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
        }
    }
}
