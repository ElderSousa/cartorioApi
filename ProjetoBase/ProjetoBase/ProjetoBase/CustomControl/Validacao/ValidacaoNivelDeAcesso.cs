using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Exceptions;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.CustomControls.Validacao
{
    public static class ValidacaoNivelDeAcesso
    {
        public static Boolean acessoPermitido(EnumNivelDeAcesso? nivelAcesso)
        {
            try
            {

                Boolean acessoPermitido = false;

                if (nivelAcesso != null)
                {

                    if (SessaoSistema.funcionario.usuario.PerfilDeAcesso != null)
                    {

                        if (SessaoSistema.funcionario.usuario.PerfilDeAcesso.NivelDeAcesso.Where(x => x.Id == (int)nivelAcesso.Value).SingleOrDefault() != null)
                        {
                            acessoPermitido = true;
                        }

                    }

                    if (SessaoSistema.funcionario.usuario.NivelDeAcesso.Where(x => x.Id == (int)nivelAcesso.Value).SingleOrDefault() != null)
                    {
                        acessoPermitido = true;
                    }
                }
                else
                {
                    acessoPermitido = true;
                }

                if (acessoPermitido == false)
                {
                    NivelDeAcesso nivelBloqueado = Repositorios.NivelDeAcesso.ProcurarPorID(Convert.ToInt32(nivelAcesso));
                    if (nivelBloqueado != null)
                    {
                        MessageBox.Show("Você não tem permissão para realizar esta operação! \n\n Nivel de Acesso: " + nivelBloqueado.Nome + " \n\n Contate um administrador", "Acesso negado!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Você não tem permissão para realizar esta operação! \n\n Nivel de Acesso: " + nivelAcesso + " não cadastrado! \n\n Contate um administrador", "Acesso negado!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                return acessoPermitido;
            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
                return false;
            }
        }

        public static Boolean acessoPermitido(EnumNivelDeAcesso? nivelAcesso, Object toolStripObj)
        {
            try
            {

                Boolean acessoPermitido = false;

                if (nivelAcesso != null)
                {

                    if (SessaoSistema.funcionario.usuario.PerfilDeAcesso != null)
                    {

                        if (SessaoSistema.funcionario.usuario.PerfilDeAcesso.NivelDeAcesso.Where(x => x.Id == (int)nivelAcesso.Value).SingleOrDefault() != null)
                        {
                            acessoPermitido = true;
                        }

                    }

                    if (SessaoSistema.funcionario.usuario.NivelDeAcesso.Where(x => x.Id == (int)nivelAcesso.Value).SingleOrDefault() != null)
                    {
                        acessoPermitido = true;
                    }
                }

                String textoNivel = null;

                if (toolStripObj != null && toolStripObj is ToolStripMenuItem)
                {
                    var toolStrip = (ToolStripMenuItem)toolStripObj;

                    textoNivel = " - " + toolStrip.Text;

                    var controlePai = toolStrip.OwnerItem;
                    while (controlePai != null)
                    {
                        textoNivel = " - " + controlePai.Text + textoNivel;
                        controlePai = controlePai.OwnerItem;
                    }

                    textoNivel = textoNivel.TrimStart(' ', '-');
                    
                    if (SessaoSistema.funcionario.usuario.PerfilDeAcesso != null)
                    {

                        if (SessaoSistema.funcionario.usuario.PerfilDeAcesso.NivelDeAcesso.Where(x => x.Nome == textoNivel).SingleOrDefault() != null)
                        {
                            acessoPermitido = true;
                        }

                    }

                    if (SessaoSistema.funcionario.usuario.NivelDeAcesso.Where(x => x.Nome == textoNivel).SingleOrDefault() != null)
                    {
                        acessoPermitido = true;
                    }
                }


                if (acessoPermitido == false)
                {
                    NivelDeAcesso nivelBloqueado = Repositorios.NivelDeAcesso.ProcurarPorID(Convert.ToInt32(nivelAcesso));
                    if (nivelBloqueado != null)
                    {
                        MessageBox.Show("Você não tem permissão para realizar esta operação! \n\n Nivel de Acesso: " + (textoNivel ?? nivelBloqueado.Nome) + " \n\n Contate um administrador", "Acesso negado!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Você não tem permissão para realizar esta operação! \n\n Nivel de Acesso: " + (textoNivel ?? nivelAcesso.ToString()) + " não cadastrado! \n\n Contate um administrador", "Acesso negado!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                return acessoPermitido;
            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
                return false;
            }
        }


        public static Boolean acessoPermitidoSemDialogo(EnumNivelDeAcesso? nivelAcesso)
        {
            try
            {
                Boolean acessoPermitido = false;

                if (nivelAcesso != null)
                {
                    SessaoSistema.funcionario = Repositorios.Funcionario.ProcurarPorID(SessaoSistema.funcionario.Id);

                    foreach (NivelDeAcesso nivel in SessaoSistema.funcionario.usuario.NivelDeAcesso)
                    {
                        if (Convert.ToInt32(nivel.Codigo) == (int)nivelAcesso.Value)
                        {
                            acessoPermitido = true;
                            break;
                        }
                    }
                }
                else
                {
                    acessoPermitido = true;
                }

                return acessoPermitido;
            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
                return false;
            }
        }
    }
}
