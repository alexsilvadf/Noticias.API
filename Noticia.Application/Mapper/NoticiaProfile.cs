using AutoMapper;
using Noticia.Core.Entidade;
using Noticia.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticia.Application.Mapper
{
    public class NoticiaProfile: Profile
    {
        public NoticiaProfile()
        {
            //CreateMap<Noticiario, NoticiaOutput>(MemberList.None)
            //    .ForMember(s => s.Imagem, opt => opt.MapFrom(src => src.Imagem));

            CreateMap<Noticiario, NoticiaOutput>(MemberList.None);
               

        }
    }
}
