using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
    public class ConfigSettings
    {
        public ConfigSettings(StatelessServiceContext statelessServiceContext)
        {
            statelessServiceContext.CodePackageActivationContext.ConfigurationPackageModifiedEvent += CodePackageActivationContext_ConfigurationPackageModifiedEvent; ;
            this.UpdateConfiguration(statelessServiceContext.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings);
        }

        private void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> e)
        {
            this.UpdateConfiguration(e.NewPackage.Settings);
        }

        private void UpdateConfiguration(ConfigurationSettings newPackageSettings)
        {
            ConfigurationSection section = newPackageSettings.Sections["GatewayConfig"];
            this.GeographyServiceName = section.Parameters["GeoServiceName"].Value;
            this.ProductServiceName = section.Parameters["proServiceName"].Value;
            this.ReverseProxyPort = int.Parse(section.Parameters["ReverseProxyPort"].Value);
        }


        public String GeographyServiceName { get; set; }

        public String ProductServiceName { get; set; }

        public int ReverseProxyPort { get; set; }
    }
}
