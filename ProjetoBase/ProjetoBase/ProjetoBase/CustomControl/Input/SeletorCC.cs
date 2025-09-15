using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Exceptions;
using ProjetoBase.Formularios;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.CustomControls
{

    public partial class SeletorCC : UserControl, CustomControl
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private Entidade entidade;
        private String cod = null;
        private String desc = null;

        TipoSeletor? tipoSeletor;

        private Boolean obrigatorio = false;
        private Boolean somenteLeitura;
        private Boolean displaySomenteDescricao = false;
        private Boolean permitirEdicaoComSenha = false;
        private Boolean modoEscrita = false;

        public Boolean alteracaoNoTextboxRelacionado = true;
        private TextboxLabelCC textBoxRelacionado;
        private CheckBox checkBoxRelacionado;

        public delegate void Handler();
        public event Handler OnSelecaoAlterada;
        public event Handler OnAlterando;
        public event Handler OnRemovido;

      

        List<Entidade> listaPreSetada = null;
        String nomeListaPreSetada = null;

        ToolTip tooltip = new ToolTip();
        ListaSeletorModoEscrita lista = new ListaSeletorModoEscrita();

        public SeletorCC()
        {
            InitializeComponent();
            HideCaret(textBox.Handle);

            lista.Selecionado += Lista_Selecionado;
        }



        void esconderCursor(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HideCaret(this.Handle);
        }

        public void setValor(String codigo, String nome)
        {
            this.codigo = codigo;
            this.nome = nome;
            if (displaySomenteDescricao == false)
            {
                textBox.Text = codigo + " - " + nome?.TrimEnd(' ');
            }
            else
            {
                textBox.Text = nome?.TrimEnd(' ');
            }
            textBox.ForeColor = Color.Black;
            textBox.SelectionStart = textBox.Text.Length;

            textBox.Select(0, 0);
            textBox.ScrollToCaret();
            try
            {
                //////SendKeys.Send("^({HOME})"); DEIXA LENTO
            }
            catch
            {

            }
        }

        public void setEntidade(Entidade entidade)
        {
            this.entidade = entidade;
            if (entidade != null)
            {
                setValor(entidade.Codigo, entidade.Descricao);

                if (textBoxRelacionado != null && (alteracaoNoTextboxRelacionado == true || textBoxRelacionado.Texto == null))
                {
                    textBoxRelacionado.Texto = entidade.Descricao;
                }
                OnSelecaoAlterada?.Invoke();
                textBox.Select(0, 0);
                textBox.ScrollToCaret();
                try
                {
                    //////SendKeys.Send("^({HOME})"); DEIXA LENTO
                }
                catch
                {

                }
            }
        }

        public void setListaPreSetada(List<Entidade> listaPreSetada)
        {
            this.listaPreSetada = listaPreSetada;
        }

        public void setListaPreSetada(List<Entidade> listaPreSetada, String nomeListaPreSetada)
        {
            this.listaPreSetada = listaPreSetada;
            this.nomeListaPreSetada = nomeListaPreSetada;
        }

        //Limpa o Seletor
        public void Clear()
        {
            this.codigo = null;
            this.nome = null;
            textBox.ForeColor = Color.Gray;
            textBox.Text = "CLIQUE PARA SELECIONAR";

            if (textBoxRelacionado != null && alteracaoNoTextboxRelacionado == true)
            {
                textBoxRelacionado.Texto = null;
            }

            if (checkBoxRelacionado != null)
            {
                checkBoxRelacionado.Checked = false;
            }

            OnSelecaoAlterada?.Invoke();
        }

        //Limpa o Seletor sem disparar o evente de seleção alterada
        public void ClearOnly()
        {
            this.codigo = null;
            this.nome = null;
            textBox.ForeColor = Color.Gray;
            textBox.Text = "CLIQUE PARA SELECIONAR";
        }

        //----------------Atributos--------------------

        [Description("Tipo de seletor"), Category("Definição")]
        public TipoSeletor? Seletor
        {
            get { return tipoSeletor; }
            set
            {
                tipoSeletor = value;
            }
        }

        [Description("Texto do Label"), Category("Definição")]
        public String NomeDisplay
        {
            get { return lb_titulo.Text; }
            set { lb_titulo.Text = value; }
        }

        [Description("Define se o campo é obrigatorio"), Category("Definição")]
        public Boolean Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        [Description("Define se o campo é somente leitura"), Category("Definição")]
        public Boolean SomenteLeitura
        {
            get { return somenteLeitura; }
            set
            {
                somenteLeitura = value;
                configurarBotoes();
            }
        }

        [Description("Mostrar apenas a descrição"), Category("Definição")]
        public Boolean DisplaySomenteDescricao
        {
            get { return displaySomenteDescricao; }
            set
            {
                displaySomenteDescricao = value;
            }
        }
        [Description("Permitir edição com senha"), Category("Definição")]
        public Boolean PermitirEdicaoComSenha
        {
            get { return permitirEdicaoComSenha; }
            set
            {
                permitirEdicaoComSenha = value;
            }
        }

        [Description("Textbox externo para alteração"), Category("Definição")]
        public TextboxLabelCC TextBoxRelacionado
        {
            get { return textBoxRelacionado; }
            set
            {
                textBoxRelacionado = value;
            }
        }

        [Description("Checkbox externo para alteração"), Category("Definição")]
        public CheckBox CheckBoxRelacionado
        {
            get { return checkBoxRelacionado; }
            set
            {
                checkBoxRelacionado = value;
            }
        }

        [Description("Configura modo escrita"), Category("Definição")]
        public Boolean ModoEscrita
        {
            get { return modoEscrita; }
            set
            {
                modoEscrita = value; configurarModoEscrita();
            }
        }



        //----------------Atributos--------------------

        public String codigo
        {
            get
            {
                if (cod != "")
                {
                    return cod;
                }
                else
                {
                    return null;
                }
            }
            set { cod = value; }
        }

        public int? codigoInt
        {
            get
            {
                if (cod != null && cod != "")
                {
                    if (cod.All(char.IsDigit))
                    {
                        return Convert.ToInt32(cod);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set { cod = value.ToString(); }
        }

        public String nome
        {
            get
            {
                if (desc != "")
                {
                    return desc;
                }
                else
                {
                    return null;
                }
            }
            set { desc = value; }
        }

        Color corLabel = Color.Black;
        [Description("Cor do Label"), Category("Definição")]
        public Color CorLabel
        {
            get { return corLabel; }
            set { corLabel = value; lb_titulo.ForeColor = corLabel; }
        }

        Boolean CustomControl.Valido()
        {
            if (obrigatorio == true && codigo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SeletorCC_Load(object sender, EventArgs e)
        {
            configurarBotoes();
        }


        public String Acao = "";
        public String Resumo = "";

        public void setDadosLog(String Acao, String Resumo)
        {
            this.Acao = Acao;
            this.Resumo = Resumo;
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (nomeListaPreSetada == null)
                {
                    if (somenteLeitura == false)
                    {
                      
                            Seletor seletor = new Seletor(tipoSeletor.Value);
                            seletor.ListaPreSetada = listaPreSetada;
                            seletor.Selecionado += Seletor_Selecionado;
                        
                            seletor.carregarSeletor();
                            seletor.ShowDialog();
                            seletor.Dispose();
                        
                    }
                    else
                    {
                        if (permitirEdicaoComSenha)
                        {
                            ValidacaoAcao validacao = new ValidacaoAcao(Acao, Resumo);
                            if (validacao.acaoValidada())
                            {
                                Seletor seletor = new Seletor(tipoSeletor.Value);
                                seletor.ListaPreSetada = listaPreSetada;
                                seletor.Selecionado += Seletor_Selecionado;                    
                                seletor.carregarSeletor();
                                seletor.ShowDialog();
                                seletor.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    Seletor seletor = new Seletor(tipoSeletor.Value);
                    seletor.SetLista(new HashSet<Entidade>(listaPreSetada), nomeListaPreSetada);
                    seletor.Selecionado += Seletor_Selecionado;
                    seletor.ShowDialog();
                }
            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
            }
        }
        public void abrirFormularioCadastro(FormCC formulario)
        {
            try
            {
                formulario.OnSalvo += Formulario_OnSalvo;
                formulario.ShowDialog();

            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
            }
        }
        private void Formulario_OnSalvo(Entidade entidade)
        {
            setEntidade(entidade);
        }

        private void SeletorPessoa_Selecionado(Entidade entidade)
        {
        

        }

        private void SeletorPessoa_Selecionado(Boolean fisica)
        {
           
        }

        private void Seletor_Selecionado(Entidade entidade)
        {
            setValor(entidade?.Codigo, entidade?.Descricao);

            if (textBoxRelacionado != null && (alteracaoNoTextboxRelacionado == true || textBoxRelacionado.Texto == null))
            {
                textBoxRelacionado.Texto = entidade.Descricao;
            }

            OnSelecaoAlterada?.Invoke();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (somenteLeitura == false)
            {
                //*******Remover entidade adicionado dia 19/10/2021*******                                
                entidade = null;

                Clear();
                OnRemovido?.Invoke();
            }
            else if (permitirEdicaoComSenha)
            {
                ValidacaoAcao validacao = new ValidacaoAcao(Acao, Resumo);
                if (validacao.acaoValidada())
                {
                    //*******Remover entidade adicionado dia 19/10/2021*******                                
                    entidade = null;

                    Clear();
                    OnRemovido?.Invoke();
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            FormCC formularioEdit = null;

            switch (tipoSeletor)
            {
               
            }

            if (formularioEdit != null)
            {
                formularioEdit.OnSalvo += FormularioEdit_OnSalvo;
                formularioEdit.ShowDialog();
                formularioEdit.fechar(DialogResult.Yes);
                formularioEdit.Dispose();
            }
        }

        private void FormularioEdit_OnSalvo(Entidade entidade)
        {
            if (entidade != null)
            {
                setValor(entidade.Codigo, entidade.Descricao);
                if (textBoxRelacionado != null)
                {
                    textBoxRelacionado.Texto = entidade.Descricao;
                }
                OnAlterando?.Invoke();
            }
        }

        public void configurarBotoes()
        {
            //BOTÃO EDITAR
            Boolean edit = false;
            switch (tipoSeletor)
            {
                case TipoSeletor.Pessoa:
                    edit = true;
                    break;
                case TipoSeletor.PessoaFisica:
                    edit = true;
                    break;
                case TipoSeletor.PessoaJuridica:
                    edit = true;
                    break;
                case TipoSeletor.Juiz:
                    edit = true;
                    break;
                case TipoSeletor.Medico:
                    edit = true;
                    break;
                case TipoSeletor.Cemiterio:
                    edit = true;
                    break;
                case TipoSeletor.Celebrante:
                    edit = true;
                    break;
            }

            if (edit == false)
            {
                btn_editar.Visible = false;
                btn_remover.Location = btn_editar.Location;
            }


            //BOTÃO REMOVER
            if (somenteLeitura)
            {
                btn_remover.Visible = false;
                textBox.BackColor = SystemColors.Control;
            }
            else
            {
                btn_remover.Visible = true;
                textBox.BackColor = Color.White;
            }

            if (permitirEdicaoComSenha)
            {
                btn_remover.Visible = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            textBox.BackColor = Color.FromArgb(181, 183, 218);

            TextBox TB = (TextBox)sender;
            int VisibleTime = 20000;  //in milliseconds
            if (entidade != null)
            {
                tooltip.Show(textBox.Text, TB, 0, 20, VisibleTime);
            }
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;

            if (somenteLeitura)
            {
                textBox.BackColor = SystemColors.Control;
            }
            else
            {
                textBox.BackColor = Color.White;
            }
            tooltip.Hide(TB);

        }

        private void lb_titulo_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            HideCaret(textBox.Handle);
        }

        private void timerHideCaret_Tick(object sender, EventArgs e)
        {
            HideCaret(textBox.Handle);
        }

        private void SeletorCC_Load_1(object sender, EventArgs e)
        {

        }

        private void btn_editar_Enter(object sender, EventArgs e)
        {

        }


        private void btn_remover_Enter(object sender, EventArgs e)
        {
            if (mouseEmcimaDelete == false)
            {
                SendKeys.Send("{TAB}");
            }
        }

        //13-10-2021
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32)
            {
                textBox_Click(null, null);
            }
        }
        Boolean mouseEmcimaDelete = false;


        private void btn_remover_MouseEnter(object sender, EventArgs e)
        {
            mouseEmcimaDelete = true;

        }

        private void btn_remover_MouseLeave(object sender, EventArgs e)
        {
            mouseEmcimaDelete = false;
        }


        private void configurarModoEscrita()
        {
            if (modoEscrita)
            {
                textBox.ReadOnly = false;
                textBox.TextChanged += TextBox_TextChanged;
                textBox.GotFocus += TextBox_GotFocus;
                textBox.Click -= textBox_Click;
                textBox.Click += textBoxModoTexto_Click;
            }
        }

        private void textBoxModoTexto_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (textBox.Text == "CLIQUE PARA SELECIONAR")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Focused)
            {
                Parent.Controls.Add(lista);
                lista.Location = new Point(this.Location.X + textBox.Location.X, this.Location.Y + textBox.Location.Y + textBox.Height);
                lista.Size = new Size(textBox.Width, 140);
                lista.BringToFront();
                lista.Show();
                timerListaClose.Start();

                lista.carregarSeletor(textBox.Text, tipoSeletor);

                desativarBotaoEnterFormPai();
            }
        }



        public void desativarBotaoEnterFormPai()
        {
            FormCC form = (FormCC)getFormCCPai(this);
            form.botaoEnterAtivado = false;
        }
        public void reativarBotaoEnterFormPai()
        {
            FormCC form = (FormCC)getFormCCPai(this);
            form.botaoEnterAtivado = true;
        }

        public Control getFormCCPai(Control control)
        {
            if (control is FormCC)
            {
                return control;
            }

            var form = control.Parent;

            if (form is FormCC)
            {
                return form;
            }

            if (form?.Parent != null)
            {
                form = getFormCCPai(form.Parent);
            }

            return form;
        }

        private void Lista_Selecionado(Entidade entidade)
        {
            reativarBotaoEnterFormPai();
            setEntidade(entidade);

            fecharLista();
            this.Focus();
        }

        public void fecharLista()
        {
            lista.Hide();
            if (Parent.Controls.Contains(lista))
            {
                Parent.Controls.Remove(lista);
            }
            if (entidade == null)
            {
                textBox.Text = "CLIQUE PARA SELECIONAR";
            }
            else
            {
                setValor(entidade.Codigo, entidade.Descricao);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (modoEscrita)
                {
                    lista.focar();
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else if (keyData == Keys.Back)
            {
                if (modoEscrita)
                {
                    textBox.Text = "";
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox.Focused == false && lista.Focused == false && lista.focado() == false)
            {
                fecharLista();
                timerListaClose.Stop();
            }
        }
    }
}
