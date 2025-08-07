using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GroupManagementSystem.Authorization;

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
