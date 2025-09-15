using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBase.DataBase.Interface
{
    public interface ComboBoxInterface
    {
        String Descricao { get; }
        String Codigo { get; }
        ComboBoxInterface Objeto { get; }      
    }
}
