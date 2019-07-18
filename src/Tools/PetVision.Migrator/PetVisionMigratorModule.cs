using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using PetVision.EntityFramework;

namespace PetVision.Migrator
{
    [DependsOn(typeof(PetVisionDataModule))]
    public class PetVisionMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<PetVisionDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}