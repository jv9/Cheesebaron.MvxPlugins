using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.Plugins;

namespace Cheesebaron.MvxPlugins.XamarinInsights.Droid
{
    public class Plugin 
        : IMvxPlugin
    {
        public void Load()
        {
            if (PluginLoader.Config == null || string.IsNullOrEmpty(PluginLoader.Config.ApiKey))
                throw new MvxException("You need to configure your plugin with an ApiKey!");

            var applicationContext = Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext;

            Xamarin.Insights.Initialize(PluginLoader.Config.ApiKey, applicationContext);

            Mvx.RegisterType(() => new AppInsights
            {
                ApiKey = PluginLoader.Config.ApiKey
            });
        }
    }
}
