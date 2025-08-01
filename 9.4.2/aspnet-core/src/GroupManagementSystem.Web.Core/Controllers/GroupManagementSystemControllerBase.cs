using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace GroupManagementSystem.Controllers
{
    public abstract class GroupManagementSystemControllerBase: AbpController
    {
        protected GroupManagementSystemControllerBase()
        {
            LocalizationSourceName = GroupManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
