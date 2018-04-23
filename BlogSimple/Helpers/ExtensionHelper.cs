using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSimple.Helpers
{
    public static class ExtensionHelper
    {
        /// <summary>
        /// extention for config
        /// </summary>
        /// <typeparam name="TConfig"></typeparam>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection serviceCollection,
            IConfiguration configuration) where TConfig : class, new()
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));
            if(configuration ==null)
                throw new ArgumentNullException(nameof(configuration));
            var config = new TConfig();

            // bind all setting from appsetting.json
            configuration.Bind(config);
            //register singleton
            serviceCollection.AddSingleton(config);

            return config;
        }
    
    }
}
