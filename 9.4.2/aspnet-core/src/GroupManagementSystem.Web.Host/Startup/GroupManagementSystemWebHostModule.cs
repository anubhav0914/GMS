using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GroupManagementSystem.Configuration;

namespace GroupManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(GroupManagementSystemWebCoreModule))]
    public class GroupManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public GroupManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GroupManagementSystemWebHostModule).GetAssembly());
        }
    }
}
