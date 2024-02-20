using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManagement
{
    public partial class Form1 : Form
    {

        private ProgressForm progressForm;

        #region constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
        private void showProgressForm(string msg)
        {
            progressForm = new ProgressForm(msg);
            progressForm.StartPosition = FormStartPosition.CenterScreen;
            progressForm.Show();
        }

        #region Form1 Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Set up the DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns.Add("SrNo", "Sr No");
            dataGridView1.Columns.Add("ServiceName", "Service Name");
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("StartType", "Start Type");
            dataGridView1.Columns[0].FillWeight = 15;

            // Set DataGridView properties
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            // Hook up the CellClick event
            dataGridView1.CellClick += DataGridView1_CellClick;
            
            //subscribe to Textchange event for searchbox
            SearchBox.TextChanged += SearchBox_TextChanged;

            //call the refresh button click method 
            RefreshBtn_Click(sender, e);

            //call the refresh button click method at every 5 
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += new EventHandler(RefreshBtn_Click);
            timer.Start();
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
            // Refresh the DataGridView
            int selectedRowIndex = -1;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            }
            // Clear the DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            // Code to repopulate the DataGridView
            dataGridView1.AllowUserToAddRows = true;

            ServiceController[] services = ServiceController.GetServices();
            // Add services to the DataGridView
            int i = 1;
            foreach (ServiceController service in services)
            {
                //string description = new ServiceInfoClass().GetServiceDescription(service.ServiceName);
                dataGridView1.Rows.Add(i, service.ServiceName,service.DisplayName, service.Status, service.StartType);
                i++;
            }
            // Select the previously selected row
            if (selectedRowIndex!=-1 && dataGridView1.Rows.Count > selectedRowIndex)
            {
                dataGridView1.Rows[selectedRowIndex].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = selectedRowIndex;
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
                ServiceController service = ServiceController.GetServices().FirstOrDefault(s => s.DisplayName == serviceName);
                //check service is not null and service status is not running
                if (service != null && service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after starting the service
                }
                else RefreshBtn_Click(sender, e); // Refresh the DataGridView after starting the service
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
                 ServiceController service = ServiceController.GetServices().FirstOrDefault(s => s.DisplayName == serviceName);
                //check service is not null and service status is not stopped
                if (service != null && service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    RefreshBtn_Click(sender, e); // Refresh the DataGridView after stopping the service
                } else
                RefreshBtn_Click(sender, e); // Refresh the DataGridView after starting the service
            }
        }
        #endregion

        #region SearchBox
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchBox.Text = SearchBox.Text;
            if (SearchBox.Text != "")
            {
                dataGridView1.ClearSelection();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cellValue = row.Cells["ServiceName"].Value;
                    if (cellValue != null && cellValue.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }
        #endregion

        #region ClearBtn
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            SearchBox_TextChanged(sender, e);
        }
        #endregion

        #region InstallBtn
        private async void InstallBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select the service file"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                showProgressForm("Install");
                string servicePath = fileDialog.FileName;
                await Task.Run(() => new ServiceInstallerClass().InstallService(servicePath));
                // Close the progress form after installation is completed
                if (progressForm != null)
                {
                    progressForm.Invoke(new Action(() =>
                    {
                        progressForm.Close();
                        progressForm.Dispose();
                        progressForm = null;
                    }));
                }
                RefreshBtn_Click(sender, e);
                //scroll to installed service
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 2;
                //select installed service
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;
            }
        }
        #endregion

        #region UninstallBtn
        private async void UninstallBtn_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service to uninstall");
                return;
            }
            int selectedIndex = dataGridView1.SelectedRows[0].Index;
            var cellValue = dataGridView1.Rows[selectedIndex].Cells["ServiceName"].Value;
            if (cellValue == null)
            {
                MessageBox.Show("Please select a service to uninstall");
                return;
            }
            string serviceName = cellValue.ToString();
            ServiceController service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);
            if (service.Status == ServiceControllerStatus.Running)
            {
                MessageBox.Show("Please stop the service before uninstalling");
                return;
            }
            showProgressForm("Uninstall");
            //get the service path from service name
            string servicePath = service.ServiceName;
            await Task.Run(() => new ServiceInstallerClass().UninstallService(servicePath));
            // Close the progress form after uninstallation is completed
            if (progressForm != null)
            {
                progressForm.Invoke(new Action(() =>
                {
                    progressForm.Close();
                    progressForm.Dispose();
                    progressForm = null;
                }));
            }
            RefreshBtn_Click(sender, e);
        }
        #endregion
    }
}
