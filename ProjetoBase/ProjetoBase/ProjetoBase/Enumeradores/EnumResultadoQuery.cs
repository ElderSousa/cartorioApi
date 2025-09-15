using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Enumeradores
{
    //Referente ao resultado da query
    public enum EnumResultadoQuery
    {
        SUCESSO = 1,
        DELETADO = 2,
        ERRO_GENERICO = 3,
        PK_DUPLICADO = 4,
        OBJETO_REFERENCIADO = 5,
        TENTANTIVA_DE_DELETE = 6
    }
}
