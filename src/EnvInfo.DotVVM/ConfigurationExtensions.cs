using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using EnvInfo.Core;
using System.Reflection;

namespace EnvInfo.DotVVM
{
    public static class ConfigurationExtensions
    {
        public static void AddEnvInfoConfiguration(this DotvvmConfiguration config)
        {
            config.Markup.AddCodeControls("dot", typeof(EnvInfo));

            config.Resources.Register(EnvInfoConsts.StyleResourceName, new StylesheetResource()
            {
                Location = new EmbeddedResourceLocation(typeof(EnvInfoOptions).GetTypeInfo().Assembly, "EnvInfo.Core.Styles.env-info-default.css")
            });
        }
    }
}
