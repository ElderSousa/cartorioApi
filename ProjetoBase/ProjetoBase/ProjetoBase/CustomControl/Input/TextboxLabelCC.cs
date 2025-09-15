using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.CustomControls.Input;
using ProjetoBase.CustomControls.Validacao;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.CustomControls
{
    public class TextboxLabelCC : Panel, CustomControl
    {
        private String nomeDisplay;
        private Boolean obrigatorio = false;
        private Boolean somenteLeitura = false;
        private Boolean senha = false;
        private Boolean permitirValorNegativo = false;
        private Boolean permitirAlterarSomenteLeitura = false;
        private Boolean pedirSenhaAlterarSomenteLeitura = true;
        private int tamanhoMaximo = 255;


        private CharacterCasing caixa = CharacterCasing.Upper;

        private TipoTextBox tipoTextBox;
        EnumTamanhoTextBox? tamanhoTextBox;

        public Label label = new Label();
        public TextBox textBox = new TextBox();
        public MaskedTextBox maskedTextBox = new MaskedTextBox();

        public Boolean edicaoLiberada = false;


        public delegate void EdicaoLiberadaHandler();
        public event EdicaoLiberadaHandler OnEdicaoLiberada;

        public delegate void CliqueDuploHandler();
        public event CliqueDuploHandler OnCliqueDuplo;

        public Boolean linhaMultipla = false;

        public Boolean ignorado = false;

        public String Acao = "";
        public String Resumo = "";

        public void setDadosLog(String Acao, String Resumo)
        {
            this.Acao = Acao;
            this.Resumo = Resumo;
        }

        public TextboxLabelCC()
        {
            //Tamanho do Controle
            this.Size = new System.Drawing.Size(150, 35);

            //Adiciona Label
            label.Text = "Titulo";
            this.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font("Arial", 8, FontStyle.Bold);
            label.Dock = DockStyle.Top; //Alterado em 19/06/2024, antes era TOP (Voltei pra Top pois desajustou outro menu)

            //Ajusta posição dos TextBox
            textBox.Dock = DockStyle.Bottom;
            maskedTextBox.Dock = DockStyle.Bottom;


            textBox.ShortcutsEnabled = true;
            textBox.ReadOnly = true;
            maskedTextBox.ReadOnly = true;

            maskedTextBox.Enter += MaskedTextBox_Enter;

            textBox.Leave += textBox_Leave;
            maskedTextBox.Leave += maskedtextBox_Leave;

            textBox.KeyPress += textBox_KeyPress;
            maskedTextBox.KeyPress += MaskedTextBox_KeyPress;

            textBox.MouseDoubleClick += TextBox_MouseDoubleClick;
            maskedTextBox.MouseDoubleClick += TextBox_MouseDoubleClick;

            textBox.CharacterCasing = CharacterCasing.Upper;

            //cbIgnorado.Width = 30;
            //cbIgnorado.Height = 15;
            //cbIgnorado.Appearance = Appearance.Button;
            //cbIgnorado.Text = "IGN";
            //cbIgnorado.AutoSize = false;
            //cbIgnorado.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Bold);
            //cbIgnorado.Location = new Point(Width - cbIgnorado.Width, 0);
            //cbIgnorado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //cbIgnorado.Visible = checkBoxIgnorado;
            //this.Controls.Add(cbIgnorado);
        }

        private void TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnCliqueDuplo?.Invoke();

            if (somenteLeitura && permitirAlterarSomenteLeitura && edicaoLiberada == false)
            {
                if (Texto != null && pedirSenhaAlterarSomenteLeitura)
                {
                    ValidacaoAcao validacao = new ValidacaoAcao(Acao, Resumo);
                    if (validacao.acaoValidada())
                    {
                        edicaoLiberada = true;
                        textBox.ReadOnly = false;
                        maskedTextBox.ReadOnly = false;
                        OnEdicaoLiberada?.Invoke();
                    }
                }
                else
                {
                    edicaoLiberada = true;
                    textBox.ReadOnly = false;
                    maskedTextBox.ReadOnly = false;
                    OnEdicaoLiberada?.Invoke();
                }
            }
        }

   

        private void MaskedTextBox_Enter(object sender, EventArgs e)
        {
            switch (tipoTextBox)
            {
                case TipoTextBox.SeloFisico:
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        maskedTextBox.Select(0, 0);
                    });
                    break;
                case TipoTextBox.PapelMoeda:
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        maskedTextBox.Select(0, 0);
                    });
                    break;
            }
        }

        [Description("Nome a ser exibido ao usuario"), Category("Definição")]
        public String NomeDisplay
        {
            get { return nomeDisplay; }
            set { nomeDisplay = value; label.Text = nomeDisplay; }
        }

        [Description("Define se o campo é obrigatorio"), Category("Definição")]
        public Boolean Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        [Description("Define se o campo é multiLinha"), Category("Definição")]
        public Boolean MultiLinha
        {
            get { return linhaMultipla; }
            set { linhaMultipla = value; configurarLinhaMultipla(); }
        }


        private void configurarLinhaMultipla()
        {
            if (linhaMultipla)
            {
                Point posicao = textBox.Location;
                Size tamanho = textBox.Size;

                textBox.Multiline = true;
                textBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);

                textBox.Location = posicao;
                textBox.Size = tamanho;
            }
            else
            {
                textBox.Multiline = false;
            }
        }

        [Description("Define se o campo é somente leitura"), Category("Definição")]
        public Boolean SomenteLeitura
        {
            get { return somenteLeitura; }
            set
            {
                somenteLeitura = value;
                if (somenteLeitura)
                {
                    textBox.ReadOnly = true; maskedTextBox.ReadOnly = true;
                }
                else
                {
                    textBox.ReadOnly = false; maskedTextBox.ReadOnly = false;
                }
            }
        }

        [Description("Define se o campo é uma senha"), Category("Definição")]
        public Boolean Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                if (senha)
                {
                    textBox.UseSystemPasswordChar = true; maskedTextBox.UseSystemPasswordChar = true;
                }
                else
                {
                    textBox.UseSystemPasswordChar = false; maskedTextBox.UseSystemPasswordChar = false;
                }
            }
        }
        [Description("Define o tamanho maximo do texto"), Category("Definição")]
        public int TamanhoMaximo
        {
            get { return tamanhoMaximo; }
            set
            {
                tamanhoMaximo = value;
                textBox.MaxLength = tamanhoMaximo;
            }
        }

        [Description("Texto do textBox"), Category("Definição")]
        public String Texto
        {
            get
            {
                if (this.Controls.Contains(textBox))
                {
                    if (textBox.Text != "")
                    {
                        return textBox.Text; //Retorna texto do TextBox Normal
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    maskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (maskedTextBox.Text != "")
                    {
                        maskedTextBox.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        return maskedTextBox.Text; //Retorna texto do MaskedTextBox
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            set
            {
                if (this.Controls.Contains(textBox))
                {
                    textBox.Text = value;
                }
                else
                {
                    maskedTextBox.Text = value;
                }
            }
        }

        public String TextoLimitadoTamanho
        {
            set
            {
                if (this.Controls.Contains(textBox))
                {
                    String valor = value;
                    if (valor?.Length > tamanhoMaximo)
                    {
                        valor = valor.Remove(tamanhoMaximo);
                    }
                    textBox.Text = valor;
                }
                else
                {
                    maskedTextBox.Text = value;
                }
            }
        }

        [Description("Texto do textBox"), Category("Definição")]
        public String TextoValidado
        {
            get
            {
                if (this.Controls.Contains(textBox))
                {
                    if (textBox.Text.TrimEnd(' ') == "")
                    {
                        return null; //Retorna texto do TextBox Normal Nulo
                    }
                    else
                    {
                        return textBox.Text; //Retorna texto do TextBox Normal
                    }
                }
                else
                {
                    if (maskedTextBox.Text.TrimEnd(' ') == "")
                    {
                        return null; //Retorna texto do MaskedTextBox Normal Nulo
                    }
                    else
                    {
                        return maskedTextBox.Text; //Retorna texto do MaskedTextBox Normal
                    }
                }
            }
        }

        [Description("Tipo de TextBox"), Category("Definição")]
        public TipoTextBox TipoTextBox
        {
            get { return tipoTextBox; }
            set { tipoTextBox = value; configurarTextBox(); }
        }

        Color corLabel = Color.Black;
        [Description("Cor do Label"), Category("Definição")]
        public Color CorLabel
        {
            get { return corLabel; }
            set { corLabel = value; label.ForeColor = corLabel; }
        }


        [Description("Tamanho do TextBox"), Category("Definição")]
        public EnumTamanhoTextBox? TamanhoTextBox
        {
            get { return tamanhoTextBox; }
            set { tamanhoTextBox = value; configurarTextBox(); }
        }

        [Description("Caixa"), Category("Definição")]
        public CharacterCasing Caixa
        {
            get { return caixa; }
            set
            {
                caixa = value;
                textBox.CharacterCasing = caixa;
            }
        }


        [Description("Permitir Negativo"), Category("Definição")]
        public Boolean PermitirValorNegativo
        {
            get { return permitirValorNegativo; }
            set { permitirValorNegativo = value; }
        }

        [Description("Define se o campo pode ser alterado quando somente leitura"), Category("Definição")]
        public Boolean PermitirAlterarSomenteLeitura
        {
            get { return permitirAlterarSomenteLeitura; }
            set { permitirAlterarSomenteLeitura = value; }
        }

        [Description("Define se o campo precisa de senha para ser alterado quando somente leitura"), Category("Definição")]
        public Boolean PedirSenhaAlterarSomenteLeitura
        {
            get { return pedirSenhaAlterarSomenteLeitura; }
            set { pedirSenhaAlterarSomenteLeitura = value; }
        }

        //Configura Tipo e mascaras de TextBox e MaskedTextBox
        public void configurarTextBox()
        {
            switch (tipoTextBox)
            {
                case TipoTextBox.Texto:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    break;
                case TipoTextBox.Data:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00/00/0000";
                    break;
                case TipoTextBox.DataExtenso:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00/00/0000";
                    break;
                case TipoTextBox.DataExtensoCompleto:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00/00/0000";
                    break;
                case TipoTextBox.Hora:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00:00:00";
                    break;
                case TipoTextBox.DataHora:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00/00/0000 00:00:00";
                    break;
                case TipoTextBox.DataHoraSimples:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00/00/0000 00:00";
                    break;
                case TipoTextBox.DDD:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "(000)";
                    break;
                case TipoTextBox.Telefone:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00000-0000";
                    break;
                case TipoTextBox.Cpf:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "000,000,000-00";
                    break;
                case TipoTextBox.Cnpj:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00,000,000/0000-00";
                    break;
                case TipoTextBox.Cep:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00,000-000";
                    break;
                case TipoTextBox.Inteiro:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    break;
                case TipoTextBox.Real:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "+R$ 0,00";
                    break;
                case TipoTextBox.Decimal:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "0,000";
                    break;
                case TipoTextBox.Decimal5Casas:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "0,00000";
                    break;
                case TipoTextBox.Decimal2Casas:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "0,00";
                    break;
                case TipoTextBox.DecimalLivre:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "";
                    break;
                case TipoTextBox.NumeroEDigito:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    textBox.Text = "";
                    break;
                case TipoTextBox.Area:
                    this.Controls.Add(textBox);
                    this.Controls.Remove(maskedTextBox);
                    Caixa = CharacterCasing.Normal;
                    textBox.Text = "0,00 m²";
                    break;
                case TipoTextBox.Coordenada:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "00,000000";
                    break;
                case TipoTextBox.Placa:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "AAA-AAAA";
                    break;
                case TipoTextBox.SeloFisico:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "LL000000";
                    maskedTextBox.PromptChar = ' ';
                    break;
                case TipoTextBox.PapelMoeda:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "LL000000000";
                    maskedTextBox.PromptChar = ' ';
                    break;
                case TipoTextBox.CodigoValidacaoCpFederal:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "AAAA,AAAA,AAAA,AAAA";
                    break;
                case TipoTextBox.CodigoValidacaoCpEstadual:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "000000000000";
                    break;
                case TipoTextBox.CodigoValidacaoCpMunicipal:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "0000000000";
                    break;
                case TipoTextBox.CodigoValidacaoCpTrabalhista:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "000000000/0000";
                    break;
                case TipoTextBox.CodigoValidacaoCpIndisponibilidade:
                    this.Controls.Add(maskedTextBox);
                    this.Controls.Remove(textBox);
                    maskedTextBox.Mask = "AAAA,AAAA,AAAA,AAAA,AAAA,AAAA,AAAA,AAAA,AAAA,AAAA";
                    break;
            }

            switch (tamanhoTextBox)
            {
                case EnumTamanhoTextBox.Pequeno:
                    label.Font = new Font("Arial", 8, FontStyle.Bold);
                    textBox.Font = new Font("Arial", 8, FontStyle.Regular);
                    maskedTextBox.Font = new Font("Arial", 8, FontStyle.Regular);
                    break;
                case EnumTamanhoTextBox.Medio:
                    label.Font = new Font("Arial", 11, FontStyle.Bold);
                    textBox.Font = new Font("Arial", 18, FontStyle.Regular);
                    maskedTextBox.Font = new Font("Arial", 18, FontStyle.Regular);
                    break;
                case EnumTamanhoTextBox.Grande:
                    label.Font = new Font("Arial", 14, FontStyle.Bold);
                    textBox.Font = new Font("Arial", 25, FontStyle.Regular);
                    maskedTextBox.Font = new Font("Arial", 25, FontStyle.Regular);
                    break;
            }
        }

        //Limpa o TextBox
        public void Clear()
        {

            if (tipoTextBox == TipoTextBox.Real || tipoTextBox == TipoTextBox.Decimal || tipoTextBox == TipoTextBox.Decimal5Casas || tipoTextBox == TipoTextBox.Decimal2Casas)
            {
                setDecimal(0);
            }
            else
            {
                this.textBox.Text = null;
                this.maskedTextBox.Text = null;
            }
        }

        //Evento On Leave Focus do TextBox
        private void textBox_Leave(object sender, EventArgs e)
        {
            Boolean valido = ValidacaoTextBox.valido(textBox.Text, tipoTextBox);
            String valor = ValidacaoTextBox.getText(textBox.Text);
            if ((valor == "" || valor == null) && obrigatorio == true)
            {
                setAvisoLabel("Campo Obrigatório");
            }
            else if ((valor != "" && valor != null) && valido == false)
            {
                setAvisoLabel("Campo Invalido");
            }
            else
            {
                removeAvisoLabel();
            }
        }

        //Evento On Leave Focus do MaskedTextBox
        private void maskedtextBox_Leave(object sender, EventArgs e)
        {
            Boolean valido = ValidacaoTextBox.valido(maskedTextBox.Text, tipoTextBox);
            String valor = ValidacaoTextBox.getText(maskedTextBox.Text);
            if ((tipoTextBox == TipoTextBox.DataHora || tipoTextBox == TipoTextBox.DataHoraSimples) && getData() == null)
            {
                maskedTextBox.Text = "";
            }
            if ((valor == "" || valor == null) && obrigatorio == true)
            {
                setAvisoLabel("Campo Obrigatório");
            }
            else if ((valor != "" && valor != null) && valido == false)
            {
                setAvisoLabel("Campo Invalido");
            }
            else
            {
                removeAvisoLabel();
            }
        }

        //Evento de pressionar tecla do TextBox
        void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (somenteLeitura == false || edicaoLiberada)
            {
                if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Real)
                {
                    textBox.Text = ValorManager.valor_press_moeda(e.KeyChar, textBox.Text, permitirValorNegativo);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal)
                {
                    textBox.Text = ValorManager.valor_press_decimal(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal5Casas)
                {
                    textBox.Text = ValorManager.valor_press_decimal5casas(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal2Casas)
                {
                    textBox.Text = ValorManager.valor_press_decimal2casas(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.DecimalLivre)
                {
                    textBox.Text = ValorManager.valor_press_decimalLivre(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.NumeroEDigito)
                {
                    textBox.Text = press_NumeroEDigito(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Area)
                {
                    textBox.Text = ValorManager.valor_press_area(e.KeyChar, textBox.Text);
                    e.Handled = true;
                    textBox.SelectionStart = textBox.TextLength;
                }
                else if (tipoTextBox == Enumeradores.TipoTextBox.Coordenada)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void MaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            maskedTextBox.Text = maskedTextBox.Text.ToUpper();
        }

        //Tratamento do evento de escrita do tipo NumeroEDigito (Agencia, Conta)
        public String press_NumeroEDigito(Char ch, String valorAtual)
        {
            String valorRetorno = null;

            if (Char.IsDigit(ch))
            {
                valorRetorno = valorAtual.Replace("-", "") + "-" + ch;
                return valorRetorno;
            }
            else if (ch == '\b')
            {
                if (valorAtual.Length >= 3)
                {
                    valorRetorno = valorAtual.Replace("-", "");
                    valorRetorno = valorRetorno.Remove(valorRetorno.Length - 1);
                    Char ultimoDigito = valorRetorno[valorRetorno.Length - 1];
                    valorRetorno = valorRetorno.Remove(valorRetorno.Length - 1) + "-" + ultimoDigito;
                }
                return valorRetorno;
            }
            else
            {
                return valorAtual;
            }

        }

        //Habilitar alerta no label
        public void setAvisoLabel(String aviso)
        {
            //label.Text = "*" + nomeDisplay;
            //label.ForeColor = Color.DarkRed;
        }

        //Remover alerta do label
        public void removeAvisoLabel()
        {
            label.Text = nomeDisplay;
            label.ForeColor = Color.Black;
        }

        //Retorna um objeto dateTime | TipoTextBox.Data
        public DateTime? getData()
        {
            DateTime? data = null;
            if (tipoTextBox == Enumeradores.TipoTextBox.Data)
            {
                try
                {
                    if (Texto != null && Texto.Length == 10)
                    {
                        String dia = Texto[0].ToString() + Texto[1].ToString();
                        String mes = Texto[3].ToString() + Texto[4].ToString();
                        String ano = Texto[6].ToString() + Texto[7].ToString() + Texto[8].ToString() + Texto[9].ToString();
                        data = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtenso)
            {
                try
                {
                    if (Texto != null && Texto.Length == 10)
                    {
                        String dia = Texto[0].ToString() + Texto[1].ToString();
                        String mes = Texto[3].ToString() + Texto[4].ToString();
                        String ano = Texto[6].ToString() + Texto[7].ToString() + Texto[8].ToString() + Texto[9].ToString();
                        data = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtensoCompleto)
            {
                try
                {
                    if (Texto != null && Texto.Length == 10)
                    {
                        String dia = Texto[0].ToString() + Texto[1].ToString();
                        String mes = Texto[3].ToString() + Texto[4].ToString();
                        String ano = Texto[6].ToString() + Texto[7].ToString() + Texto[8].ToString() + Texto[9].ToString();
                        data = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Hora)
            {
                try
                {
                    String hora = Texto[0].ToString() + Texto[1].ToString();
                    String minuto = Texto[3].ToString() + Texto[4].ToString();
                    String segundo = Texto[6].ToString() + Texto[7].ToString();
                    data = new DateTime(1, 1, 1, Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataHora)
            {
                try
                {
                    String valor = Texto?.Replace("/", "").Replace(":", "").Replace("_", "").Replace(" ", "");
                    if (valor?.Length >= 8)
                    {
                        if (valor != null && valor != "")
                        {
                            valor = valor.PadRight(14, '0');
                        }

                        String dia = valor[0].ToString() + valor[1].ToString();
                        String mes = valor[2].ToString() + valor[3].ToString();
                        String ano = valor[4].ToString() + valor[5].ToString() + valor[6].ToString() + valor[7].ToString();

                        String hora = valor[8].ToString() + valor[9].ToString();
                        String minuto = valor[10].ToString() + valor[11].ToString();
                        String segundo = valor[12].ToString() + valor[13].ToString();
                        data = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia), Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataHoraSimples)
            {
                try
                {
                    String valor = Texto.Replace("/", "").Replace(":", "").Replace("_", "").Replace(" ", "");
                    if (valor.Length >= 8)
                    {
                        if (valor != null && valor != "")
                        {
                            valor = valor.PadRight(12, '0');
                        }

                        String dia = valor[0].ToString() + valor[1].ToString();
                        String mes = valor[2].ToString() + valor[3].ToString();
                        String ano = valor[4].ToString() + valor[5].ToString() + valor[6].ToString() + valor[7].ToString();

                        String hora = valor[8].ToString() + valor[9].ToString();
                        String minuto = valor[10].ToString() + valor[11].ToString();
                        data = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia), Convert.ToInt32(hora), Convert.ToInt32(minuto), 0);
                    }
                }
                catch
                {

                }
            }
            return data;
        }


        //Seta o texto a partir de um objeto dateTime | TipoTextBox.Data
        public void setData(DateTime? data)
        {
            if (tipoTextBox == Enumeradores.TipoTextBox.Data)
            {
                try
                {
                    if (data != null)
                    {
                        this.maskedTextBox.Text = data.Value.ToString().Remove(10);
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtenso)
            {
                try
                {
                    if (data != null)
                    {
                        this.maskedTextBox.Text = data.Value.ToString().Remove(10);
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtensoCompleto)
            {
                try
                {
                    if (data != null)
                    {
                        this.maskedTextBox.Text = data.Value.ToString().Remove(10);
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Hora)
            {
                try
                {
                    if (data != null)
                    {
                        this.maskedTextBox.Text = data.Value.ToString().Remove(0, 11);
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataHora || tipoTextBox == Enumeradores.TipoTextBox.DataHoraSimples)
            {
                try
                {
                    if (data != null)
                    {
                        this.maskedTextBox.Text = data.Value.ToString();
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }
        }

        //Retorna um objeto TimeSpan | TipoTextBox.Hora
        public TimeSpan? getTimeSpan()
        {
            TimeSpan? timeSpan = null;
            if (tipoTextBox == Enumeradores.TipoTextBox.Hora)
            {
                try
                {
                    String hora = Texto[0].ToString() + Texto[1].ToString();
                    String minuto = Texto[3].ToString() + Texto[4].ToString();
                    String segundo = Texto[6].ToString() + Texto[7].ToString();
                    timeSpan = new TimeSpan(Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                }
                catch
                {

                }
            }

            return timeSpan;
        }

        //Seta o texto a partir de um objeto TimeSpan | TipoTextBox.Hora
        public void setTimeSpan(TimeSpan? hora)
        {
            if (tipoTextBox == Enumeradores.TipoTextBox.Hora)
            {
                try
                {
                    if (hora != null)
                    {
                        this.maskedTextBox.Text = hora.Value.ToString();
                    }
                    else
                    {
                        this.maskedTextBox.Clear();
                    }
                }
                catch
                {

                }
            }

        }

        //Retorna um objeto decimal | TipoTextBox.Real ou TipoTextBox.Area
        public Decimal getDecimal()
        {
            Decimal valor = 0;
            if (tipoTextBox == Enumeradores.TipoTextBox.Real)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valorStr = valorStr.Remove(1, 2);
                    valorStr = valorStr.Replace(" ", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch (Exception ex)
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal5Casas)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal2Casas)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DecimalLivre)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Area)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "").Replace(" ", "").Replace("m", "").Replace("²", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Coordenada)
            {
                try
                {
                    valor = Convert.ToDecimal(maskedTextBox.Text.Replace(".", ","));
                }
                catch
                {

                }
            }
            return valor;
        }

        //Retorna um objeto decimal | TipoTextBox.Real ou TipoTextBox.Area
        public Decimal? getDecimalOuNulo()
        {
            Decimal? valor = null;
            if (tipoTextBox == Enumeradores.TipoTextBox.Real)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valorStr = valorStr.Remove(1, 2);
                    valorStr = valorStr.Replace(" ", "");
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Area)
            {
                try
                {
                    String valorStr = textBox.Text.Replace(".", "");
                    valorStr = valorStr.TrimEnd('m', '²', ' ');
                    valor = Convert.ToDecimal(valorStr);
                }
                catch
                {

                }
            }
            return valor;
        }

        //Seta o texto a partir de um objeto decimal | TipoTextBox.Real
        public void setDecimal(Decimal? valor)
        {

            try
            {
                if (valor != null)
                {
                    if (tipoTextBox == Enumeradores.TipoTextBox.Real)
                    {
                        textBox.Text = ValorManager.formatarValorMoedaTextBox(valor);
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal)
                    {
                        textBox.Text = ValorManager.formatarValorDecimal(valor);
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal5Casas)
                    {
                        textBox.Text = ValorManager.formatarValorDecimal5Places(valor);
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.Decimal2Casas)
                    {
                        textBox.Text = ValorManager.formatarValorDecimal2Places(valor);
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.DecimalLivre)
                    {
                        String valorInt = valor.Value.ToString().Replace(".", "").Split(',').FirstOrDefault();
                        String valorDecimal = valor.Value.ToString().Replace(".", "").Split(',').LastOrDefault().TrimEnd(',', '0');
                        if (valorDecimal.Length > 0)
                        {
                            valorDecimal = "," + valorDecimal;
                        }
                        else if (valorInt.Length > 0)
                        {
                            valorDecimal += ",00";
                        }

                        if (valorInt?.Length > 0)
                        {
                            valorInt = ValorManager.formatarValorDecimal(Convert.ToInt64(valorInt)).Split(',').FirstOrDefault();
                        }

                        textBox.Text = valorInt + valorDecimal;
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.Coordenada)
                    {
                        maskedTextBox.Text = ValorManager.formatarValorCoordenada((Decimal)valor);
                    }
                    else if (tipoTextBox == Enumeradores.TipoTextBox.Area)
                    {
                        textBox.Text = ValorManager.formatarValorArea(valor);
                    }
                }
            }
            catch
            {

            }

        }

        //Retorna um objeto inteiro | TipoTextBox.Inteiro
        public int? getInteiro()
        {
            int? valor = null;
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                try
                {
                    String valorStr = textBox.Text;

                    int resultado;
                    if (int.TryParse(valorStr, out resultado))
                    {
                        valor = resultado;
                    }

                }
                catch
                {

                }
            }
            return valor;
        }

        public Int64? getInteiro64()
        {
            Int64? valor = null;
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                try
                {
                    String valorStr = textBox.Text;

                    int resultado;
                    if (int.TryParse(valorStr, out resultado))
                    {
                        valor = resultado;
                    }

                }
                catch
                {

                }
            }
            return valor;
        }

        //Retorna um objeto inteiro | TipoTextBox.Inteiro
        public int getInteiroOuZero()
        {
            int valor = 0;
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                String valorStr = textBox.Text;
                int.TryParse(valorStr, out valor);
            }
            return valor;
        }
        public Int64 getInteiro64OuZero()
        {
            Int64 valor = 0;
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                try
                {
                    String valorStr = textBox.Text;
                    valor = Convert.ToInt64(valorStr);
                }
                catch
                {

                }
            }
            return valor;
        }

        //Seta o texto a partir de um objeto inteiro | TipoTextBox.Inteiro
        public void setInteiro(Int32? valor)
        {
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                try
                {
                    if (valor != null)
                    {
                        String valorStr = valor.ToString();
                        textBox.Text = valorStr;
                    }
                }
                catch
                {

                }
            }
        }
        public void setInteiro(Int64? valor)
        {
            if (tipoTextBox == Enumeradores.TipoTextBox.Inteiro)
            {
                try
                {
                    if (valor != null)
                    {
                        String valorStr = valor.ToString();
                        textBox.Text = valorStr;
                    }
                }
                catch
                {

                }
            }
        }

        Boolean CustomControl.Valido()
        {
            if ((tipoTextBox == Enumeradores.TipoTextBox.Texto || tipoTextBox == Enumeradores.TipoTextBox.Inteiro) && obrigatorio == true && (Texto == null || Texto == ""))
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Data && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtenso && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataExtensoCompleto && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.Hora && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataHora && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == Enumeradores.TipoTextBox.DataHoraSimples && obrigatorio == true && getData() == null)
            {
                return false;
            }
            else if (tipoTextBox == TipoTextBox.SeloFisico && maskedTextBox.Text.Length < 8 && obrigatorio == true)
            {
                return false;
            }
            else if (tipoTextBox == TipoTextBox.PapelMoeda && maskedTextBox.Text.Length < 11 && obrigatorio == true)
            {
                return false;
            }
            else if (tipoTextBox == TipoTextBox.Cpf && maskedTextBox.Text.Replace("_", "").Length < 14 && obrigatorio == true)
            {
                return false;
            }
            else if (tipoTextBox == TipoTextBox.Decimal2Casas && getDecimal() == 0 && obrigatorio == true)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

    }
}
