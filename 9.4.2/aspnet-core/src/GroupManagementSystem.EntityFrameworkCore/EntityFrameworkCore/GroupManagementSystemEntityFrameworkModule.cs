using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using GroupManagementSystem.EntityFrameworkCore.Seed;

namespace GroupManagementSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(GroupManagementSystemCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class GroupManagementSystemEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<GroupManagementSystemDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        GroupManagementSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        GroupManagementSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GroupManagementSystemEntityFrameworkModule).GetAssembly());

        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
