/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */
using System;

namespace TrabalhoPratico
{
    /// <summary>
    /// Classe Reserva
    /// </summary>
    [Serializable]
    class Reserva
    {
        #region Atributos
        int tel;
        int numPessoas;
        DateTime horario;


        #endregion
        #region Construtor
        /// <summary>
        /// Cria uma reserva
        /// </summary>
        /// <param name="tel">Numero de telefone</param>
        /// <param name="numpes">Numero de pessoas</param>
        /// <param name="h">AA/MM/DD HH:MM:SS</param>
        public Reserva(int tel,int numpes,DateTime h)
        {
            this.tel = tel;
            numPessoas = numpes;
            horario = h;
        }
        #endregion
        #region Propriedades

        /// <summary>
        /// Manipula a ementa
        /// </summary>
        public int numPessoa
        {
            get { return numPessoas; }
            set { numPessoas = value; }
        }

        public int Telefone
        {
            get { return tel; }
            set { tel = value; }
        }

        public DateTime Horario
        {
            get { return horario ; }
            set { horario = value; }
        }

        #endregion
        #region Overrides

        public override bool Equals(object obj)
        {
            Reserva aux = (Reserva)obj;
            return tel == aux.tel && horario.CompareTo(aux.horario) == 0;
        }

        public override string ToString()
        {
            return ("Cliente: " + tel + " Horario: " + horario);
        }

 

        #endregion
    }
}
