using Microsoft.EntityFrameworkCore;
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
    public class NoticiarioRepository :  INoticiarioRepository
    {
        private readonly NoticiaContext _context;
        public NoticiarioRepository(NoticiaContext noticiaContext, NoticiaContext context)
        {
            _context = context;
        }


        public async Task<List<Noticiario>> BuscarNoticiasAsync()
        {
            var resultado = await _context.Noticiario.ToListAsync();
            return resultado;
        }

        public Task<bool> IncluirNoticiaAsync(Noticiario input)
        {
            throw new NotImplementedException();
        }
    }
}
