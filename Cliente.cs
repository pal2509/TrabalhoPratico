/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */



using System;

namespace TrabalhoPratico
{
    [Serializable]
    class Cliente:Pessoa
    {
        #region Estado
        int numCliente;
        #endregion
        
        #region Construtor

        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Cliente():base()
        { 
            numCliente = -1;
        }

        /// <summary>
        /// Construtor de um Cliente
        /// </summary>
        /// <param name="nome">Nome do Cliente</param>
        /// <param name="tel">Numero de telemovel</param>
        public Cliente(string nome,int tel):base(nome,tel)
        {
            this.numCliente = -1;
        }

        
        #endregion
        #region Propriedades
        

        /// <summary>
        /// Manipula o numero de cliente
        /// </summary>
        public int numCli
        {
            get { return numCliente; }
            set { numCliente = value; }
        }

        #endregion
        #region Metodos



        #endregion

        #region Operadores

        public static bool operator ==(Cliente x,Cliente y)
        {
            return (x.Equals(y));
        }

        public static bool operator !=(Cliente x, Cliente y)
        {
            return (!(x==y));
        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return string.Format("Nome: {0} Telemovel: {1} NumCliente: {2} ", Nome, Telefone, numCli);

        }

        public override bool Equals(object obj)
        {
            Cliente aux = (Cliente)obj;
            return (this.numCliente == aux.numCliente || base.Equals(aux));
        }
        #endregion



    }

}
