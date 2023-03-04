using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Core.ViewModel
{
    public class NoticiaOutput
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte[]? Imagem { get; set; }
        public string? DataCriacao { get; set; }
      
    }
}
