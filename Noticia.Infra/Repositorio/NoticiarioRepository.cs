using Noticia.Core.Entidade;
using Noticia.Core.Interface;
using Noticia.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Infra.Repositorio
{
    public class NoticiarioRepository : INoticiarioRepository
    {
        public Task<bool> IncluirNoticiaAsync(Noticiario input)
        {
            throw new NotImplementedException();
        }
    }
}
