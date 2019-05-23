using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    [Serializable]
    class Pessoa
    {
        #region Atributos
        string nome;
        int tel;
        #endregion
        #region Constructor

        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Pessoa()
        {
            nome= "";
            tel = -1;
        }

        /// <summary>
        /// Cria uma pessoa com nome e numero telefone
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="tel">Telefone</param>
        public Pessoa(string nome, int tel)
        {
            this.nome = nome;
            this.tel = tel;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Manipula o nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        /// <summary>
        /// Manipula o numero de telemovel
        /// </summary>
        public int Telefone
        {
            get { return tel; }
            set { this.tel = value; }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return "Nome: " + Nome + " Telefone: " + Telefone;
        }

        public override bool Equals(object obj)
        {
            Pessoa aux = (Pessoa)obj;
            return this.Nome.CompareTo(aux.Nome) == 0 && this.tel == aux.tel;
        }

        #endregion

    }
}
