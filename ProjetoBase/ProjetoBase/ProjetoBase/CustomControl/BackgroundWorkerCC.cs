using ProjetoBase.CustomControl.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjetoBase.CustomControls
{
    public class BackgroundWorkerCC : BackgroundWorker
    {
        InterfaceMenu menuInterface;
        Boolean atualizacaoPendente = false;

        public BackgroundWorkerCC()
        {

        }

        public void setMenu(InterfaceMenu menuInterface)
        {
            this.menuInterface = menuInterface;
            DoWork += menuInterface.backgroundWorkerUpdate_DoWork;
            RunWorkerCompleted += BackgroundWorkerUpdate_RunWorkerCompleted;
        }

        public void setAtualizacaoPendente()
        {
            atualizacaoPendente = true;
        }

        private void BackgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MenuCC menuCC = (MenuCC)menuInterface;
            if (atualizacaoPendente)
            {
                //menuCC.update();
                atualizacaoPendente = false;
            }
           // menuCC.zerarProgressBar();
        }

    
    }
}
