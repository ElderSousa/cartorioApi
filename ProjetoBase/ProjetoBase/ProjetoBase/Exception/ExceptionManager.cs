using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.Exceptions
{
    public static class ExceptionManager
    {
        public static void tratarExcecao(Exception excecao)
        {
            if (excecao is NHibernate.Exceptions.GenericADOException)
            {
                if (excecao.InnerException.Message.Contains("violation of PRIMARY or UNIQUE KEY constraint"))
                {
                    MessageBox.Show("Não foi possivel salvar o objeto. Chave Primaria duplicada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na execução da Query. Verifique a conexão com o banco de dados\n" +excecao.InnerException?.Message + excecao.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ExcecaoManager.gravarExcecao(excecao);
                }
            }
            else if (excecao is NHibernate.NonUniqueObjectException)
            {
                if (excecao.Message.Contains("a different object with the same identifier value was already associated with the session"))
                {
                    MessageBox.Show("Não foi possivel salvar o objeto. Chave Primaria duplicada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (excecao is NullReferenceException)
            {
                MessageBox.Show("NullPointerException", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(excecao.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
