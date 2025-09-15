using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.Config;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Ferramentas;
using ProjetoBase.Formularios;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.CustomControls
{
    public partial class FormCC : Form
    {
        private String nome_janela;
        private Button botaoEnter;
        private Button botaoEscape;


        public delegate void SalvoHandler(Entidade entidade);
        public event SalvoHandler OnSalvo;

        public FormCC()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        [Description("Nome da janela exibido ao usuario"), Category("Janela")]
        public String Nome_janela
        {
            get { return nome_janela; }
            set { nome_janela = value; }
        }

        [Description("Botão para ser acionado ao pressionar a tecla Enter"), Category("Janela")]
        public Button BotaoEnter
        {
            get { return botaoEnter; }
            set { botaoEnter = value; }
        }

        [Description("Botão para ser acionado ao pressionar a tecla Escape"), Category("Janela")]
        public Button BotaoEscape
        {
            get { return botaoEscape; }
            set { botaoEscape = value; }
        }

 
        public void configurarFormulario()
        {
            this.Text = VersaoTecnoCart.Nome + " - " + Nome_janela; //Define nome do sistema visivel no cabeçalho do formulario e o nome da janela
        }

        private void MenuCC_Load(object sender, EventArgs e)
        {
            configurarFormulario();  // Inicia as configurações de definição do formulario

        }


        public Boolean botaoEnterAtivado = true;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (botaoEnter != null && botaoEnterAtivado)
                {
                    if (botaoEnter.Focused == false)
                    {
                        BotaoEnter.Focus();
                    }
                    else
                    {
                        botaoEnter.PerformClick();
                    }
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else if (keyData == Keys.Escape)
            {
                if (botaoEscape != null)
                {
                    if (botaoEscape.Focused == false)
                    {
                        botaoEscape.Focus();
                    }
                    else
                    {
                        botaoEscape.PerformClick();
                    }
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
        
            //else if (keyData == (Keys.Alt | Keys.F12))
            //{
            //    if (SessaoSistema.funcionario.Id == 1)
            //    {
            //        SeletorReflection SeletorReflection = new SeletorReflection();
            //        SeletorReflection.carregarForm(this);
            //        if(SeletorReflection.ShowDialog() == DialogResult.Yes)
            //        {
            //            fechar(DialogResult.Yes);
            //        }
            //        return true;
            //    }
            //    return base.ProcessCmdKey(ref msg, keyData);
            //}

            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void mostrarDialogoSucesso()
        {
            MessageBox.Show("Cadastro salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void mostrarMensagemResultado(Entidade seletorInterface, EnumResultadoQuery resultado)
        {
            mostrarMensagemResultado(resultado);
        }

        public void mostrarMensagemResultado(EnumResultadoQuery resultado)
        {
            //MessageBox.Show("Cadastro salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            mostrarMensagemResultadoSemFechar(resultado);
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            disposeComponentesForm();
            GC.SuppressFinalize(this);
            this.Dispose();
        }

        public void fechar(DialogResult? resultadoDialogo)
        {
            var x = disposeComponentesForm();
            if (resultadoDialogo != null)
            {
                this.DialogResult = (DialogResult)resultadoDialogo;
            }
            GC.SuppressFinalize(this);
            this.DestroyHandle();
            this.Dispose();
        }

        public void Disposar()
        {
            // GC.SuppressFinalize(this);
            this.DestroyHandle();
            this.Dispose();
        }

        public int disposeComponentesForm()
        {
            int x = 0;

            int total = Controls.Count;
            for (int y = total - 1; y > 0; y--)
            {
                var controle = Controls[y];
                x += disposeComponentes((Control)controle);
            }

            GC.WaitForFullGCComplete();
            GC.Collect();
            return x;
        }



        public int disposeComponentes(Control controlePai)
        {
            int x = 0;
            if (controlePai is TabControl)
            {
                TabControl TabControl = (TabControl)controlePai;
                foreach (TabPage pagina in TabControl.TabPages)
                {
                    x += disposeComponentes(pagina);
                }
            }

            if (controlePai.Controls != null)
            {
                int total = controlePai.Controls.Count;
                for (int y = total - 1; y > 0; y--)
                {
                    Control controleListado = controlePai.Controls[y];

                    if (controleListado.Controls?.Count > 0)
                    {
                        x += disposeComponentes(controleListado);
                    }

                    if (controleListado is IDisposable)
                    {
                        GC.SuppressFinalize(controleListado);
                        controleListado.Dispose();
                        x += 1;
                    }
                }
            }
            if (controlePai is IDisposable)
            {
                GC.SuppressFinalize(controlePai);
                controlePai.Dispose();
                x += 1;
            }

            return x;
        }



        public void mostrarMensagemResultadoSemFechar(EnumResultadoQuery resultado)
        {
            switch (resultado)
            {
                case EnumResultadoQuery.SUCESSO:
                    MessageBox.Show("Cadastro salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case EnumResultadoQuery.DELETADO:
                    MessageBox.Show("Cadastro deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case EnumResultadoQuery.OBJETO_REFERENCIADO:
                    MessageBox.Show("Não foi possivel deletar este registro! Existe uma referência a ele ativa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumResultadoQuery.PK_DUPLICADO:
                    MessageBox.Show("Não foi possivel salvar este registro! O Id utilizado já existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumResultadoQuery.ERRO_GENERICO:
                    MessageBox.Show("Não foi possivel realizar esta ação! Encerre o sistema e inicie novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumResultadoQuery.TENTANTIVA_DE_DELETE:
                    MessageBox.Show("Não foi possivel realizar esta ação, tentativa de exclusão de dados! Tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }


        public void cancelarEdicao(Object objetoParaEvict)
        {
            try
            {
                if (objetoParaEvict != null)
                {
                    SessionFactory.UnflushedSession().Evict(objetoParaEvict);
                }
            }
            catch
            {

            }
            this.DialogResult = DialogResult.No;
            disposeComponentesForm();
            GC.SuppressFinalize(this);
            this.Dispose();
        }

        public Boolean DispararEventoSalvo(Entidade entidade)
        {
            if (OnSalvo != null)
            {
                OnSalvo?.Invoke(entidade);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormCC
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCC_Load);
            this.ResumeLayout(false);

        }

        private void FormCC_Load(object sender, EventArgs e)
        {

        }

        //public void configurarTabOrder()
        //{
        //    var controles = new List<Control>();

        //    foreach (Control control in Controls)
        //    {
        //        controles.Add(control);
        //    }
        //    setTabOrder(controles);

        //}

        //int tabCount = 0;
        //public void setTabOrder(List<Control> controles)
        //{
        //    foreach (Control control in controles.OrderBy(x => x.Location.Y))
        //    {
        //        control.TabIndex = tabCount;
        //        tabCount += 1;
        //        if (control.Controls?.Count > 0)
        //        {
        //            var controlesFilhos = new List<Control>();
        //            foreach (Control controleFilho in control.Controls)
        //            {
        //                if (controleFilho is TextboxLabelCC == false && controleFilho is SeletorBooleanoCC == false && controleFilho is SeletorCC == false)
        //                {
        //                    controlesFilhos.Add(controleFilho);
        //                }
        //            }
        //            setTabOrder(controlesFilhos);
        //        }
        //    }
        //}

        //public PessoaFisicaPersistida persistirParte(PessoaFisica parteLegado)
        //{
        //    if (parteLegado != null)
        //    {
        //        using (PessoaFisicaPersistidaCadastro PessoaFisicaPersistidaCadastro = new PessoaFisicaPersistidaCadastro(parteLegado))
        //        {
        //            return (PessoaFisicaPersistida)PessoaFisicaPersistidaCadastro.Salvar();
        //        }
        //    }
        //    return null;
        //}



    }

    public class FormularioAbertoDTO
    {
        public virtual int Id { get; set; }
        public virtual String NomeForm { get; set; }
        public virtual String IdEntidade { get; set; }
        public virtual int FuncionarioId { get; set; }
        public virtual DateTime UltimoTick { get; set; }
        public virtual String NomeFuncionario { get; set; }
    }
}
