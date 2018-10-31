using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Contracts.Interface;
using Contracts.SDO;
using Data;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace Startup
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ILogger logger = new BlancLogger();
            string persName = "configuration.config";
            ConfigurationLoad(logger,persName);
            DispatcherHelper.Initialize();
        }

        private void ConfigurationLoad( ILogger log, string persFileName)
        {
            if (persFileName == null) throw new ArgumentNullException(nameof(persFileName));
            string applicationDir = AppDomain.CurrentDomain.BaseDirectory;
            persFileName = applicationDir + "\\" + persFileName;
            Session.Settings= new Settings();
            Session.SerializationManager = new SerialisationManager(applicationDir,log);
            Session.Settings = Session.SerializationManager.GetSettings();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Settings set = new Settings();
            set.SelectedPersonId = new List<string>();
            set.SelectedPointId = new List<string>();
        ConnectionSettings con = new ConnectionSettings();
            con.

            Session.SerializationManager.SerializeSettings(Session.Settings);
        }
    }
}
