using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoBase.Ferramentas
{
    public static class CriptografiaHelper
    {
        // Método para gerar o hash de uma senha
        public static string GerarHash(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            // Usamos o algoritmo SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a senha em um array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Converte o array de bytes em uma string hexadecimal
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

            // Gera o hash da senha que o usuário digitou agora
            string hashDaSenhaDigitada = GerarHash(senhaDigitada);

            // Compara os dois hashes de forma case-insensitive
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashDaSenhaDigitada, hashSalvo) == 0;
        }
    }
}