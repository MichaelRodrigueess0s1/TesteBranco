using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Util
{
    public class Criptografia
    {
        ///<summary>
        /// Gera uma string codificada com base no algorítmo proprietário Cedro.
        ///</summary>
        public static string Cript(string senha)
        {
            string senhaResposta = null;
            int tam = 0;
            int ord = 0;

            char[] myChar = senha.ToUpper().ToCharArray();
            DateTime agora = DateTime.Now;

            ord = agora.Second;
            tam = senha.Length - 1;
            ord += tam;

            for (int j = 0; j <= tam; j++)
            {
                senhaResposta += (Convert.ToChar((byte)(myChar[j]) + ord).ToString() + (Convert.ToChar(ord + j)).ToString());
            }
            senhaResposta = senhaResposta + Convert.ToChar(ord);
            return senhaResposta;
        }
        ///<summary>
        /// Gera uma string codificada com base no algorítmo proprietário Cedro para compração
        /// com o AD.
        ///</summary>
        public static string CriptAD(string senha)
        {
            string senhaResposta = null;
            int tam = 0;
            int ord = 0;

            char[] myChar = senha.ToCharArray();
            DateTime agora = DateTime.Now;

            ord = agora.Second;
            tam = senha.Length - 1;
            ord += tam;

            for (int j = 0; j <= tam; j++)
            {
                senhaResposta += (Convert.ToChar((byte)(myChar[j]) + ord).ToString() + (Convert.ToChar(ord + j)).ToString());
            }
            senhaResposta = senhaResposta + Convert.ToChar(ord);
            return senhaResposta;
        }


        ///<summary>
        /// Decodifica uma string codifica com o algorítimo proprietário Cedro.
        ///</summary>
        public static string Uncript(string senha)
        {
            string senhaResposta = null;
            int tam = 0;
            int ord = 0;
            char[] myChar = senha.ToCharArray();
            try
            {
                tam = (senha.Length) - 2;
                ord = (byte)Convert.ToChar(senha.Substring(senha.Length - 1, 1));
                for (int j = 0; j <= tam; j++)
                {
                    if (j % 2 == 0)
                    {
                        senhaResposta += Convert.ToChar((int)(myChar[j] - ord));
                    }
                }
            }
            catch (Exception ex)
            {
                senhaResposta = ex.Message;
            }
            return senhaResposta;
        }

    }


}
