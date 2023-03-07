using Noticia.Core.Entidade;
using Noticia.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Application.Interface
{
    public interface INoticiaService
    {
        Task<Noticiario> IncluirNoticiaAsync(NoticiaInput input);
        Task<List<Noticiario>> BuscarNoticias();

    }
}
