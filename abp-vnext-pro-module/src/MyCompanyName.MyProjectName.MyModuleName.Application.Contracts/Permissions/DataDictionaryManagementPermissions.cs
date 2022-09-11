namespace MyCompanyName.MyProjectName.MyModuleName.Permissions
{
    public class MyModuleNamePermissions
    {
        public const  string GroupName = "AbpIdentity";

        public static class MyModuleName
        {
            public const string Default = GroupName + ".MyModuleName";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MyModuleNamePermissions));
        }
    }
}