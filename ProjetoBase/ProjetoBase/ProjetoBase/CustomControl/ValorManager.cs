using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoBase.CustomControls.Input
{
    public static class ValorManager
    {
        //----------------------------------------------MOEDA---------------------------------------------------------------------
        static public String valor_press_moeda(char ch, String valorAtual, Boolean permitirValorNegativo)
        {
            if (Char.IsDigit(ch))
            {
                if (valorAtual == "")
                {
                    valorAtual = "+000";
                }

                char charTipo = valorAtual[0];
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");
                valorAtual = valorAtual.Trim('+', '-', 'R', '$', ' ');


                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }
                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return charTipo + "R$ " + valorRetorno;
            }
            else if (ch == '\b')
            {
                char charTipo = valorAtual[0];
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");
                valorAtual = valorAtual.Trim('+', '-', 'R', '$', ' ');


                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return charTipo + "R$ " + valorRetorno;
            }
            else if (ch == '+')
            {
                valorAtual = valorAtual.Replace('-', '+');
                return valorAtual;
            }
            else if (ch == '-')
            {
                if (permitirValorNegativo)
                {
                    valorAtual = valorAtual.Replace('+', '-');
                }
                return valorAtual;
            }
            else
            {
                return valorAtual;
            }
        }

        static public String formatarValorMoeda(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                if (valorDecimal >= 0)
                {
                    return "R$ " + valorDecimal.ToString("#,##0.00");
                }
                else
                {
                    return "-R$ " + valorDecimal.ToString("#,##0.00").Replace("-", "");
                }
            }
            else
            {
                return "R$ 0,00";
            }
        }

        static public String formatarValorMoedaTextBox(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                if (valorDecimal >= 0)
                {
                    return "+R$ " + valorDecimal.ToString("#,##0.00");
                }
                else
                {
                    return "-R$ " + valorDecimal.ToString("#,##0.00").Replace("-", "");
                }
            }
            else
            {
                return "+R$ 0,00";
            }
        }
        //----------------------------------------------MOEDA---------------------------------------------------------------------


        //----------------------------------------------COORDENADA---------------------------------------------------------------------
        static public String formatarValorCoordenada(Decimal valor)
        {
            if (valor != 0)
            {
                String valorString = valor.ToString().Replace("-", "");
                if ((valor < 10 && valor > 0) || (valor > -10 && valor < 0))
                {
                    valorString = "0" + valorString;
                }
                valorString = valorString.PadRight(9, '0');
                valorString = valorString.Replace(',', '.');
                return valorString;
            }
            else
            {
                return "00.000000";
            }
        }
        //----------------------------------------------COORDENADA---------------------------------------------------------------------


        //----------------------------------------------AREA---------------------------------------------------------------------
        static public String valor_press_area(char ch, String valorAtual)
        {
            valorAtual = valorAtual.TrimEnd('m', '²', ' ');
            if (Char.IsDigit(ch))
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                if (valorAtual == "")
                {
                    valorAtual = "000";
                }

                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }
                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno + " m²";
            }
            else if (ch == '\b')
            {
                valorAtual = valorAtual.TrimEnd('m', '²');
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno + " m²";
            }
            else
            {
                return valorAtual + " m²";
            }
        }

        static public String formatarValorArea(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                return valorDecimal.ToString("#,##0.00") + " m²";
            }
            else
            {
                return "0,00  m²";
            }
        }
        //----------------------------------------------AREA---------------------------------------------------------------------



        //----------------------------------------------PORCENTO---------------------------------------------------------------------
        static public String valor_press_porcento(char ch, String valorAtual)
        {
            valorAtual = valorAtual.TrimEnd('%', ' ');
            if (Char.IsDigit(ch))
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");


                if (valorAtual == "")
                {
                    valorAtual = "000";
                }

                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }
                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno + " %";
            }
            else if (ch == '\b')
            {
                valorAtual = valorAtual.TrimEnd('%');
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno + " %";
            }
            else
            {
                return valorAtual + " %";
            }
        }

        static public String formatarValorPorcento(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                return valorDecimal.ToString("#,##0.00") + " %";
            }
            else
            {
                return "0%";
            }
        }
        //----------------------------------------------AREA---------------------------------------------------------------------

        //----------------------------------------------VALOR DECIMAL---------------------------------------------------------------------
        static public String valor_press_decimal(char ch, String valorAtual)
        {
            if (Char.IsDigit(ch))
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                if (valorAtual == "")
                {
                    valorAtual = "0000";
                }

                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual.Length == 4)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual.Length == 4)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual.Length == 4)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }
                else if (valorAtual[valorAtual.Length - 4] == '0' && valorAtual.Length == 4)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 4, 1);
                }
                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 3);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 3);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else if (ch == '\b')
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");


                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2 || valorRetorno.Length == 3)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 3);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 3);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else
            {
                return valorAtual;
            }
        }

        static public String valor_press_decimal5casas(char ch, String valorAtual)
        {
            if (Char.IsDigit(ch))
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                if (valorAtual == "")
                {
                    valorAtual = "000000";
                }

                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual[valorAtual.Length - 5] == '0' && valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual[valorAtual.Length - 5] == '0' && valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual[valorAtual.Length - 4] == '0' && valorAtual[valorAtual.Length - 5] == '0' && valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }
                else if (valorAtual[valorAtual.Length - 4] == '0' && valorAtual[valorAtual.Length - 5] == '0' && valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 4, 1);
                }
                else if (valorAtual[valorAtual.Length - 5] == '0' && valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 5, 1);
                }
                else if (valorAtual[valorAtual.Length - 6] == '0' && valorAtual.Length == 6)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 6, 1);
                }

                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 5);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 5);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else if (ch == '\b')
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");


                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2 || valorRetorno.Length == 5)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 5);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 5);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else
            {
                return valorAtual;
            }
        }

        static public String valor_press_decimal2casas(char ch, String valorAtual)
        {
            if (Char.IsDigit(ch))
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");

                if (valorAtual == "")
                {
                    valorAtual = "000";
                }

                if (valorAtual[valorAtual.Length - 1] == '0' && valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 1);
                }
                else if (valorAtual[valorAtual.Length - 2] == '0' && valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 2, 1);
                }
                else if (valorAtual[valorAtual.Length - 3] == '0' && valorAtual.Length == 3)
                {
                    valorAtual = valorAtual.Remove(valorAtual.Length - 3, 1);
                }

                String valorRetorno = (valorAtual + ch);
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else if (ch == '\b')
            {
                valorAtual = valorAtual.Replace(".", "");
                valorAtual = valorAtual.Replace(",", "");


                String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                if (valorRetorno.Length == 2 || valorRetorno.Length == 2)
                {
                    valorRetorno = "0" + valorRetorno;
                }
                String valor1 = valorRetorno.Remove(valorRetorno.Length - 2);
                String valor2 = valorRetorno.Remove(0, valorRetorno.Length - 2);
                valorRetorno = pontuarValor(valor1) + "," + valor2;
                return valorRetorno;
            }
            else
            {
                return valorAtual;
            }
        }


        static public String valor_press_decimalLivre(char ch, String valorAtual)
        {
            if (Char.IsDigit(ch))
            {
                String valorRetorno = valorAtual + ch;
                return valorRetorno;
            }
            else if (ch == ',')
            {
                if (valorAtual.Contains(",") == false)
                {
                    String valorRetorno = valorAtual + ch;
                    return valorRetorno;
                }
                return valorAtual;
            }
            else if (ch == '\b')
            {
                if (valorAtual?.Length > 0)
                {
                    String valorRetorno = valorAtual.Remove(valorAtual.Length - 1);
                    return valorRetorno;
                }
                return valorAtual;
            }
            else
            {
                return valorAtual;
            }
        }

        static public String formatarValorDecimal(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                return valorDecimal.ToString("#,##0.000");
            }
            else
            {
                return "0,000";
            }
        }
        static public String formatarValorDecimal5Places(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                return valorDecimal.ToString("#,##0.00000");
            }
            else
            {
                return "0,00000";
            }
        }
        static public String formatarValorDecimal2Places(Decimal? valor)
        {
            if (valor != null)
            {
                Decimal valorDecimal = (Decimal)valor;
                return valorDecimal.ToString("#,##0.00");
            }
            else
            {
                return "0,00";
            }
        }
        //----------------------------------------------VALOR DECIMAL---------------------------------------------------------------------


        public static void digitCheck(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        public static String pontuarValor(String valor)
        {
            String valorPontuado = "0";
            if (valor.Length == 4)
            {
                valorPontuado = valor[0].ToString() + "." + valor[1].ToString() + valor[2].ToString() + valor[3].ToString();
            }
            else if (valor.Length == 5)
            {
                valorPontuado = valor[0].ToString() + valor[1].ToString() + "." + valor[2].ToString() + valor[3].ToString() + valor[4].ToString();
            }
            else if (valor.Length == 6)
            {
                valorPontuado = valor[0].ToString() + valor[1].ToString() + valor[2].ToString() + "." + valor[3].ToString() + valor[4].ToString() + valor[5].ToString();
            }
            else if (valor.Length == 7)
            {
                valorPontuado = valor[0].ToString() + "." + valor[1].ToString() + valor[2].ToString() + valor[3].ToString() + "." + valor[4].ToString() + valor[5].ToString() + valor[6].ToString();
            }
            else if (valor.Length == 8)
            {
                valorPontuado = valor[0].ToString() + valor[1].ToString() + "." + valor[2].ToString() + valor[3].ToString() + valor[4].ToString() + "." + valor[5].ToString() + valor[6].ToString() + valor[7].ToString();
            }
            else if (valor.Length == 9)
            {
                valorPontuado = valor[0].ToString() + valor[1].ToString() + valor[2].ToString() + "." + valor[3].ToString() + valor[4].ToString() + valor[5].ToString() + "." + valor[6].ToString() + valor[7].ToString() + valor[8].ToString();
            }
            else
            {
                valorPontuado = valor;
            }

            return valorPontuado;
        }


        public static int quantidadeDecimal(decimal n)
        {
            n = Math.Abs(n); //make sure it is positive.
            n -= (int)n;     //remove the integer part of the number.
            var decimalPlaces = 0;
            while (n > 0)
            {
                decimalPlaces++;
                n *= 10;
                n -= (int)n;
            }
            return decimalPlaces;
        }

    }
}
