using AutoMapper;
using Noticia.Application.Interface;
using Noticia.Core.Entidade;
using Noticia.Core.Interface;
using Noticia.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Application
{
    public class NoticiaService : INoticiaService
    {
        private readonly IMapper _mapper;
        private readonly INoticiarioRepository _noticiarioRepository;

        public NoticiaService(INoticiarioRepository noticiarioRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noticiarioRepository = noticiarioRepository;
        }

        public async Task<List<Noticiario>> BuscarNoticias()
        {
            var listaNoticias = await _noticiarioRepository.BuscarNoticiasAsync();

            return listaNoticias;
        }

        public async Task<Noticiario> IncluirNoticiaAsync(NoticiaInput input)
        {
            var noticiario = new Noticiario();
            _mapper.Map<NoticiaInput, Noticiario>(input, noticiario);

            //await _noticiarioRepository.IncluirNoticiaAsync(noticiario);

            return null;
        }
    }
}
