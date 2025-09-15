using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.DataBase.Ferramentas;

namespace ProjetoBase.CustomControls.Validacao
{
    public class RetornoValidacaoDados
    {
        public Boolean Valido = true;
        public String CamposInvalidos = "";
        public MessageBox messageBoxInvalido;

        public void addCampoInvalido(String campo)
        {
            CamposInvalidos = CamposInvalidos + "*" + campo + "\n";
        }
    }

    public static class ValidacaoDadosObrigatorios
    {

        //Validar campos dentro de um panel
        public static RetornoValidacaoDados validarPanel(Panel panel)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();

            for (int x = 0; x < panel.Controls.Count; x++)
            {
                Control controle = panel.Controls[x];

                if (controle is CustomControl)
                {
                    CustomControl controleCustomizado = (CustomControl)controle;
                    if (controleCustomizado.Valido() == false)
                    {
                        retorno.Valido = false;
                        retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                    }
                }
            }
            if (retorno.Valido == false)
            {
                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n Deseja prosseguir mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    retorno.Valido = true;
                }
            }
            return retorno;
        }

        //Validar campos dentro de um panel - Não permite ação caso campos invalidos
        public static RetornoValidacaoDados validarPanelObrigatorio(Panel panel)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();
            validarControle(panel, retorno);

            if (retorno.Valido == false)
            {
                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return retorno;
        }

        //Validar campos dentro de multiplos panels - Não permite ação caso campos invalidos
        public static RetornoValidacaoDados validarControlesObrigatorios(List<Control> controles)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();

            foreach (Control controle in controles)
            {
                validarControle(controle, retorno);
            }

            if (retorno.Valido == false)
            {
                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return retorno;
        }

        public static String validarControle(Control controle, RetornoValidacaoDados retorno)
        {
            String camposInvalidos = "";

            if (controle is CustomControl)
            {
                CustomControl controleCustomizado = (CustomControl)controle;
                if (controleCustomizado.Valido() == false)
                {
                    retorno.Valido = false;
                    retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                }
            }
            else
            {
                foreach (Control controleFilho in controle.Controls)
                {
                    if (controleFilho is CustomControl)
                    {
                        CustomControl controleCustomizado = (CustomControl)controleFilho;
                        if (controleCustomizado.Valido() == false)
                        {
                            retorno.Valido = false;
                            retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                        }
                    }
                    else
                    {
                        validarControle(controleFilho, retorno);
                    }
                }
            }
            return camposInvalidos;
        }

        //Validar campos dentro de um groupBox - Não permite ação caso campos invalidos
        public static RetornoValidacaoDados validarGroupBoxObrigatorio(GroupBox groupBox)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();

            for (int x = 0; x < groupBox.Controls.Count; x++)
            {
                Control controle = groupBox.Controls[x];

                if (controle is CustomControl)
                {
                    CustomControl controleCustomizado = (CustomControl)controle;
                    if (controleCustomizado.Valido() == false)
                    {
                        retorno.Valido = false;
                        retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                    }
                }
            }
            if (retorno.Valido == false)
            {
                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return retorno;
        }


        //Verificar se controle contem algo preenchido
        public static Boolean ControlePreenchido(Control controle)
        {
            Boolean preenchido = false;
            for (int x = 0; x < controle.Controls.Count; x++)
            {
                Control controleInterno = controle.Controls[x];

                if (controleInterno is CustomControl)
                {
                    if (controleInterno is TextboxLabelCC)
                    {
                        TextboxLabelCC textBoxLabelCC = (TextboxLabelCC)controleInterno;
                        if (textBoxLabelCC.Texto != null && textBoxLabelCC.Texto != "")
                        {
                            preenchido = true;
                        }
                    }
                    //else if (controleInterno is SeletorCC)
                    //{
                    //    SeletorCC SeletorCC = (SeletorCC)controleInterno;
                    //    if (SeletorCC.codigoInt != null)
                    //    {
                    //        preenchido = true;
                    //    }
                    //}
                    //else if (controleInterno is SeletorCadastralCC)
                    //{
                    //    SeletorCadastralCC SeletorCadastralCC = (SeletorCadastralCC)controleInterno;
                    //    if (SeletorCadastralCC.getEntidade() != null)
                    //    {
                    //        preenchido = true;
                    //    }
                    //}

                }
            }

            return preenchido;
        }

        //Validar campos dentro de varios panels
        public static RetornoValidacaoDados validarPaneis(Panel[] panel)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();
            for (int contPanel = 0; contPanel < panel.Length; contPanel++)
            {
                for (int x = 0; x < panel[contPanel].Controls.Count; x++)
                {
                    Control controle = panel[contPanel].Controls[x];

                    if (controle is CustomControl)
                    {
                        CustomControl controleCustomizado = (CustomControl)controle;
                        if (controleCustomizado.Valido() == false)
                        {
                            retorno.Valido = false;
                            retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                        }
                    }
                }
            }
            if (retorno.Valido == false)
            {
                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n Deseja prosseguir mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    retorno.Valido = true;
                }
            }
            return retorno;
        }

        //validar campos dentro de um panel e campos avulsos
        public static RetornoValidacaoDados validarPanelECamposEndereco(Panel panel, CustomControl[] controles)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();

            for (int x = 0; x < panel.Controls.Count; x++)
            {
                Control controle = panel.Controls[x];

                if (controle is CustomControl)
                {
                    CustomControl controleCustomizado = (CustomControl)controle;
                    if (controleCustomizado.Valido() == false)
                    {
                        retorno.Valido = false;
                        retorno.addCampoInvalido(controleCustomizado.NomeDisplay);
                    }
                }
            }

            for (int contControle = 0; contControle < controles.Length; contControle++)
            {
                if (controles[contControle].Valido() == false)
                {
                    retorno.Valido = false;
                    retorno.addCampoInvalido(controles[contControle].NomeDisplay);
                }
            }


            if (retorno.Valido == false)
            {

                DialogResult resultado = MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n Deseja prosseguir mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    retorno.Valido = true;
                }

            }
            return retorno;
        }

        public static RetornoValidacaoDados validarCamposObrigatirios(CustomControl[] controles)
        {
            RetornoValidacaoDados retorno = new RetornoValidacaoDados();

            for (int contControle = 0; contControle < controles.Length; contControle++)
            {
                if (controles[contControle].Valido() == false)
                {
                    retorno.Valido = false;
                    retorno.addCampoInvalido(controles[contControle].NomeDisplay);
                }
            }
            if (retorno.Valido == false)
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!\n-----------------------------------------\n" + retorno.CamposInvalidos + "-----------------------------------------\n\n", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return retorno;
        }
    }
}
