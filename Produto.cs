/*
Paulo Meneses 
17611

Trabalho Prático LPII

desc:
Classe Produto

 */
using System;

namespace TrabalhoPratico
{
    [Serializable]
    class Produto
    {
        #region Atributos
        string nome;
        int cod;
        double preco;
        #endregion
        #region Construtor

        /// <summary>
        /// Construtor de um produto
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <param name="cod">Codigo do produto</param>
        /// <param name="preco">Preço do produto</param>
        public Produto(string nome,int cod,double preco)
        {
            this.nome = nome;
            this.cod = cod;
            this.preco = preco;
        }

        #endregion

        #region Propriedades
        
        /// <summary>
        /// Manipula o codigo do produto
        /// </summary>
        public int Cod
        {
            get{ return cod; }
            set { cod = value; }
        }

        /// <summary>
        /// Manipula o nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Manipula o preço
        /// </summary>
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        #endregion
        #region Operadores

        public static bool operator ==(Produto a,Produto b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Produto a, Produto b)
        {
            return !(a == b);
        }

        #endregion

        #region Overrrides

        public override string ToString()
        {
            return "Codigo: " + cod + " Produto: " + nome + " Preço: " + preco + " $ ";
        }

        public override bool Equals(object obj)
        {
            Produto aux = (Produto)obj;
            return this.cod == aux.cod || this.nome.CompareTo(aux.nome) == 0;
        }

        #endregion

    }
}
