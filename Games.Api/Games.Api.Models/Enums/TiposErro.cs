using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Api.Models.Enums
{
    public enum TiposErro
    {
        [Description("Sucesso")]
        Success = 0,

        [Description("Erro Inesperado")]
        Inesperado = 9999,
        
        [Description("Erro Interno do Servidor")]
        InternalServerError = 500
    }
}
