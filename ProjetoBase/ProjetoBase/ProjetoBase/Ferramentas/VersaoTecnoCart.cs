using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Config
{
    static class VersaoTecnoCart
    {
        private static String nome = "TecnoCart"; //Nome do sistema TecnoCart
        private static String versao = "1.0.0"; //Versão do sistema TecnoCart
        private static DateTime data = new DateTime(2015, 10, 21); //Data da versão
        private static String[] novasFuncionalidades; // Funcionalidades adicionadas nesta versão
        private static String[] correcoes; //Correções realizadas nesta versão


        public static String Nome
        {
            get { return VersaoTecnoCart.nome; }
            set { VersaoTecnoCart.nome = value; }
        }

        public static String Versao
        {
            get { return VersaoTecnoCart.versao; }
            set { VersaoTecnoCart.versao = value; }
        }
 
        public static DateTime Data
        {
            get { return VersaoTecnoCart.data; }
            set { VersaoTecnoCart.data = value; }
        }


        public static String[] NovasFuncionalidades
        {
            get { return novasFuncionalidades; }
            set { novasFuncionalidades = value; }
        }


        public static String[] Correcoes
        {
            get { return correcoes; }
            set { correcoes = value; }
        }
    }
}
