using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.Config;
using ProjetoBase.Enumeradores;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.CustomControls
{
    public class MenuStripCC : MenuStrip
    {
        public MenuStripCC()
        {
            this.Renderer = new MyRenderer();
            this.BackColor = LayoutManager.corItemMenuStrip;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = LayoutManager.corItemMenuStrip;
        }
    }

    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    public class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return LayoutManager.corItemMenuStrip; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return LayoutManager.corItemMenuStrip; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return LayoutManager.corItemMenuStrip; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return LayoutManager.corItemMenuStrip; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

        public override Color MenuItemBorder
        {
            get { return LayoutManager.corSelecaoItemMenuStrip; }
        }

    }

    public class ToolStripMenuItemCC : ToolStripMenuItem
    {
        private EnumNivelDeAcesso? nivelAcesso = null;

     
        [Description("Nivel de acesso do botão"), Category("Definição")]
        public EnumNivelDeAcesso? NivelDeAcesso
        {
            get { return nivelAcesso; }
            set { nivelAcesso = value; }
        }

        public ToolStripMenuItemCC()
        {
            this.ForeColor = LayoutManager.corTextoStrip;
        }
    }
}
