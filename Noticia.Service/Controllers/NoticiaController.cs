using AutoMapper;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noticia.Application.Interface;
using Noticia.Core.Entidade;
using Noticia.Core.ViewModel;

namespace Noticia.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _noticiaService;
        private readonly IMapper _mapper;

        public NoticiaController(INoticiaService noticiaService, IMapper mapper)
        {
            _noticiaService = noticiaService;
            _mapper = mapper;
        }

        [HttpPost("Incluir")]
        public async Task<IActionResult> Post([FromForm] NoticiaInput input)
        {
            var filePath = Path.Combine("Storage", input.Imagem.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            input.Imagem.CopyTo(fileStream);

            input.CaminhoImagem = filePath;

            var resultado = await _noticiaService.IncluirNoticiaAsync(input);

            return new JsonResult(resultado);
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> Get()
        {

            var noticias = await _noticiaService.BuscarNoticias();

            //var dataBytes = System.IO.File.ReadAllBytes(Path.Combine("Storage", "IMG_20230103_090026.jpg"));

            


            var resultado = _mapper.Map<List<NoticiaOutput>>(noticias);

            for (int i = 0; i < noticias.Count; i++)
            {
                resultado[i].Titulo = noticias[i].Titulo;
                resultado[i].Descricao = noticias[i].Descricao;
                resultado[i].DataHoraInclusao = noticias[i].DataHoraInclusao;
                resultado[i].Imagem = System.IO.File.ReadAllBytes(Path.Combine(noticias[i].CaminhoImagem)); ;
            }

            return new JsonResult(resultado);       






            //var retorno = new List<NoticiaOutput>()
            //{
            //  new NoticiaOutput()
            //  {
            //      Id = 
            //      Titulo = "Primeiro Dia",
            //      Descricao =   "Chegada do Material para inicio das obras",
            //      Imagem = dataBytes,
            //      DataCriacao = DateTime.Now.ToShortDateString(),

            // }

            //};

            //return new JsonResult(retorno);



        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Get(int id)
        {

            //var noticias = _noticiaService.BuscarNoticias();

            //var dataBytes = System.IO.File.ReadAllBytes(noticias.ToString());

            var dataBytes = System.IO.File.ReadAllBytes(Path.Combine("Storage", "IMG_20230103_090026.jpg"));

            var retorno = new List<NoticiaOutput>()
            {
              new NoticiaOutput()
              {
                  Id = 1,
                  Titulo = "Primeiro Dia",
                  Descricao =   "Chegada do Material para inicio das obras",
                  Imagem = dataBytes,
                  DataHoraInclusao = DateTime.Now,

              }
            };

            return new JsonResult(retorno);

        }

        [HttpDelete("Remover/{id}")]
        public IActionResult ReomoverNoticia(int id)
        {
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult AtualizarNoticia(int id)
        {
            return Ok();
        }




    }
}

