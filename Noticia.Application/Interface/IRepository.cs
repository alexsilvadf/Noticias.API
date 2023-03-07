using Noticia.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Application.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
    }
}
