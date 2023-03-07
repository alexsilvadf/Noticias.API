using Noticia.Core.Entidade;
using Noticia.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Core.Interface
{
    public interface INoticiarioRepository
    {
        Task<List<Noticiario>> BuscarNoticiasAsync();
    }
}
