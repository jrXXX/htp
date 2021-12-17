using System;
using Microsoft.Extensions.Options;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Configuration
{
    public static class BackendConfigurationHelper
    {
        static IServiceProvider _services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get => _services;
            set
            {
                if (_services != null)
                {
                    throw new NullReferenceException("Can't set once a value has already been set.");
                }
                _services = value;
            }
        }

        public static BackendConfiguration Config
        {
            get
            {
                //This works to get file changes.
                var s = _services.GetService(typeof(IOptionsMonitor<BackendConfiguration>)) as IOptionsMonitor<BackendConfiguration>;
                var config = s.CurrentValue;

                return config;
            }
        }
    }
}