using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Ferramentas;

namespace ProjetoBase.Ferramentas
{
    public static class ExcecaoManager
    {
        public static void gravarExcecao(Exception e)
        {
            String[] linhas = new String[7];
            linhas[0] = "Hora: " + DateTime.Now.ToString();
            linhas[1] = "------------------------------------------------------------------------------";
            linhas[2] = "Exceção: " + e.Message;
            linhas[3] = "------------------------------------------------------------------------------";
            linhas[4] = "Inner Exceção: " + e.InnerException?.Message;
            linhas[5] = "------------------------------------------------------------------------------";
            linhas[6] = "StackTrace: " + e.StackTrace;

            if (execaoNaoIgnorada(e))
            {
                MessageBox.Show("Ocorreu um erro no sistema!", "Erro #100", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Directory.CreateDirectory("Exceções");
                System.IO.File.WriteAllLines("Exceções\\" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "-") + ".txt", linhas);
            }
        }

        public static Boolean execaoNaoIgnorada(Exception ex)
        {
            return true;

            //SOMENTE PARA ENCONTRAR FORMATOS BUGADOS
            if (ex.Message == "Erro genérico de GDI+." && ex.StackTrace?.Contains("GMapControl") == true)
            {
                return false;
            }
            return true;
        }

        public static void gravarExcecaoSemMensagem(Exception e)
        {
            String[] linhas = new String[7];
            linhas[0] = "Hora: " + DateTime.Now.ToString();
            linhas[1] = "------------------------------------------------------------------------------";
            linhas[2] = "Exceção: " + e.Message;
            linhas[3] = "------------------------------------------------------------------------------";
            linhas[4] = "Inner Exceção: " + e.InnerException?.Message;
            linhas[5] = "------------------------------------------------------------------------------";
            linhas[6] = "StackTrace: " + e.StackTrace;

            Directory.CreateDirectory("Exceções");
            System.IO.File.WriteAllLines("Exceções\\" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "-") + ".txt", linhas);
        }

        public static void gravarExcecaoSemMensagem(String msg)
        {
            String[] linhas = new String[7];
            linhas[0] = "Hora: " + DateTime.Now.ToString();
            linhas[1] = "------------------------------------------------------------------------------";
            linhas[2] = "Exceção: " + msg;
            linhas[3] = "------------------------------------------------------------------------------";
   
            Directory.CreateDirectory("Exceções");
            System.IO.File.WriteAllLines("Exceções\\" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "-") + ".txt", linhas);
        }

     
    }
}
