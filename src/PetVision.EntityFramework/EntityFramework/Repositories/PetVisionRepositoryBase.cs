using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace PetVision.EntityFramework.Repositories
{
    public abstract class PetVisionRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PetVisionDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PetVisionRepositoryBase(IDbContextProvider<PetVisionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PetVisionRepositoryBase<TEntity> : PetVisionRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PetVisionRepositoryBase(IDbContextProvider<PetVisionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
