using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Interface;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.Config
{
    [Serializable]
    public class InstanciaServidor : Entidade, ComboBoxInterface
    {
        //------------Configs App Cliente---------------
        private String nome; //Nome da instancia
        private String servidor; //Caminho do servidor
        private String usuario; //Usuario
        private String senha; //Senha
        private Boolean ultimaInstanciaUsada; //Senha


        public String NomeInstancia
        {
            get { return nome; }
            set { nome = value; }
        }
        public String Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public Boolean UltimaInstanciaUsada
        {
            get { return ultimaInstanciaUsada; }
            set { ultimaInstanciaUsada = value; }
        }    
        //------------Configs App Cliente---------------

        public string Codigo
        {
            get
            {
                return nome;
            }
        }
        public string Descricao
        {
            get
            {
                return nome;
            }
        }

        public Entidade Proprio
        {
            get
            {
                return this;
            }
        }

        public ComboBoxInterface Objeto
        {
            get
            {
                return this;
            }
        }
    }
}
