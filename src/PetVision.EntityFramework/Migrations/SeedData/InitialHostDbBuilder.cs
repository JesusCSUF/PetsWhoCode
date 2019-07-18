using PetVision.EntityFramework;
using EntityFramework.DynamicFilters;

namespace PetVision.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PetVisionDbContext _context;

        public InitialHostDbBuilder(PetVisionDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
