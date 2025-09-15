using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.CustomControls
{
    public class BotaoCC : Button
    {
        private TipoBotao tipoBotao;
        private EnumNivelDeAcesso? nivelAcesso = null;

        public BotaoCC()
        {
            this.Text = "Botão";
            this.Size = new System.Drawing.Size(120, 35);
            this.Font = new Font("Arial", 11, FontStyle.Bold);
        }


        [Description("Tipo de Botão"), Category("Configuração")]
        public TipoBotao TipoBotao
        {
            get { return tipoBotao; }
            set { tipoBotao = value; configurarBotao(); }
        }

        [Description("Nivel de acesso do botão"), Category("Definição")]
        public EnumNivelDeAcesso? NivelDeAcesso
        {
            get { return nivelAcesso; }
            set { nivelAcesso = value; }
        }

        public void configurarBotao()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            switch (tipoBotao)
            {
                case TipoBotao.Cadastrar:
                    this.Text = "Cadastrar";
                    this.ForeColor = Color.Blue;
                    break;
                case TipoBotao.Deletar:
                    this.Text = "Deletar";
                    this.ForeColor = Color.Red;
                    break;
                case TipoBotao.Novo:
                    this.Text = "Novo";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.Salvar:
                    this.Text = "Salvar";
                    this.ForeColor = Color.DarkBlue;                    
                    break;
                case TipoBotao.Selecionar:
                    this.Text = "Selecionar";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.Cancelar:
                    this.Text = "Cancelar";
                    this.ForeColor = Color.DarkRed;
                    break;
                case TipoBotao.CancelarPagamento:
                    this.Text = "Cancelar Pagamento";
                    this.ForeColor = Color.DarkRed;
                    break;
                case TipoBotao.SmallAdicionar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Adicionar";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.SmallAdicionarMultiplos:
                    this.Size = new System.Drawing.Size(150, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Adicionar Multiplos";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.SmallAlterar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Alterar";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.SmallSalvar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Salvar";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.SmallRemover:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Remover";
                    this.ForeColor = Color.DarkRed;
                    break;
                case TipoBotao.SmallVisualizar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Visualizar";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.SmallCancelar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Cancelar";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.SmallPesquisar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Pesquisar";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.Gerar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Gerar";
                    this.ForeColor = Color.DarkOliveGreen;
                    break;
                case TipoBotao.FinalizarPedido:
                    this.Text = "Confirmar Pedido";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.SalvarPedido:
                    this.Text = "Alterar Pedido";
                    this.ForeColor = Color.DarkOliveGreen;
                    break;
                case TipoBotao.SalvarOrcamento:
                    this.Text = "Salvar Orçamento";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.AlterarOrcamento:
                    this.Text = "Alterar Orçamento";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.TrocoDecolucao:
                    this.Text = "Troco/Devolução";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.CancelarOrcamento:
                    this.Text = "Cancelar Pedido";
                    this.ForeColor = Color.DarkRed;
                    break;
                case TipoBotao.Sair:
                    this.Text = "Sair";
                    this.ForeColor = Color.Black;
                    break;
                case TipoBotao.Pagar:
                    this.Text = "Pagar";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.PraticarAtos:
                    this.Text = "Praticar Atos";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.PraticarAto:
                    this.Text = "Praticar Ato";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.Retificar:
                    this.Text = "Retificar";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.ReenviarLote:
                    this.Text = "Reenviar Lote";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.AbrirAto:
                    this.Text = "Abrir Ato";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.AbrirPedido:
                    this.Text = "Abrir Pedido";
                    this.ForeColor = Color.ForestGreen;
                    break;
                case TipoBotao.Recibo:
                    this.Text = "Recibo";
                    this.ForeColor = Color.DodgerBlue;
                    break;
                case TipoBotao.Cupom:
                    this.Text = "Cupom";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.Imprimir:
                    this.Text = "Imprimir";
                    this.ForeColor = Color.DodgerBlue;
                    break;
                case TipoBotao.ReconsultarLote:
                    this.Text = "Reconsultar";
                    this.ForeColor = Color.DodgerBlue;
                    break;
                case TipoBotao.AtoOriginal:
                    this.Size = new System.Drawing.Size(80, 22);
                    this.Font = new Font("Arial", 10, FontStyle.Bold);
                    this.Text = "Ato Original";
                    this.ForeColor = Color.MidnightBlue;
                    break;
                case TipoBotao.Sim:
                    this.Text = "Sim";
                    this.ForeColor = Color.DodgerBlue;
                    break;
                case TipoBotao.Nao:
                    this.Text = "Não";
                    this.ForeColor = Color.DarkRed;
                    break;
                case TipoBotao.AbrirImovel:
                    this.Text = "Abrir Imovel";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.GerarImovel:
                    this.Text = "Gerar Imovel";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.EditorTexto:
                    this.Text = "Editor de Texto";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.RetificarArea:
                    this.Text = "Ret. Area";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.OK:
                    this.Text = "OK";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.FichaCompleta:
                    this.Text = "Visualizar Ficha Completa";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.ConcluirDemanda:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Concluir Demanda";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.ReabrirDemanda:
                    this.Text = "Reabrir Demanda";
                    this.ForeColor = Color.BlueViolet;
                    break;
                case TipoBotao.FinalizarPendencia:
                    this.Size = new System.Drawing.Size(127, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Finalizar Pendencia";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.PraticarAtosPendentesSelo:
                    this.Text = "Praticar Atos Pendentes de Selo";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.PraticarAtoPendenteSelo:
                    this.Text = "Praticar Ato Pendente de Selo";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.ImprimirEtiqueta:
                    this.Size = new System.Drawing.Size(130, 26);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Imprimir Etiqueta";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.Sincronizar:
                    this.Size = new System.Drawing.Size(100, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Sincronizar";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.FinalizarPrenotacao:
                    this.Size = new System.Drawing.Size(139, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Finalizar Prenotação";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.Finalizar:
                    this.Size = new System.Drawing.Size(110, 26);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Finalizar";
                    this.ForeColor = Color.DarkBlue;
                    break;
                case TipoBotao.ReceberConta:
                    this.Size = new System.Drawing.Size(139, 24);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Receber Conta";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.PagarConta:
                    this.Size = new System.Drawing.Size(139, 24);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Pagar Conta";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.DevolverConta:
                    this.Size = new System.Drawing.Size(139, 24);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Devolver/Cancelar";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.GerarCartaoAutografo:
                    this.Text = "Gerar Cartão de Autografo";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.SmallSelar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Selar";
                    this.ForeColor = Color.Blue;
                    break;
                case TipoBotao.SmallRemoverTodos:
                    this.Size = new System.Drawing.Size(116, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Remover Todos";
                    this.ForeColor = Color.Red;
                    break;
                case TipoBotao.GerarXml:
                    this.Text = "Gerar XML";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.Enviado:
                    this.Text = "Enviado";
                    this.ForeColor = Color.Blue;
                    break;
                case TipoBotao.PesquisarMenu:
                    this.Text = "PESQUISAR";
                    this.ForeColor = Color.Black;
                    this.BackColor = Color.White;
                    break;
                case TipoBotao.SmallArmazenar:
                    this.Size = new System.Drawing.Size(84, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Armazenar";
                    this.ForeColor = Color.DarkOrange;
                    break;
                case TipoBotao.SmallConsultar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Consultar";
                    this.ForeColor = Color.Blue;
                    break;
                case TipoBotao.SmallValidar:
                    this.Size = new System.Drawing.Size(77, 22);
                    this.Font = new Font("Arial", 9, FontStyle.Bold);
                    this.Text = "Validar";
                    this.ForeColor = Color.BlueViolet;
                    break;
                case TipoBotao.EmitirCarta:
                    this.Text = "Emitir Carta";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.NotificacaoConcluida:
                    this.Text = "Notificação Concluida";
                    this.ForeColor = Color.DarkGreen;
                    break;
                case TipoBotao.GerarEdital:
                    this.Text = "Gerar Edital";
                    this.ForeColor = Color.OrangeRed;
                    break;
                case TipoBotao.EditalConcluido:
                    this.Text = "Edital Concluido";
                    this.ForeColor = Color.DarkGreen;
                    break;
            }
        }

    }
}
