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

        public NoticiaController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
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

            return new JsonResult(noticias);

            //var dataBytes = System.IO.File.ReadAllBytes(noticias.ToString());



            //var dataBytes = System.IO.File.ReadAllBytes(Path.Combine("Storage", "IMG_20230103_090026.jpg"));

            //var dataBytes2 = System.IO.File.ReadAllBytes(Path.Combine("Storage", "IMG-20230109-WA0038.jpeg"));

            //var dataBytes3 = System.IO.File.ReadAllBytes(Path.Combine("Storage", "IMG_20230106_102104.jpg"));


            //var retorno = new List<NoticiaOutput>()
            //{
            //  new NoticiaOutput()
            //  {
            //      Id = 1,
            //      Titulo = "Primeiro Dia",
            //      Descricao =   "Chegada do Material para inicio das obras",
            //      Imagem = dataBytes,
            //      DataCriacao = DateTime.Now.ToShortDateString(),

            //  },
            //   new NoticiaOutput()
            //  {
            //      Id = 2,
            //      Titulo = "Segundo Dia",
            //      Descricao =   "Continuando a obra",
            //      Imagem = dataBytes2,
            //      DataCriacao = DateTime.Now.ToShortDateString(),

            //  },
            //    new NoticiaOutput()
            //  {
            //      Id = 3,
            //      Titulo = "Terceiro Dia",
            //      Descricao =   "Finalizando o Alicerce",
            //      Imagem = dataBytes3,
            //      DataCriacao = DateTime.Now.ToShortDateString(),

            //  }

            //};



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
                  DataCriacao = DateTime.Now.ToShortDateString(),

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

