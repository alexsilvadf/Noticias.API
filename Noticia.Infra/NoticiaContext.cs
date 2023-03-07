using Microsoft.EntityFrameworkCore;
using Noticia.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Infra
{
    public class NoticiaContext: DbContext
    {
        public NoticiaContext(DbContextOptions<NoticiaContext> options) : base(options)
        {

        }

        public DbSet<Noticiario> Noticiario { get; set; }
    }
}
