using System;
using System.Configuration;

namespace T4Config
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
            };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(configurationFileMap, ConfigurationUserLevel.None);

            foreach (KeyValueConfigurationElement setting in configuration.AppSettings.Settings)
            {
                Console.WriteLine("key: {0}, value: {1}", setting.Key, setting.Value);
            }

            Console.ReadLine();
        }
    }
}
