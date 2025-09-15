using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.DataBase.Ferramentas
{
    public interface ICrud<T>
    {
        EnumResultadoQuery Salvar(T entidade);
        EnumResultadoQuery Excluir(T entidade);
        T ProcurarPorID(Object id);
        IList<T> getLista();
    }
}
