using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBase.DataBase.Dominio.Interface
{
    public interface Entidade
    {
        String Codigo { get; }
        String Descricao { get; }
        Entidade Proprio { get; }

    }

  
}
