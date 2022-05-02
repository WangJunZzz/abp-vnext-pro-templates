namespace Lion.AbpPro.Permissions
{
    public static class AbpProPermissions
    {
        /// <summary>
        /// 系统管理扩展权限
        /// </summary>
        public static class SystemManagement
        {
            public const string Default = "System";
            public const string UserEnable = Default + ".Users.Enable";
            public const string UserExport = Default + ".Users.Export";
            public const string AuditLog = Default + ".AuditLog";
            public const string ES = Default + ".ES";
            public const string Setting = Default + ".Setting";
        }

    }
}