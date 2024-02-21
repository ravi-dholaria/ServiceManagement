using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace ServiceManagement
{
    internal class ServiceInstallerClass
    {
        //Method to install the service from given path using installutil show popup that shows status of process and as process complete close that popup.
        public void InstallService(string servicePath)
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
            // Perform the installation using installutil
            process.StandardInput.WriteLine("cd " + Path.GetDirectoryName(servicePath));
            process.StandardInput.WriteLine("installutil " + servicePath);
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();
        }
      
        //Method to uninstall the service from given path using installutil.
        public void UninstallService(string servicePath)
        {
            using (ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller()) ;
            using (ServiceInstaller serviceInstaller = new ServiceInstaller())
            {
                // Set the service name
                serviceInstaller.ServiceName = servicePath;

                // Create an instance of TransactedInstaller
                using (TransactedInstaller transactedInstaller = new TransactedInstaller())
                {
                    // Add the service installer to the transacted installer
                    transactedInstaller.Installers.Add(serviceInstaller);

                    // Uninstall the service
                    transactedInstaller.Uninstall(null);
                }
            }
        }
    }
}