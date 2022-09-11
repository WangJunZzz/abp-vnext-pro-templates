namespace MyCompanyName.MyProjectName.MyModuleName.Permissions
{
    public class MyModuleNamePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var abpIdentityGroup = context.GetGroup("AbpIdentity");

            var MyModuleName = abpIdentityGroup.AddPermission(MyModuleNamePermissions.MyModuleName.Default,
                L("Permission:MyModuleName"));
            MyModuleName.AddChild(MyModuleNamePermissions.MyModuleName.Create, L("Permission:Create"));
            MyModuleName.AddChild(MyModuleNamePermissions.MyModuleName.Update, L("Permission:Update"));
            MyModuleName.AddChild(MyModuleNamePermissions.MyModuleName.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MyModuleNameResource>(name);
        }
    }
}