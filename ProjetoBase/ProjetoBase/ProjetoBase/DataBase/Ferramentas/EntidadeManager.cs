using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ProjetoBase.DataBase.Dominio.Interface;

namespace ProjetoBase.DataBase.Ferramentas
{
    public static class EntidadeManager
    {

        public static void forcarLoad(object objeto, int IndiceMaximo)
        {
            //loadObjeto(objeto, 0, IndiceMaximo);
        }

        private static void loadObjeto(object objeto, int indiceObjeto, int IndiceMaximo)
        {
            int indice = indiceObjeto + 1;


            try
            {
                PropertyInfo[] props = objeto.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object obj = prop.GetValue(objeto, null);

                        if (indice < IndiceMaximo && obj is Entidade)
                        {
                            loadObjeto(obj, indice, IndiceMaximo);
                        }
                        else if (indice < IndiceMaximo && (prop.PropertyType.Name.Contains("ISet") || obj is System.Collections.IEnumerable))
                        {
                            foreach (object objetoLista in (IEnumerable)obj)
                            {
                                if (objetoLista is Entidade)
                                {
                                    loadObjeto(objetoLista, indice, IndiceMaximo);
                                }
                            }
                        }

                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }


    }
}
