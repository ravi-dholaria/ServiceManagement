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
        #region class variables and constructor
        private readonly ServiceController[] services;
        public Form1()
        {
            InitializeComponent();
            services = ServiceController.GetServices();
        }
        #endregion

        #region Form1 Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns.Add("SrNo", "Sr No");
            dataGridView1.Columns.Add("ServiceName", "Service Name");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns[0].FillWeight = 10;

            // Set DataGridView properties
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            // Hook up the CellClick event
            dataGridView1.CellClick += DataGridView1_CellClick;

            RefreshBtn_Click(sender, e);
        }
        #endregion

        #region DataGridView1_CellClick 
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click to select the entire row
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        #endregion

        #region RefresBtn
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
        #endregion

        #region StartServiceBtn
        private void StartServiceBtn_Click_1(object sender, EventArgs e)
        {
            // Start the selected service
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string serviceName = dataGridView1.Rows[selectedIndex].Cells["ServiceName"].Value.ToString();
                ServiceController service = services.FirstOrDefault(s => s.DisplayName == serviceName);
                //check service is not null and service status is not running
                if (service != null && service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after starting the service
                }
                
            }
        }
        #endregion
        
        #region StopServiceBtn
        private void StopServiceBtn_Click_1(object sender, EventArgs e)
        {
            // Stop the selected service
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string serviceName = dataGridView1.Rows[selectedIndex].Cells["ServiceName"].Value.ToString();
                ServiceController service = services.FirstOrDefault(s => s.DisplayName == serviceName);
                //check service is not null and service status is not stopped
                if (service != null && service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after stopping the service
                }
            }
        }
        #endregion
    }
}
