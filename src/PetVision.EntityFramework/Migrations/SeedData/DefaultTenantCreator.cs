using System.Linq;
using PetVision.EntityFramework;
using PetVision.MultiTenancy;

namespace PetVision.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PetVisionDbContext _context;

        public DefaultTenantCreator(PetVisionDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
