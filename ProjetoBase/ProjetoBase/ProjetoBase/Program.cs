using ProjetoBase.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoBase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cria uma instância do nosso NOVO formulário de login
            Login formLogin = new Login();

            // Mostra o login como uma "caixa de diálogo". O código pausa aqui
            // até que o login seja fechado.
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                // Se o login foi bem-sucedido (DialogResult.OK),
                // a aplicação principal inicia com o MenuInicial.
                Application.Run(new MenuInicial());
            }
            // Se o login foi cancelado ou fechado, o método Main() termina
            // e a aplicação se encerra sem abrir nada.
        }
    }
}
