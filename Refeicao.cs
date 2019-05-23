/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */

using System;
using System.Collections.Generic;

namespace TrabalhoPratico
{
    [Serializable]
    class Refeicao
    {
        #region Atributos
        int numClient;
        List<int> cod;
        DateTime hora;
        double custo;

        #endregion
        #region Construtor
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Refeicao()
        {
            numClient = -1;
            cod = new List<int>();
            hora = DateTime.Now;
            custo = -1;
            
        }

        /// <summary>
        /// Construtor de uma redeição
        /// </summary>
        /// <param name="cli">Numero de cliente</param>
        /// <param name="codigo">Array de codigos dos produtos da ementa que foram consumidos</param>
        public Refeicao(int cli,params int[]codigo)
        {
            numClient = cli;
            hora = DateTime.Now;
            custo = -1;
            cod = CopiaCodigos(codigo);
        }

        /// <summary>
        /// Construtor de uma refeição
        /// </summary>
        /// <param name="cli">Numero de cliente</param>
        /// <param name="cod">Lista de Codigos</param>
        public Refeicao(int cli, List<int> cod)
        {
            numClient = cli;
            hora = DateTime.Now;
            custo = -1;
            this.cod = cod;
        }

        #endregion
        #region Propriedades
        /// <summary>
        /// Manipula o Cliente
        /// </summary>
        public int Cliente
        {
            get { return numClient;}
            set { numClient = value; }
        }
        
        /// <summary>
        /// Manipula o array de codigos dos produtos da refeição
        /// </summary>
        public List<int> Codigo
        {
            get { return cod; }
            set { cod = value;}
        }

        /// <summary>
        /// Manipula o horario da refeição
        /// </summary>
        public DateTime Horario
        {
            get { return hora; }
            set { hora = value; }
        }

        /// <summary>
        /// Manipula o custo da refeição
        /// </summary>
        public double Custo
        {
            get { return custo; }
            set { custo = value; }
        }

        #endregion
        #region Metodos

        public List<int> CopiaCodigos(int []cod)
        {
            List<int> z = new List<int>();
            foreach (int x in cod)
            {
                z.Add(x);
            }
            return z;
        }

        /// <summary>
        /// Calcula o custo da refieçao
        /// </summary>
        /// <param name="y">Array da ementa do restaurante</param>
        /// <param name="x">Array com os codigos dos produtos cosumidos</param>
        /// <returns>Retorna o Custo</returns>
        public double CalculaCusto(Produto []y,int []x)
        {
            double soma = 0;
            for(int i=0;i<x.Length;i++)
            {
                for(int j=0;j<y.Length;j++)
                {
                    if (x[i] == y[j].Cod) soma = soma + y[j].Preco;
                }
            }
            return soma;
        }
        #endregion
 
        #region Overrides

        public override string ToString()
        {
            return "Cliente: " + numClient + " Data: " + hora.ToString() + " Custo: " + custo;
        }
        
        public override bool Equals(object obj)
        {
            Refeicao aux = (Refeicao)obj;

            if (hora.Hour.CompareTo(aux.hora.Hour) == 0 && hora.Minute.CompareTo(aux.hora.Minute) == 0 && hora.Second.CompareTo(aux.hora.Second) == 0 && numClient == aux.numClient)
            {
                if (cod.ToArray().Length == aux.cod.ToArray().Length)
                {
                    int[] a = cod.ToArray();
                    int[] b = aux.cod.ToArray();
                    int cont = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        for (int j = 0; j < b.Length; j++)
                        {
                            if (cod[i] == aux.cod[j]) cont++;
                        }             
                    }
                    if (cont == a.Length) return true;
                    else return false;
                }
                else return false;
            }
            else return false;


            //return (hora.Hour.CompareTo(aux.hora.Hour) == 0 && hora.Minute.CompareTo(aux.hora.Minute) == 0 && hora.Second.CompareTo(aux.hora.Second) == 0 && c == aux.c && cod==aux.cod);
        }

        #endregion

    }
}
