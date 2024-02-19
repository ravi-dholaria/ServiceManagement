using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration.Install;

namespace ServiceManagement
{
    internal class ServiceInstallerClass
    {
        //Method to install the service from given path using installutil show popup that shows status of process and as process complete close that popup.
        public static void InstallService(string servicePath)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas"
            };
            Process process = new Process
            {
                StartInfo = processInfo
            };
            process.Start();
            //open messagebox to show status of process and close it.
            MessageBox.Show("Installing Service");
            process.StandardInput.WriteLine("cd " + servicePath);
            process.StandardInput.WriteLine("installutil " + servicePath);
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();
            MessageBox.Show("Service Installed");
        }

        //Method to uninstall the service from given path using installutil.
        public static void UninstallService(string servicePath)
        {
            using( ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller());
            using (ServiceInstaller serviceInstaller = new ServiceInstaller())
            {
                // Set the service name
                serviceInstaller.ServiceName = servicePath;

                MessageBox.Show("Uninstalling Service");
                // Create an instance of TransactedInstaller
                using (TransactedInstaller transactedInstaller = new TransactedInstaller())
                {
                    // Add the service installer to the transacted installer
                    transactedInstaller.Installers.Add(serviceInstaller);

                    // Uninstall the service
                    transactedInstaller.Uninstall(null);
                }
                MessageBox.Show("Service Uninstalled");
            }
        }
    }
}
