using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.CustomControls.Validacao;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.Formularios
{
    public partial class CargoCadastro : FormCC
    {
        Cargo cargo = null;

        public CargoCadastro(Cargo cargo)
        {
            InitializeComponent();
            this.cargo = cargo;
            carregarCargo();
        }

        //Carrega dados de um Cargo se ja cadastrado
        public void carregarCargo()
        {
            if (cargo != null)
            {
                txt_codigo.Texto = cargo.Codigo;
                txt_nome.Texto = cargo.Nome;
                btn_cadastrar.TipoBotao = TipoBotao.Salvar;
            }
        }

        private void PessoaNovo_Load(object sender, EventArgs e)
        {

        }

        //Cadastrar ou salvar cargo
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            RetornoValidacaoDados retorno = ValidacaoDadosObrigatorios.validarPanelObrigatorio(panel_cargo);
            if (retorno.Valido)
            {
                cargo = new Cargo();
                cargo.Nome = txt_nome.Texto;

                EnumResultadoQuery retornoQuery = Repositorios.Cargo.Salvar(cargo);
                DispararEventoSalvo(cargo);
                mostrarMensagemResultado(retornoQuery);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicao(cargo);
        }

        private void btn_add_tipo_ato_Click(object sender, EventArgs e)
        {

        }
    }
}
