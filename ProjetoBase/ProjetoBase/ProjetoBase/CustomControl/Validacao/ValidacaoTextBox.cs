using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Enumeradores;

namespace ProjetoBase.CustomControls.Validacao
{
    public static class ValidacaoTextBox
    {
        public static Boolean valido(String valor, TipoTextBox tipoTextBox)
        {
            Boolean valido = false;
            valor = getText(valor);
            switch (tipoTextBox)
            {
                case TipoTextBox.Cep:
                    if (valor.Length == 8)
                    {
                        valido = true;
                    }
                    break;
                case TipoTextBox.Cnpj:
                    if (valor.Length == 14)
                    {
                        valido = true;
                    }
                    break;
                case TipoTextBox.Cpf:
                    if (valor.Length == 11)
                    {
                        valido = true;
                    }
                    break;
                case TipoTextBox.Data:
                    if (valor.Length == 8)
                    {
                        try
                        {
                            String dia = valor[0].ToString() + valor[1].ToString();
                            String mes = valor[2].ToString() + valor[3].ToString();
                            String ano = valor[4].ToString() + valor[5].ToString() + valor[6].ToString() + valor[7].ToString();
                            new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
                            valido = true;
                        }
                        catch
                        {

                        }
                    }
                    break;
                case TipoTextBox.Hora:
                    if (valor.Length == 6)
                    {
                        try
                        {
                            String hora = valor[0].ToString() + valor[1].ToString();
                            String minuto = valor[2].ToString() + valor[3].ToString();
                            String segundo = valor[4].ToString() + valor[5].ToString();
                            new DateTime(0, 0, 0, Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                            valido = true;
                        }
                        catch
                        {

                        }
                    }
                    break;
                case TipoTextBox.DataHora:                   
                        try
                        {
                            String valorDataHora = valor.Replace("/", "").Replace(":", "").Replace("_", "").Replace(" ", "");
                            if (valorDataHora.Length >= 8)
                            {
                                if (valorDataHora != null && valorDataHora != "")
                                {
                                    valorDataHora = valorDataHora.PadRight(14, '0');
                                }

                                String dia = valorDataHora[0].ToString() + valorDataHora[1].ToString();
                                String mes = valorDataHora[2].ToString() + valorDataHora[3].ToString();
                                String ano = valorDataHora[4].ToString() + valorDataHora[5].ToString() + valorDataHora[6].ToString() + valorDataHora[7].ToString();

                                String hora = valorDataHora[8].ToString() + valorDataHora[9].ToString();
                                String minuto = valorDataHora[10].ToString() + valorDataHora[11].ToString();
                                String segundo = valorDataHora[12].ToString() + valorDataHora[13].ToString();
                                new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia), Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                            }

                            valido = true;
                        }
                        catch
                        {

                        }
                    
                    break;
                case TipoTextBox.Telefone:
                    if (valor.Length >= 10)
                    {
                        valido = true;
                    }
                    break;
                case TipoTextBox.Texto:
                    valido = true;
                    break;
            }
            return valido;
        }

        public static String getText(String valor)
        {
            valor = valor.Replace(" ", "");
            valor = valor.Replace(".", "");
            valor = valor.Replace("-", "");
            valor = valor.Replace("/", "");
            valor = valor.Replace("(", "");
            valor = valor.Replace(")", "");
            valor = valor.Replace(":", "");
            return valor;
        }
    }
}
