﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Galaxy.Cache.Bootstrapper.AutoFacModules;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Cache.Bootstrapper
{
    public static  class GalaxyCacheRegistrationExtensions
    {
        public static ContainerBuilder UseGalaxyInMemoryCache(this ContainerBuilder builder, IServiceCollection services)
        {
            RegisterInMemoryCacheFromSericeProvider(services);
            builder.RegisterModule(new InMemoryGlobalSettingsModule());
            builder.RegisterModule(new NewtonSoftSerializerModule());
            builder.RegisterModule(new InMemoryCacheModule());
            return builder;
        }

        private static void RegisterInMemoryCacheFromSericeProvider(IServiceCollection services) =>
            services.AddMemoryCache();
        
    }
}
