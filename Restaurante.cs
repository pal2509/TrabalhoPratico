/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */


using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TrabalhoPratico
{
    [Serializable]
    class Restaurante
    {

        #region Atributos

        string nomeRest;
        int numTel;
        int numMesas;
        int maxPessoas;
        List<Produto> ementa = new List<Produto>();
        const string fileEmenta = "Ementa.bin";

        #region Clientes

        const string fileClientes = "Clientes.bin";
        List<Cliente> lista = new List<Cliente>();
       
        #endregion
        #region Refeições
        const string fileRefeicoes = "Refeicoes.bin";
        List<Refeicao> refeicoes = new List<Refeicao>();

        #endregion
        #region Reservas
        const string fileReservas = "Reservas.bin";
        List<Reserva> reser = new List<Reserva>();

        #endregion
        #region Empregados
        const string fileEmpregados = "Empregados.bin";
        List<Funcionario> empregados = new List<Funcionario>();

        #endregion
        #endregion
        #region Construtor Restaurante

        /// <summary>
        /// Construtor para o Restaurante
        /// </summary>
        /// <param name="nome">Nome do Restaurante</param>
        /// <param name="tel">Numero de telefone</param>
        /// <param name="numMesa">Numero de mesas</param>
        public Restaurante(string nome,int tel,int numMesa,int maxPes)
        {
            nomeRest = nome;
            numTel = tel;
            numMesas = numMesa;
            maxPessoas = maxPes;
        }


        #endregion

        #region Propriedades

        public string NomeRes
        {
            get { return nomeRest; }
        }

        /// <summary>
        /// Retorna o um array com a ementa
        /// </summary>
        public Produto[]Ementa
        {
            get { return ementa.ToArray(); }
           
        }

        public List<Cliente> Clientes
        {
            get { return lista; }
            set { lista = value; }
        }


        public List<Refeicao> Refeicaos
        {
            get { return refeicoes; }
            set { refeicoes = value; }
        }

        public List<Reserva> Reservas
        {
            get { return reser; }
            set { reser = value; }
        }

        public List<Produto> Produtos
        {
            get { return ementa; }
            set { ementa = value; }
        }

        public List<Funcionario> Funcionarios
        {
            get { return empregados; }
            set { empregados = value; }
        }

        public string fileNameClientes
        {
            get { return fileClientes; }
        }

        public string fileNameReservas
        {
            get { return fileReservas; }
        }

        public string fileNameReficoes
        {
            get { return fileRefeicoes; }
        }

        public string fileNameEmenta
        {
            get { return fileEmenta; }
        }

        public string fileNameEmpregados
        {
            get { return fileEmpregados; }
        }
        #endregion

        #region Metodos
        #region Preçario

        /// <summary>
        /// Adiciona um produto á ementa do restaurante
        /// </summary>
        /// <param name="x">Produto</param>
        /// <returns></returns>
        public bool AddProduto(Produto x)
        {
            if (ementa.Contains(x)==false)
            {
                ementa.Add(x);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Mostra a ementa do restaurante
        /// </summary>
        public void MostraEmenta()
        {
            foreach(Produto p in ementa)
            {
                Console.WriteLine(p.ToString());
            }
        }

        #endregion

        #region Clientes
        /// <summary>
        /// Adiciona um cliente
        /// </summary>
        /// <param name="c">Cliente</param>
        /// <returns>True se iseriu ou false se ja existe</returns>
        public bool AddCliente(Cliente c)
        {
            if (lista.Contains(c) == false)
            {
                lista.Add(c);
                c.numCli = GeraNumCliente();
                return true;
                        
            }
            return false;
        }

        /// <summary>
        /// Gera um numero de cliente
        /// </summary>
        /// <returns>Retorna um inteiro enre 1000 e 10 000</returns>
        public int GeraNumCliente()
        {
            int n = GeraInt();
            Cliente[] cli = lista.ToArray();
            bool x = false;
            for(int i=0;i<cli.Length;i++)
            {
                if (n == cli[i].numCli) x = true;
            }
            if (x == true) return n = GeraNumCliente();
            else return n;
        }

        /// <summary>
        /// Gera um numrero interio positivo entre 1000 e 10 000
        /// </summary>
        /// <returns>Retorna o numero gerado</returns>
        int GeraInt()
        {
            Random rng = new Random();
            int n = rng.Next(1000, 10000);
            return n;
        }

        /// <summary>
        /// Lista de todos os clientes do restaurante
        /// </summary>
        public void MostraClientes()
        {
            foreach (Cliente c in lista)
            {
                Console.WriteLine(c.ToString());
            }
        }

        /// <summary>
        /// Calcula o dinheiro gasto de um dado cliente 
        /// </summary>
        /// <param name="n">Numero do cliente</param>
        /// <returns>Total do dinheiro gasto</returns>
        public double TotalGastoCliente(int n)
        {
            double soma = 0;
            Refeicao[] x = refeicoes.ToArray();
            for(int i=0;i<x.Length;i++)
            {
                if (n == x[i].Cliente) soma = soma + x[i].Custo;
            }
            return soma;
        }

        /// <summary>
        /// Procura um cliente atraves do numero de cliente na lista de clientes
        /// </summary>
        /// <param name="num">Numero do cliente</param>
        /// <param name="c">Retorna o Cliente</param>
        /// <returns>Verdadeiro se existe e falso se nao existe</returns>
        public bool ProcuraCliente(int num,out Cliente c)
        {    
            Cliente[] x = lista.ToArray();
            for(int i=0;i<x.Length;i++)
            {
                if (x[i].numCli == num)
                { 
                    c = x[i];
                    return true;
                }
               
            }
            c = new Cliente();
            return false ;
        }

        /// <summary>
        /// Procura cliente pelo numero de cliente ou pelo o numero de telefone
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int ProCliente(int n,out Cliente c)
        {
            Cliente[] x = lista.ToArray();
            for(int i=0;i<x.Length;i++)
            {
                if (x[i].numCli == n || x[i].Telefone == n) 
                {
                    c = x[i];
                    return 1;
                }    
            }
            c = new Cliente();
            return 0;
        }

        /// <summary>
        /// Verifica se o cliente existe no restaurante pelo numero de cliente
        /// </summary>
        /// <param name="num">Numero de cliente</param>
        /// <returns></returns>
        public bool ExisteCliente(int num)
        {
            Cliente[] c = lista.ToArray();
            for(int i=0;i<c.Length;i++)
            {
                if (c[i].numCli == num) return true;
            }
            return false;
        }

        #endregion

        #region Refeições

        /// <summary>
        /// Adiciona uma refeiçao 
        /// </summary>
        /// <param name="x">Refeição</param>
        /// <returns>true se adicionar e false se nao adicionar</returns>
        public bool AddReficao(Refeicao x)
        {
            if (x.Cliente == -1) return false;
            else
            {
                if (refeicoes.Contains(x) == false)
                {
                    x.Custo = CalculaCusto(x.Codigo.ToArray());
                    refeicoes.Add(x);
                    return true;
                }
                else return false;
            }
            
        }

        public double CalculaCusto(int []cod)
        {
            double soma = 0;
            Produto[] emen = ementa.ToArray();
            for (int i = 0; i < cod.Length; i++) 
            {
                for(int j=0;j<emen.Length;j++)
                {
                    if (cod[i] == emen[j].Cod) soma = soma + emen[j].Preco;
                }
            }
            return soma;

        }


        /// <summary>
        /// Calcula a media do custo de todas as refeições do restaurante
        /// </summary>
        /// <returns></returns>
        public double MediaCustoRefeicoes()
        {
            int cont = 0;
            double soma = 0;
            foreach(Refeicao r in refeicoes)
            {
                if (r.Custo > 0)
                {
                    soma = soma + r.Custo;
                    cont++;
                }
            }
            if (cont != 0)
            {
                return soma / cont;
            }
            else return 0;
        }


        /// <summary>
        /// Lista todas a refeições
        /// </summary>
        public void MostraRefeicoes()
        {
            foreach(Refeicao x in refeicoes)
            {
                Console.WriteLine(x.ToString());
            }
        }


        #endregion

        #region Reservas

        /// <summary>
        /// Adiciona uma reserva 
        /// </summary>
        /// <param name="t">Reserva</param>
        /// <returns>Retorna 1 se adicionar, 0 se já houver muitas reservas naquela hora e -1 se ja existe uma reserva igual</returns>
        public int AddReserva(Reserva t)
        {
            if(reser.Contains(t)==false)
            {
                if (VerificaData(t.Horario) < 5)
                {
                    reser.Add(t);
                    reser.Sort(new ReservaComp());
                    return 1;
                }
                return 0;
            }
            return -1;
            
        }

        

        /// <summary>
        /// Verifica quantas reservas existe +30 e -30 minutos de uma determinada hora
        /// </summary>
        /// <param name="h">hora da reseva</param>
        /// <returns>Numero de revervas</returns>
        int VerificaData(DateTime h)
        {
            Reserva[] x = reser.ToArray();

            int cont = 0;
            for(int i=0;i<x.Length;i++)
            {
                DateTime y = x[i].Horario;
                TimeSpan dif = h - y;
                if (dif < new TimeSpan(0, 30, 0)) cont++;
            }
            return cont;
        }

        /// <summary>
        /// Mostra a lista das reservas
        /// </summary>
        public void MostraReservas()
        {
            foreach (Reserva c in reser)
            {
                Console.WriteLine(c.ToString());
            }
        }

        #endregion

        #region Empregados

        /// <summary>
        /// Adiciona um funcionario ao restaurante
        /// </summary>
        /// <param name="f">Funcionario</param>
        /// <returns>True/false</returns>
        public bool AddFuncionario(Funcionario f)
        {
            if(empregados.Contains(f)==false)
            {
                empregados.Add(f);
                f.Empregado = GeraNumFunci();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gera um numero para o empregado
        /// </summary>
        /// <returns>Numero interio entre 1000 e 10 000</returns>
        public int GeraNumFunci()
        {
            int n = GeraInt();
            Funcionario []f = empregados.ToArray();
            bool x = false;
            for (int i = 0; i < f.Length; i++)
            {
                if (n == f[i].Empregado) x = true;
            }
            if (x == true) return n = GeraNumCliente();
            else return n;
        }

        /// <summary>
        /// Mostra os empregados do restaurante
        /// </summary>
        public void MostraFuncionario()
        {

            foreach(Funcionario f in empregados)
            {
                Console.WriteLine(f.ToString());
            }
        }

        #endregion
        #endregion


    }
}
