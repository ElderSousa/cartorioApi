using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.Config
{
    [Serializable]
    public class Config
    {
        //------------Configs App Cliente---------------

        private List<InstanciaServidor> instancias; //Memoria maxima utilizavel

        private Decimal memoriaMaxima; //Memoria maxima utilizavel


        public List<InstanciaServidor> Instancias
        {
            get { return instancias; }
            set { instancias = value; }
        }

        public Decimal MemoriaMaxima
        {
            get { return memoriaMaxima; }
            set { memoriaMaxima = value; }
        }

    
        //------------Configs App Cliente---------------



        //------------Configs Servidor---------------
        private String anexos;
      
        private String versaoCliente;
        private String chaveCartorio;

        private String caminhoArquivosTecnoCart;

        public String Anexos
        {
            get { return anexos; }
            set { anexos = value; }
        }
       
        public String VersaoCliente
        {
            get { return versaoCliente; }
            set { versaoCliente = value; }
        }
        public String ChaveCartorio
        {
            get { return chaveCartorio; }
            set { chaveCartorio = value; }
        }
        public String CaminhoArquivosTecnoCart
        {
            get { return caminhoArquivosTecnoCart; }
            set { caminhoArquivosTecnoCart = value; }
        }
        //------------Configs Servidor---------------

    }
}
