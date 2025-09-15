using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.Formularios.Ferramentas
{
    public partial class ReconectarBancoCadastro : FormCC
    {
        public ReconectarBancoCadastro()
        {
            InitializeComponent();

            Thread threadReconexao = new Thread(Reconexao);
            threadReconexao.Start();
        }

        void Reconexao()
        {
            Boolean desconectado = true;
            while (desconectado)
            {
                try
                {
                    SessionFactory.Session().CreateSQLQuery("SELECT CAST(CAST(GETDATE() AS DATE) AS DATETIME)").UniqueResult();
                    desconectado = false;
                }
                catch
                {

                }
            }

            if (desconectado == false)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void ValidacaoAcao_Load(object sender, EventArgs e)
        {

        }

        private void btn_reconectar_Click(object sender, EventArgs e)
        {

        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            if (lb_status.Text.Length < 15)
            {
                lb_status.Text += ".";
            }
            else
            {
                lb_status.Text = "Reconectando";
            }
        }
    }

    public static class ReconectarBanco
    {
        private static ReconectarBancoCadastro janela = null;

        public static Boolean reconectar()
        {
            if (janela == null)
            {
                janela = new ReconectarBancoCadastro();
                janela.ShowDialog();
                if (janela.DialogResult == DialogResult.Yes)
                {
                    janela.Dispose();
                    janela = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Boolean janelaAberta()
        {
            if (janela == null)
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
