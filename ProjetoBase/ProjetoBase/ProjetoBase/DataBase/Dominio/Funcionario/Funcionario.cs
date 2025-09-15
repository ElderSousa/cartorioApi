using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class Funcionario : Entidade
    {
        public virtual int Id { get; set; }
        public virtual DateTime? DataAdmissao { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Cpf { get; set; }
        public virtual String Rg { get; set; }
        public virtual DateTime? DataNascimento { get; set; }
        public virtual String DDD { get; set; }
        public virtual String Telefone { get; set; }
        public virtual String Email { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual String IpEstacaoLogada { get; set; }
        public virtual Byte[] Foto { get; set; }
        public virtual String StatusChat { get; set; }
        public virtual Boolean AssinaReconhecimentoFirma { get; set; }
        public virtual Boolean SomenteSelosFisicosAlocados { get; set; }
        public virtual Boolean SelarSeloFisicoAutomatico { get; set; }
        public virtual Boolean SelarAutomaticoBotaoPraticar { get; set; }
        public virtual Boolean AssinaAtosBalcao { get; set; }
        public virtual Boolean EmiteCPF { get; set; }
        public virtual Boolean? Inativo { get; set; }
        public virtual Boolean ConfiguraNivelAcessoDinamico { get; set; }


        public virtual string Codigo
        {
            get
            {
                return Id.ToString();
            }
        }

        public virtual string Descricao
        {
            get
            {
                String descricao = Nome;

                if (Cargo != null)
                {
                    descricao += " - " + Cargo.Descricao;
                }
                return descricao;
            }
        }
        public virtual Entidade Proprio
        {
            get { return this; }
        }

        public virtual Boolean verificarAcesso(EnumNivelDeAcesso EnumNivelDeAcesso)
        {
            Boolean acessoPermitido = false;
            NivelDeAcesso nivelAcessoVerTodasDemandas = Repositorios.NivelDeAcesso.ProcurarPorID(EnumNivelDeAcesso);
            usuario = Repositorios.Usuario.UnProxyObjectAs(usuario);

            ISet<NivelDeAcesso> niveis = usuario.NivelDeAcesso;

            if (usuario.PerfilDeAcesso != null)
            {
                foreach (NivelDeAcesso nivelPerfil in usuario.PerfilDeAcesso.NivelDeAcesso)
                {
                    niveis.Add(nivelPerfil);
                }
            }

            foreach (NivelDeAcesso nivel in niveis)
            {
                NivelDeAcesso nivelUnproxed = Repositorios.NivelDeAcesso.UnProxyObjectAs(nivel);
                if (nivelUnproxed.Id == nivelAcessoVerTodasDemandas?.Id)
                {
                    acessoPermitido = true;
                    break;
                }
            }


            return acessoPermitido;
        }

     

        public virtual String getDataNascimento()
        {
            if (DataNascimento != null)
            {
                return DataNascimento.Value.ToString().Remove(10);
            }
            else
            {
                return null;
            }
        }

        public virtual String getDataAdmissao()
        {
            if (DataAdmissao != null)
            {
                return DataAdmissao.Value.ToString().Remove(10);
            }
            else
            {
                return null;
            }
        }


        public virtual Brush getCorStatus()
        {
            Brush cor = Brushes.DarkGray;
            if (StatusChat != null && IpEstacaoLogada != null)
            {
                switch (StatusChat)
                {
                    case "Online":
                        cor = Brushes.Green;
                        break;
                    case "Ausente":
                        cor = Brushes.Orange;
                        break;
                    case "Ocupado":
                        cor = Brushes.Red;
                        break;
                }
            }
            return cor;
        }

        public virtual void getStatus(out String status, out Color cor)
        {
            cor = Color.DarkGray;
            status = "Offline";
            if (StatusChat != null && IpEstacaoLogada != null)
            {
                status = StatusChat;
                switch (StatusChat)
                {
                    case "Online":
                        cor = Color.Green;
                        break;
                    case "Ausente":
                        cor = Color.Orange;
                        break;
                    case "Ocupado":
                        cor = Color.Red;
                        break;
                }

            }
        }

    }
}
