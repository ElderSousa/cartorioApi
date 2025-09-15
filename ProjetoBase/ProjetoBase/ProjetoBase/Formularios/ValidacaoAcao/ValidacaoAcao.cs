using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.Formularios.Ferramentas
{
    public partial class ValidacaoAcao : FormCC
    {
        public Funcionario funcionarioResponsavel = null;

        Boolean salvarLog = false;
        String acao;
        String resumo;
        EnumAutorizacaoAcao? autorizacao;

        public Boolean permitirAutoAutorizacao = true;

        public ValidacaoAcao()
        {
            InitializeComponent();

        }

        public ValidacaoAcao(String acao, String resumo)
        {
            InitializeComponent();
            this.salvarLog = true;
            this.acao = acao;
            this.resumo = resumo;
        }


        public ValidacaoAcao(String acao, String resumo, EnumAutorizacaoAcao autorizacao)
        {
            InitializeComponent();
            this.salvarLog = true;
            this.acao = acao;
            this.resumo = resumo;
            this.autorizacao = autorizacao;
        }

        public ValidacaoAcao(String acao, String resumo, Boolean permitirAutoAutorizacao)
        {
            InitializeComponent();
            this.salvarLog = true;
            this.acao = acao;
            this.resumo = resumo;
            this.permitirAutoAutorizacao = permitirAutoAutorizacao;
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        public Boolean acaoValidada()
        {
            Boolean validado = false;

            if (autorizacao != null)
            {
                var qtd = SessionFactory.UnflushedSession().CreateSQLQuery($"select count(*) from autorizacao_acao_funcionario where funcionario_id = {SessaoSistema.funcionario.Id} and EnumAutorizacaoAcao = {Convert.ToInt32(autorizacao)}").UniqueResult<int>();
                if (qtd == 1)
                {
                    validado = true;
                    funcionarioResponsavel = SessaoSistema.funcionario;
                    return validado;
                }
            }

            if (SessaoSistema.funcionario?.usuario?.Administrador == true && permitirAutoAutorizacao)
            {
                if (MessageBox.Show("Deseja autorizar esta ação com o usuario: " + SessaoSistema.funcionario.Nome + "?", "Autorizar Ação?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    funcionarioResponsavel = SessaoSistema.funcionario;
                    fechar(DialogResult.Yes);
                    validado = true;
                }
            }
            else
            {
                var nivelDinamico = SessionFactory.UnflushedSession().QueryOver<NivelDeAcessoDinamico>().Where(x => x.Acao == acao).TransformUsing(Transformers.DistinctRootEntity).SingleOrDefault();

                if (nivelDinamico?.Funcionarios?.Where(x => x.Id == SessaoSistema.funcionario.Id).Count() > 0)
                {
                    if (MessageBox.Show("Deseja autorizar esta ação com o usuario: " + SessaoSistema.funcionario.Nome + "?", "Autorizar Ação?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        funcionarioResponsavel = SessaoSistema.funcionario;
                        fechar(DialogResult.Yes);
                        validado = true;
                    }
                }
            }

            if (validado == false)
            {

                DialogResult resultado = this.ShowDialog();
                if (resultado == DialogResult.Yes)
                {
                    validado = true;
                }
            }
            return validado;

        }

        Boolean modoSimples = false;
        internal void ModoSimples()
        {
            modoSimples = true;
        }

        public Funcionario FuncionariaResponsavel()
        {
            DialogResult resultado = this.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                return funcionarioResponsavel;
            }
            else
            {
                return null;
            }
        }


        private void ValidacaoAcao_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Usuario usuario = getUsuario();
            var nivelDinamico = SessionFactory.UnflushedSession().QueryOver<NivelDeAcessoDinamico>().Where(x => x.Acao == acao).TransformUsing(Transformers.DistinctRootEntity).SingleOrDefault();

            if (usuario != null)
            {
                if (usuario.Administrador)
                {
                    funcionarioResponsavel = SessionFactory.UnflushedSession().QueryOver<Funcionario>().Where(x => x.usuario == usuario).TransformUsing(Transformers.DistinctRootEntity).SingleOrDefault();
                    fechar(DialogResult.Yes);
                }
                else if (SessionFactory.UnflushedSession().CreateSQLQuery($"select count(*) from autorizacao_acao_funcionario where funcionario_id = {SessaoSistema.funcionario.Id} and EnumAutorizacaoAcao = {Convert.ToInt32(autorizacao)}").UniqueResult<int>() == 1)
                {
                    funcionarioResponsavel = SessionFactory.UnflushedSession().QueryOver<Funcionario>().Where(x => x.usuario == usuario).TransformUsing(Transformers.DistinctRootEntity).SingleOrDefault();
                    fechar(DialogResult.Yes);
                }
                else if (nivelDinamico?.Funcionarios?.Where(x => x.Id == SessaoSistema.funcionario.Id).Count() > 0)
                {
                    if (MessageBox.Show("Deseja autorizar esta ação com o usuario: " + SessaoSistema.funcionario.Nome + "?", "Autorizar Ação?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        funcionarioResponsavel = SessaoSistema.funcionario;
                        fechar(DialogResult.Yes);
                    }
                }
                else
                {
                    MessageBox.Show("Este usuario não tem permissão para realizar esta ação.", "Contate um Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fechar(DialogResult.No);
                }
            }
            else
            {
                MessageBox.Show("Login ou senha invalidos!", "Tente novamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        public Usuario getUsuario()
        {
            Usuario usuario = null;

            IList<Usuario> listaUsuario = SessionFactory.UnflushedSession().QueryOver<Usuario>()
                 .Where(
               Restrictions.On<Usuario>(c => c.Login).IsLike(txt_login.Texto) &&
               Restrictions.On<Usuario>(c => c.Senha).IsLike(txt_senha.Texto)
               )
                .TransformUsing(Transformers.RootEntity)
                .Take(1)
                .List<Usuario>();


            if (listaUsuario.Count == 1)
            {
                usuario = listaUsuario[0];
            }

            return usuario;
        }

        private void btn_configurar_autorizacao_Click(object sender, EventArgs e)
        {

        }

        private void NivelAcessoDinamicoCadastro_OnSalvo(Entidade entidade)
        {

        }

        private void ValidacaoAcao_Shown(object sender, EventArgs e)
        {
            var nivelAcesso = SessionFactory.UnflushedSession().QueryOver<NivelDeAcessoDinamico>().TransformUsing(Transformers.DistinctRootEntity).Where(x => x.Acao == acao).SingleOrDefault();

            if (nivelAcesso == null && modoSimples == false)
            {
                this.Size = new Size(224, 252);
            }
        }
    }


    public class AutorizacaoAcao : Entidade
    {
        public AutorizacaoAcao(EnumAutorizacaoAcao codigo, String nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }
        public EnumAutorizacaoAcao codigo;
        public String nome;

        public string Codigo
        {
            get
            {
                return Convert.ToInt32(codigo).ToString();
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
    }

    public enum EnumAutorizacaoAcao
    {
        GERAR_CNM = 1,
        ABERTURA_MATRICULA = 2,
        DELETAR_CARTAO_AUTOGRAFO = 3,
        CONVERTER_DOI = 4,
        ALTERAR_GERACAO_PRENOTACAO_AUTOMATICA = 5,
        ADICIONAR_PARTE_MANUALMENTE_RTD_RPJ = 6,
        VER_ALERTA_PAGAMENTOS = 7,
        GERAR_TEXTO_PRENOTACOES_SUBSISTENTES = 8,
        SOMENTE_VISUALIZAR_CONTAS_A_RECEBER = 9,
        SOMENTE_VISUALIZAR_COMPENSACAO_CONTAS = 10,
        LIBERAR_EDICAO_MODELO_DOCUMENTO = 11,
        ENCERRAR_MATRICULA = 12,
        CADASTRAR_PESSOA_SEM_CPF = 13,
        CADASTRAR_PESSOA_SEM_CNPJ = 14,
        CADASTRAR_PESSOA_SEM_ENDERECO = 15,
        EMITIR_NFE = 16,
        SALVAR_REGISTRO_CIVIL = 17,
        SANGRIA_DE_CAIXA = 18,
        PUBLICAR_EDITAL_COM_DATA_ANTERIOR = 19
    }

    public static class AutorizacaoAcaoManager
    {
        public static List<AutorizacaoAcao> lista = new List<AutorizacaoAcao>()
        {
            new AutorizacaoAcao(EnumAutorizacaoAcao.GERAR_CNM, "Registro de imovel -> Gerar CNM"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.ABERTURA_MATRICULA, "Registro de imovel -> Abertura de Matricula"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.DELETAR_CARTAO_AUTOGRAFO, "Deletar cartão de autografo"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.CONVERTER_DOI, "Converter DOI Para DOI Web"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.ALTERAR_GERACAO_PRENOTACAO_AUTOMATICA, "Alterar geração automatica de prenotação"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.ADICIONAR_PARTE_MANUALMENTE_RTD_RPJ, "Adicionar parte manualmente em RTD/RPJ"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.VER_ALERTA_PAGAMENTOS, "Receber alerta de pagamentos"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.GERAR_TEXTO_PRENOTACOES_SUBSISTENTES, "Gerar texto de prenotações subsistentes"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.SOMENTE_VISUALIZAR_CONTAS_A_RECEBER, "Somente visualizar menu de contas a receber"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.SOMENTE_VISUALIZAR_COMPENSACAO_CONTAS, "Somente visualizar compensação de contas"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.LIBERAR_EDICAO_MODELO_DOCUMENTO, "Liberar edição de texto nos modelos de documento (Notas/RI)"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.ENCERRAR_MATRICULA, "Encerrar matricula (Registro de Imovel)"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.CADASTRAR_PESSOA_SEM_CPF, "Cadastrar pessoa sem cpf (000.000.000-00)"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.CADASTRAR_PESSOA_SEM_CNPJ, "Cadastrar pessoa sem cnpj (00.000.000/0000-00)"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.CADASTRAR_PESSOA_SEM_ENDERECO, "Cadastrar pessoa sem endereço"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.EMITIR_NFE, "Emitir NFE"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.SALVAR_REGISTRO_CIVIL, "Realizar alterações em registro civil já finalizado."),
            new AutorizacaoAcao(EnumAutorizacaoAcao.SANGRIA_DE_CAIXA, "Sangria de Caixa"),
            new AutorizacaoAcao(EnumAutorizacaoAcao.PUBLICAR_EDITAL_COM_DATA_ANTERIOR, "Publicar edital de protesto com data anteior ao dia atual"),
        };
    }
}
