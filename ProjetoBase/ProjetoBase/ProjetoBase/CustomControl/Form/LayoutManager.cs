using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ProjetoBase.Config
{

    public static class LayoutManager
    {
        public static Color corBotaoMouseEnter = Color.FromArgb(48, 130, 193);
        public static Color corBotaoMouseLeave = Color.FromArgb(43, 44, 46);
        public static Color corBotaoMenuAtual = Color.FromArgb(147, 196, 233);
        public static Color corSelecaoItemMenuStrip = Color.FromArgb(30, 117, 184);
        public static Color corItemMenuStrip = Color.FromArgb(43, 44, 46);
        public static Color corPictureBoxDivisor = Color.FromArgb(255, 255, 255);
        public static Color corTextoStrip = Color.FromArgb(255, 255, 255);


        //---------------------------------------Acoes---------------------------------------


        //---------------------------------------Atalhos---------------------------------------
        public static Image ImageBotaoCadastrar = Properties.Resources.Icon_btn_cadastrar_branco;
        public static Image ImageBotaoEditar = Properties.Resources.Icon_btn_editar_branco;
        public static Image ImageBotaoDeletar = Properties.Resources.Icon_btn_deletar_branco;

        public static void setLayout_Dark_Blue()
        {
            corBotaoMouseEnter = Color.FromArgb(48, 130, 193);
            corBotaoMouseLeave = Color.FromArgb(43, 44, 46);
            corBotaoMenuAtual = Color.FromArgb(147, 196, 233);
            corSelecaoItemMenuStrip = Color.FromArgb(30, 117, 184);
            corItemMenuStrip = Color.FromArgb(43, 44, 46);
            corPictureBoxDivisor = Color.FromArgb(255, 255, 255);
            corTextoStrip = Color.FromArgb(255, 255, 255);
            setBotoesLayoutDark();
        }

        public static void setLayout_Dark_Red()
        {
            corBotaoMouseEnter = Color.FromArgb(193, 0, 0);
            corBotaoMouseLeave = Color.FromArgb(43, 44, 46);
            corBotaoMenuAtual = Color.FromArgb(203, 131, 131);
            corSelecaoItemMenuStrip = Color.FromArgb(150, 0, 0);
            corItemMenuStrip = Color.FromArgb(43, 44, 46);
            corPictureBoxDivisor = Color.FromArgb(255, 255, 255);
            corTextoStrip = Color.FromArgb(255, 255, 255);
            setBotoesLayoutDark();
        }

        public static void setLayout_Dark_Green()
        {
            corBotaoMouseEnter = Color.FromArgb(0, 170, 85);
            corBotaoMouseLeave = Color.FromArgb(43, 44, 46);
            corBotaoMenuAtual = Color.FromArgb(159, 218, 162);
            corSelecaoItemMenuStrip = Color.FromArgb(0, 140, 70);
            corItemMenuStrip = Color.FromArgb(43, 44, 46);
            corPictureBoxDivisor = Color.FromArgb(255, 255, 255);
            corTextoStrip = Color.FromArgb(255, 255, 255);
            setBotoesLayoutDark();
        }
             
        private static void setBotoesLayoutDark()
        {
          
        }


    }
}
