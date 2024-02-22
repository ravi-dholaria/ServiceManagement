using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        public string servicePath;

        public ServiceDetailForm()
        {
            InitializeComponent();
            StartTypeComboBox.Items.Add("auto");
            StartTypeComboBox.Items.Add("Manual");
            StartTypeComboBox.Items.Add("Disabled");
            StartTypeComboBox.Items.Add("Delayed-auto");
            
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            //try catch block to handle exception
            try
            {
                if (DisplayNametextBox.Text != string.Empty && serviceName != string.Empty)
                {
                    DispName = DisplayNametextBox.Text;
                    ServiceDescription = DescriptiontextBox.Text;
                    ServiceStartType = StartTypeComboBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Service Name cannot be empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public void changeServiceProperties()
        {
            if ((serviceName != null))
            {
                ChangeServiceDisplayName(serviceName, DispName);
                ChangeServiceDescription(serviceName, ServiceDescription);
                ChangeServiceStartupType(serviceName, ServiceStartType);
            }else throw new Exception("Service Name not found");
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

        private void ServiceFileBtn_Click(object sender, EventArgs e)
        {
            // Execute the code on the main UI thread
            this.Invoke(new Action(() =>
            {
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Executable files (*.exe)|*.exe",
                    Title = "Select the service file"
                };
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    servicePath = fileDialog.FileName;
                }
                GetServiceName(servicePath);
            }));
        }
        private void GetServiceName(string ServicePath)
        {
            // Load the assembly from the provided path
            Assembly assembly = Assembly.LoadFrom($"{ServicePath}");

            // Get the AssemblyTitle attribute
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            if (attributes.Length > 0)
            {
                serviceName = ((AssemblyTitleAttribute)attributes[0]).Title;
                Console.WriteLine("Service Name: " + serviceName);
            }
            else
            {
                Console.WriteLine("Service name not found.");
            }
        }
    }
}
