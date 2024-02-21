using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManagement
{
    public partial class ServiceDetailForm : Form
    {
        public string serviceName;
        public string DispName;
        public string ServiceDescription;
        public string ServiceStartType;
        public ServiceDetailForm(string serviceName)
        {
            this.serviceName = serviceName;
            InitializeComponent();
            StartTypeComboBox.Items.Add("auto");
            StartTypeComboBox.Items.Add("Manual");
            StartTypeComboBox.Items.Add("Disabled");
            StartTypeComboBox.Items.Add("Delayed-auto");
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (DisplayNametextBox.Text != string.Empty)
            {
                DispName = DisplayNametextBox.Text;
                ServiceDescription = DescriptiontextBox.Text;
                ServiceStartType = StartTypeComboBox.Text;
                changeServiceProperties(serviceName, DispName, ServiceDescription, ServiceStartType);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Service Name cannot be empty");
            }
        }
       
        public void changeServiceProperties(string serviceName, string newDisplayName = "Service", string serviceDescription = "", string startMode = "demand")
        {

            ChangeServiceDisplayName(serviceName, newDisplayName);
            ChangeServiceDescription(serviceName, serviceDescription);
            ChangeServiceStartupType(serviceName, startMode.ToString());
        }

        public void ChangeServiceDisplayName(string serviceName, string newDisplayName)
        {
            string command = $"sc config {serviceName} DisplayName= \"{newDisplayName}\"";
            RunCommand(command);
        }

        public void ChangeServiceDescription(string serviceName, string newDescription)
        {
            string command = $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\{serviceName}\" /v Description /t REG_SZ /d \"{newDescription}\" /f";
            RunCommand(command);
        }

        public void ChangeServiceStartupType(string serviceName, string startupType)
        {
            string command = $"sc config {serviceName} start= {startupType}";
            RunCommand(command);
        }

        private void RunCommand(string command)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {command}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();
                    process.WaitForExit();
                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
