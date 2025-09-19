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

            Login formLogin = new Login();

            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MenuInicial());
            }
        }
    }
}
