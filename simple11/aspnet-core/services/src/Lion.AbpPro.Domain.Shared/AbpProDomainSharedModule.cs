using Lion.AbpPro.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization.Resources.AbpLocalization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.TenantManagement;
using Volo.Abp.Timing.Localization.Resources.AbpTiming;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Lion.AbpPro
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
    )]
    public class AbpProDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpProGlobalFeatureConfigurator.Configure();
            AbpProModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpProDomainSharedModule>("Lion.AbpPro");
            });
          
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpProResource>("zh-Hans")
                    .AddVirtualJson("/Localization/AbpPro")
                    .AddBaseTypes(typeof(IdentityResource))
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddBaseTypes(typeof(AbpLocalizationResource))
                    .AddBaseTypes(typeof(AbpTimingResource))
                    .AddBaseTypes(typeof(AbpSettingManagementResource));

                options.DefaultResourceType = typeof(AbpProResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpPro", typeof(AbpProResource));
            });
        }

       
    }
}