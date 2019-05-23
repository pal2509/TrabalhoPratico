/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */

 /*
  Relatório:
    Problema
    Abordagem:
        Classes
        Diagrama de classes 
        Estrutura dados
    Observações       
  */

using System;
using System.Collections.Generic;

namespace TrabalhoPratico
{
    class Program
    {
        static void Main(string[] args)
        {



            Restaurante R = new Restaurante("Brasas", 253867463, 10,40);
            Dados.Load(R);

            #region Testes
            //R.AddProduto(new Produto("Agua 1L", 124, 1.55));
            //R.AddProduto(new Produto("Agua 1L", 124, 1.55));
            //R.AddProduto(new Produto("Pao", 567, 0.10));
            //R.AddProduto(new Produto("Coca-Cola", 456, 2));
            //R.AddProduto(new Produto("Bacalhau", 847, 15));
            //R.AddProduto(new Produto("Vitela", 756, 12));
            //R.AddProduto(new Produto("Frango", 432, 8));
            //R.AddProduto(new Produto("Sopa", 42, 3.75));

            //R.MostraEmenta();

            //Cliente c1 = new Cliente("Paulo", 9437262);
            //Cliente c2 = new Cliente("Paulo", 9437262);
            //Cliente c3 = new Cliente("Jose", 8913713);
            //Cliente c4 = new Cliente("Manuel", 9547722);

            //Console.WriteLine(c1.ToString());
            //Console.WriteLine(c2.ToString());
            //Console.WriteLine(c3.ToString());
            //Console.WriteLine(c4.ToString());


            //R.AddCliente(c1);
            //R.AddCliente(c2);
            //R.AddCliente(c3);
            //R.AddCliente(c4);
            //R.MostraClientes();
            //Dados.Guardar(R);

            //Refeicao e1 = new Refeicao(c1.numCli, 124, 567, 847, 42);
            //Refeicao e2 = new Refeicao(c1.numCli, 124, 567, 847, 42);
            //Refeicao e3 = new Refeicao(c3.numCli, 124, 432, 756, 42);
            //Refeicao e4 = new Refeicao(c3.numCli, 456, 567, 847, 432);

            //Console.WriteLine(e1.ToString());

            //R.AddReficao(e1);
            //R.AddReficao(e2);
            //R.AddReficao(e3);
            //R.AddReficao(e4);
            //R.MostraRefeicoes();

            //Reserva t1 = new Reserva(c1.Telefone, 6, new DateTime(2019, 06, 10, 18, 30, 00));
            //Reserva t2 = new Reserva(c1.Telefone, 6, new DateTime(2019, 06, 10, 18, 30, 00));
            //Reserva t3 = new Reserva(c1.Telefone, 3, new DateTime(2019, 05, 11, 12, 30, 00));
            //Reserva t4 = new Reserva(c2.Telefone, 6, new DateTime(2019, 06, 10, 19, 30, 00));
            //Reserva t5 = new Reserva(c2.Telefone, 5, new DateTime(2019, 06, 10, 19, 00, 00));
            //Reserva t6 = new Reserva(c3.Telefone, 4, new DateTime(2019, 06, 10, 19, 10, 00));
            //Reserva t7 = new Reserva(c4.Telefone, 10, new DateTime(2019, 06, 10, 18, 40, 00));
            //Reserva t8 = new Reserva(c3.Telefone, 12, new DateTime(2019, 06, 20, 13, 30, 00));


            //R.AddReserva(t1);
            //R.AddReserva(t2);
            //R.AddReserva(t3);
            //R.AddReserva(t4);
            //R.AddReserva(t5);
            //R.AddReserva(t6);
            //R.AddReserva(t7);
            //R.AddReserva(t8);
            //Console.WriteLine("Reservas:");
            //R.MostaReservas();

            #endregion

            int op = 1;

            while (op != -1)
            {

                Console.WriteLine("Menu:");
                Console.WriteLine("1-Adicionar Cliente");
                Console.WriteLine("2-Adicionar Reserva");
                Console.WriteLine("3-Adicionar Refeição");
                Console.WriteLine("4-Gestão do restaurante "+R.NomeRes);
                Console.WriteLine("5-Lista dos Clientes");
                Console.WriteLine("6-Lista das Refeições");
                Console.WriteLine("7-Lista de Reservas");
                Console.WriteLine("8-Lista ementa");
                Console.WriteLine("9-Procurar");
                Console.WriteLine("0-Sair");
                Console.WriteLine("Opção?");

                try
                {

                    op = GereExceptoes.NovoInteiro(Console.ReadLine());

                    if (GereExceptoes.MaiorZero(op) == true)
                    {

                        switch (op)
                        {
                            case 0:
                                Dados.Guardar(R);
                                op = -1;
                                break;
                            case 1:
                                try
                                {
                                    string nome;
                                    int telefone;
                                    Console.WriteLine("Nome do Cliente:");
                                    nome = Console.ReadLine();

                                    Console.WriteLine("Numero de telefone:");
                                    telefone = GereExceptoes.NovoInteiro(Console.ReadLine());
                                    bool resp = R.AddCliente(new Cliente(nome, telefone));
                                    if (resp == true) Console.WriteLine("Adicionado com sucesso.");
                                    else Console.WriteLine("Cliente já existente.");
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    break;
                                }

                            case 2:
                                try
                                {
                                    DateTime data;
                                    Console.WriteLine("Data da Reserva(Ano/Mes/Dia Hora:Minuto): ");
                                    data = GereExceptoes.NovaData(Console.ReadLine());

                                    Console.WriteLine("Numero de pessoas:");
                                    int n = GereExceptoes.NovoInteiro(Console.ReadLine());

                                    Console.WriteLine("Numero de telefone:");
                                    int num = GereExceptoes.NovoInteiro(Console.ReadLine());

                                    int resp = R.AddReserva(new Reserva(num, n, data));
                                    if (resp == 1)
                                    {
                                        Console.WriteLine("Adicionado com sucesso!!!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não adicionado.");
                                        break;
                                    } 
                                    
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    break;
                                }
                            case 3:
                                try
                                {
                                    Console.WriteLine("Numero do Cliente:");
                                    int num = GereExceptoes.NovoInteiro(Console.ReadLine());
                                    bool resp;
                                    resp = R.ExisteCliente(num);
                                    if (resp == false)
                                    {
                                        Console.WriteLine("Cliente não existe!!!");
                                        break;
                                    }
                                    Console.WriteLine("Codigos dos produtos(zero para parar de inserir):");
                                    int n = 1;
                                    List<int> codigo = new List<int>();
                                    n = GereExceptoes.NovoInteiro(Console.ReadLine());
                                    while (n != 0)
                                    {
                                        codigo.Add(n);
                                        n = GereExceptoes.NovoInteiro(Console.ReadLine());
                                    }
                                    resp = R.AddReficao(new Refeicao(num, codigo));
                                    if (resp == true)
                                    {
                                        Console.WriteLine("Adiconado com sucesso.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não adicionado.");
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    break;
                                }


                            case 4:
                                int j = -1;
                                while (j != 0)
                                {
                                    try
                                    {
                                        Console.WriteLine("Opção: ");
                                        Console.WriteLine("1-Mostra funcionarios");
                                        Console.WriteLine("2-Adicionar funcionario");
                                        Console.WriteLine("3-Adicionar produto");
                                        Console.WriteLine("0-Voltar");
                                        j = GereExceptoes.NovoInteiro(Console.ReadLine());

                                        switch (j)
                                        {
                                            case 1:
                                                Console.WriteLine("Lista de Funcionários: ");
                                                R.MostraFuncionario();
                                                break;
                                            case 2:
                                                try
                                                {
                                                    Console.WriteLine("Nome do funcionario:");
                                                    string m = Console.ReadLine();
                                                    Console.WriteLine("Numero de telefone:");
                                                    int tel = GereExceptoes.NovoInteiro(Console.ReadLine());
                                                    Console.WriteLine("Função?");
                                                    Console.WriteLine("1-" + Funcao.Gerente.ToString());
                                                    Console.WriteLine("2-" + Funcao.EmpregadoMesa.ToString());
                                                    Console.WriteLine("3-" + Funcao.Cozinheiro.ToString());
                                                    Console.WriteLine("4-" + Funcao.Balcao.ToString());
                                                    Console.WriteLine("5-" + Funcao.AjudanteCozinha.ToString());
                                                    int n1 = GereExceptoes.NovoInteiro(Console.ReadLine());
                                                    bool re = false;
                                                    if (n1 == 1) re = R.AddFuncionario(new Funcionario(m, tel, Funcao.Gerente));
                                                    if (n1 == 2) re = R.AddFuncionario(new Funcionario(m, tel, Funcao.EmpregadoMesa));
                                                    if (n1 == 3) re = R.AddFuncionario(new Funcionario(m, tel, Funcao.Cozinheiro));
                                                    if (n1 == 4) re = R.AddFuncionario(new Funcionario(m, tel, Funcao.Balcao)); 
                                                    if (n1 == 5) re = R.AddFuncionario(new Funcionario(m, tel, Funcao.AjudanteCozinha));
                                                    if (re == true) Console.WriteLine("Adicionado com sucesso.");
                                                    else Console.WriteLine("Não adicionado!!!");
                                                }
                                                catch(Exception e)
                                                {
                                                    Console.WriteLine(e);
                                                    break;
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("Nome do produto:");
                                                string nome = Console.ReadLine();
                                                Console.WriteLine("Preço:");
                                                int n = GereExceptoes.NovoInteiro(Console.ReadLine());
                                                Console.WriteLine("Codigo:");
                                                int cod = GereExceptoes.NovoInteiro(Console.ReadLine());

                                                bool resp=R.AddProduto(new Produto(nome, cod, n));
                                                if(resp==true)
                                                {
                                                    Console.WriteLine("Adicionado com sucesso.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Não adicionado!!!");
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e);
                                        j = -1;
                                    }
                                }
                                break;
                            case 5:
                                Console.WriteLine("Lista de clientes:");
                                R.MostraClientes();
                                break;
                            case 6:
                                Console.WriteLine("Lista das refieçõe:");
                                R.MostraRefeicoes();
                                break;
                            case 7:
                                Console.WriteLine("Lista das reservas:");
                                R.MostraReservas();
                                break;
                            case 8:
                                Console.WriteLine("Ementa:");
                                R.MostraEmenta();
                                break;
                            case 9:
                                int k = -1;
                                while(k!=0)
                                {
                                    try
                                    {
                                        Console.WriteLine("Opção: ");
                                        Console.WriteLine("1-Procurar Cliente");
                                        Console.WriteLine("2-Procurar Refeição");
                                        Console.WriteLine("3-Procurar Reserva");
                                        Console.WriteLine("0-Voltar");
                                        k = GereExceptoes.NovoInteiro(Console.ReadLine());

                                        switch (k)
                                        {
                                            case 1:
                                                Console.WriteLine("Numero de cliente ou telefone:");
                                                int n = GereExceptoes.NovoInteiro(Console.ReadLine());
                                                Cliente c;
                                                int resp = R.ProCliente(n, out c);
                                                if(resp==1)
                                                {
                                                    Console.WriteLine("Enconstrado.");
                                                    Console.WriteLine("Nome: " + c.Nome + " Telefone: " + c.Telefone + " Numero de cliente: " + c.numCli);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Não existe");
                                                }
                                                break;
                                            case 2:
                                                break;
                                            case 3:
                                                break;
                                        }
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e);
                                        k = -1;
                                    }
                                }
                                break;
                        }

                    }
                    else
                    {
                        op = 10;
                        Console.WriteLine("Opção não existe tente denovo");
                    }
                }
                catch (Exception e)
                {

                    op = 10;
                    Console.WriteLine("ERRO:", e);
                    Console.WriteLine("Opção invalida. Tente novamente.");
                }
                finally
                {
                    Dados.Guardar(R);
                }



            }


        }
    }
    
}
