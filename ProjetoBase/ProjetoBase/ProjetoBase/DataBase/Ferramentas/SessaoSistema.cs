using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.Enumeradores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoBase.DataBase.Ferramentas // Mantemos o namespace mais específico
{
    public static class SessaoSistema
    {
        // --- Propriedades do arquivo original ---
        public static Funcionario funcionario { get; set; } = null;
        public static string ChaveLevontec { get; set; } = null;
        public static Point posicaoNotificacaoChat { get; set; }
        internal static bool emailAvisoHandlersEnviado { get; set; } = false;
        public static string modulo { get; set; }
        public static Point PosicaoForm { get; internal set; }
        public static Size TamanhoForm { get; internal set; }
        public static int SavesSemCommit { get; internal set; }
        public static FormWindowState WindowStateForm { get; set; } = FormWindowState.Maximized;

        // --- Nosso novo método de verificação de permissão ---
        /// <summary>
        /// Verifica se o usuário logado possui uma permissão específica.
        /// </summary>
        /// <param name="permissaoExigida">O nível de acesso que se deseja verificar (pode ser nulo).</param>
        /// <returns>Verdadeiro se o usuário tiver a permissão ou se nenhuma permissão for exigida.</returns>
        public static bool VerificarPermissao(EnumNivelDeAcesso? permissaoExigida)
        {
            if (permissaoExigida == null) return true;
            if (funcionario == null || funcionario.usuario == null) return false;
            if (funcionario.usuario.Administrador) return true;

            // Converte o nome do enum da permissão exigida para uma string.
            string nomePermissaoExigida = permissaoExigida.Value.ToString();

            var todasAsPermissoes = new HashSet<NivelDeAcesso>(funcionario.usuario.NivelDeAcesso);
            if (funcionario.usuario.PerfilDeAcesso != null)
            {
                todasAsPermissoes.UnionWith(funcionario.usuario.PerfilDeAcesso.NivelDeAcesso);
            }

            // A NOVA COMPARAÇÃO: por Nome, ignorando diferenças de maiúsculas/minúsculas.
            bool temPermissao = todasAsPermissoes.Any(nivel =>
                nivel.Nome.Equals(nomePermissaoExigida, StringComparison.OrdinalIgnoreCase)
            );

            return temPermissao;
        }
    }
}