using Microsoft.EntityFrameworkCore;
using Noticia.Application.Interface;
using Noticia.Core.Entidade;

namespace Noticia.Infra
{
    public abstract class EFRepositoryBase<TDbContext, TEntity> : IRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        protected readonly TDbContext _context;

        public EFRepositoryBase(TDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}