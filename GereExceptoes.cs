/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */
using System;

namespace TrabalhoPratico
{
    class GereExceptoes
    {
        public static DateTime NovaData(string n)
        {
            try
            {
                return DateTime.Parse(n);
            }
            catch
            {
                throw new Exception("Data Ivalida!!!");           
            }
        }

        public static bool MaiorZero(int n)
        {
            if (n >= 0) return true;
            return false;
        }

        public static int NovoInteiro(string n)
        {
            try
            {
                if (int.Parse(n) >= 0) return int.Parse(n);
                else throw new Exception("Numero não é positivo!!!");
            }
            catch
            {
                throw new Exception("Não é um numero inteiro!!!");
            }
        }

        public static double NovoDouble(string n)
        {
            try
            {
                return double.Parse(n);
            }
            catch
            {
                throw new Exception("Não é um numero com duas casas decimais!!!");
            }
        }
    }
}
