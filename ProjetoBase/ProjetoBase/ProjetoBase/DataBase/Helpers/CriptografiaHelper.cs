using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ProjetoBase.Ferramentas
{
    public static class CriptografiaHelper
    {
        // Método para gerar o hash de uma senha (mão única)
        public static string GerarHash(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Método para verificar se uma senha digitada corresponde a um hash salvo
        public static bool VerificarSenha(string senhaDigitada, string hashSalvo)
        {
            if (string.IsNullOrEmpty(senhaDigitada) || string.IsNullOrEmpty(hashSalvo))
                return false;

            string hashDaSenhaDigitada = GerarHash(senhaDigitada);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashDaSenhaDigitada, hashSalvo) == 0;
        }

        // --- MÉTODOS DE CRIPTOGRAFIA REVERSÍVEL PARA A CONNECTION STRING ---

        /// <summary>
        /// Criptografa um texto usando a chave de utilizador do Windows. Reversível.
        /// </summary>
        public static string Criptografar(string textoPuro)
        {
            if (string.IsNullOrEmpty(textoPuro))
                return string.Empty;

            byte[] dados = Encoding.Unicode.GetBytes(textoPuro);
            byte[] dadosCriptografados = ProtectedData.Protect(dados, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(dadosCriptografados);
        }

        /// <summary>
        /// Descriptografa um texto. Se a descriptografia falhar, assume que o texto já está em formato puro.
        /// </summary>
        public static string Descriptografar(string textoCriptografado)
        {
            if (string.IsNullOrEmpty(textoCriptografado))
                return string.Empty;

            textoCriptografado = textoCriptografado.Trim();

            try
            {
                // Verifica se a string é Base64 antes de tentar converter
                if (IsBase64String(textoCriptografado))
                {
                    byte[] dadosCriptografados = Convert.FromBase64String(textoCriptografado);
                    byte[] dadosDescriptografados = ProtectedData.Unprotect(dadosCriptografados, null, DataProtectionScope.CurrentUser);
                    return Encoding.Unicode.GetString(dadosDescriptografados);
                }
                else
                {
                    // Se não for Base64, assume que já é texto puro
                    return textoCriptografado;
                }
            }
            catch (CryptographicException)
            {
                // Caso ocorra erro de descriptografia, retorna o texto original
                return textoCriptografado;
            }
        }

        private static bool IsBase64String(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length % 4 != 0)
                return false;

            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

