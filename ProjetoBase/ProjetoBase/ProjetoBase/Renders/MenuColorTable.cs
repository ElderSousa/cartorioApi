using System.Drawing;
using System.Windows.Forms;

namespace ProjetoBase.Renderers // Ou o namespace da sua preferência
{
    public class MenuColorTable : ProfessionalColorTable
    {
        // --- CORES QUE PODE PERSONALIZAR ---
        private Color menuFundo = Color.FromArgb(45, 45, 48);
        private Color itemSelecionado = Color.FromArgb(60, 60, 60);
        private Color corBorda = Color.FromArgb(80, 80, 80);
        private Color corSeparador = Color.FromArgb(80, 80, 80);

        // --- Mapeamento das propriedades de cor ---
        public override Color ToolStripDropDownBackground => menuFundo;
        public override Color MenuStripGradientBegin => menuFundo;
        public override Color MenuStripGradientEnd => menuFundo;
        public override Color MenuItemSelected => itemSelecionado;
        public override Color MenuItemBorder => itemSelecionado;
        public override Color MenuBorder => corBorda;
        public override Color SeparatorDark => corSeparador;
        public override Color ImageMarginGradientBegin => menuFundo;
        public override Color ImageMarginGradientMiddle => menuFundo;
        public override Color ImageMarginGradientEnd => menuFundo;
    }
}