using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Core.ViewModel
{
    public class NoticiaInput
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IFormFile? Imagem { get; set; }
        public string? CaminhoImagem { get; set; }
    }
}
