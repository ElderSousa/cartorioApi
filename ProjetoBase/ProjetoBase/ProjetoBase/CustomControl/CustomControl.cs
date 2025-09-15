using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.CustomControls
{
    public interface CustomControl
    {
        Boolean Valido();
        Boolean Obrigatorio { get; set; }
        String NomeDisplay { get; set; }
        Boolean SomenteLeitura{ get; set; }
        void Clear();
    }
}
