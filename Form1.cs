using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManagement
{
    public partial class Form1 : Form
    {
        private readonly ServiceController[] services;
        public Form1()
        {
            InitializeComponent();
            services = ServiceController.GetServices();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns.Add("SrNo", "Sr No");
            dataGridView1.Columns.Add("ServiceName", "Service Name");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns[0].FillWeight = 10;
            RefreshBtn_Click(sender, e);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            // Add services to the DataGridView
            int i = 1;
            foreach (ServiceController service in services)
            {
                dataGridView1.Rows.Add(i, service.DisplayName, service.Status);
                i++;
            }
        }
        private void StartServiceBtn_Click_1(object sender, EventArgs e)
        {
            // Start the selected service
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string serviceName = dataGridView1.Rows[selectedIndex].Cells["ServiceName"].Value.ToString();
                ServiceController service = services.FirstOrDefault(s => s.DisplayName == serviceName);
                if (service != null)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after starting the service
                }
            }
        }

        private void StopServiceBtn_Click_1(object sender, EventArgs e)
        {
            // Stop the selected service
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string serviceName = dataGridView1.Rows[selectedIndex].Cells["ServiceName"].Value.ToString();
                ServiceController service = services.FirstOrDefault(s => s.DisplayName == serviceName);
                if (service != null)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after stopping the service
                }
            }
        }
    }
}
