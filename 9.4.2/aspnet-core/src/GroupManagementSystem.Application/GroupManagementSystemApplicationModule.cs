using System;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using GroupManagementSystem.Authorization;
using GroupManagementSystem.Manager.Interfaces;
using GroupManagementSystem.Manager.Services;

namespace GroupManagementSystem
{
    [DependsOn(
        typeof(GroupManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class GroupManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<GroupManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(GroupManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
            IocManager.IocContainer.Register(Component.For<IGMSTrasactionAppService>().ImplementedBy<GMSTransactionAppService>().LifestyleTransient()
            .Named(nameof(GMSTransactionAppService)));

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                    cfg.AddProfile<GroupManagementSystem.Utis.AutoMapperProfile>();
                }
            );
        }
    }
}
