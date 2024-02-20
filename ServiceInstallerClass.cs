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
        //Method to install the service from given path.
        public static void InstallService(string servicePath, string serviceName = "MyDriveService", string serviceDisplayName = "MyDriveService", string serviceDescription = "MyDriveService", ServiceStartMode startMode = ServiceStartMode.Manual)
        {
            try
            {
                // Create a service process description.
                ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
                ServiceInstaller serviceInstaller = new ServiceInstaller();

                // Set the service credentials (if necessary).
                processInstaller.Account = ServiceAccount.LocalSystem;

                // Set the service properties.
                serviceInstaller.StartType = startMode;
                serviceInstaller.ServiceName = serviceName;
                serviceInstaller.DisplayName = serviceDisplayName;
                serviceInstaller.Description = serviceDescription;
                serviceInstaller.DelayedAutoStart = true; // This can be set to true if necessary.

                // Set the service source.
                serviceInstaller.Context = new System.Configuration.Install.InstallContext();
                serviceInstaller.Context.Parameters["assemblypath"] = servicePath;

                // Install the service.
                System.Configuration.Install.AssemblyInstaller installer = new System.Configuration.Install.AssemblyInstaller();
                installer.UseNewContext = true;
                installer.Installers.Add(processInstaller);
                installer.Installers.Add(serviceInstaller);
                installer.Path = servicePath;
                installer.Install(new System.Collections.Hashtable());

                Console.WriteLine("Service installed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error installing service: " + ex.Message);
            }
        }

        //Method to uninstall the service from selected service using.
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
