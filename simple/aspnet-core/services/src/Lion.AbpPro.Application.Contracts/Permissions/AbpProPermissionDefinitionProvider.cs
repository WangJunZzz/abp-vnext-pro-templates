using Lion.AbpPro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Lion.AbpPro.Permissions
{
    public class AbpProPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var abpIdentityGroup = context.GetGroup(IdentityPermissions.GroupName);
            var userManagement = abpIdentityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
            userManagement.AddChild(AbpProPermissions.SystemManagement.UserEnable, L("Permission:Enable"));
            userManagement.AddChild(AbpProPermissions.SystemManagement.UserExport, L("Permission:Export"));

            var auditManagement =
                abpIdentityGroup.AddPermission(AbpProPermissions.SystemManagement.AuditLog, L("Permission:AuditLogManagement"));
            var settingManagement = abpIdentityGroup.AddPermission(AbpProPermissions.SystemManagement.Setting, L("Permission:SettingManagement"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpProResource>(name);
        }
    }
}