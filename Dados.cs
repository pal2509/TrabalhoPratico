/*
Paulo Meneses 
17611

Trabalho Prático LPII
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TrabalhoPratico
{
    class Dados
    {
        /// <summary>
        /// Carregas os dados de um restaurante para a memoria
        /// </summary>
        /// <param name="r">Restaurante</param>
        /// <returns></returns>
        public static bool Load(Restaurante r)
        {
            try
            {

                if (File.Exists(r.fileNameClientes))
                {
                    r.Clientes = ReadClientes(r.fileNameClientes);
                }
                if (File.Exists(r.fileNameEmenta))
                {
                    r.Produtos = ReadProdutos(r.fileNameEmenta);
                }
                if (File.Exists(r.fileNameReficoes))
                {
                    r.Refeicaos = ReadRefeicoes(r.fileNameReficoes);
                }
                if (File.Exists(r.fileNameReservas))
                {
                    r.Reservas = ReadReservas(r.fileNameReservas);
                }
                if(File.Exists(r.fileNameEmpregados))
                {
                    r.Funcionarios = ReadFuncionarios(r.fileNameEmpregados);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao carregar dados:", e);
            }
            
        }

        public static bool Guardar(Restaurante r)
        {
            try
            {
                Save(r.fileNameClientes, r.Clientes);
                Save(r.fileNameEmenta, r.Produtos);
                Save(r.fileNameReficoes, r.Refeicaos);
                Save(r.fileNameReservas, r.Reservas);
                Save(r.fileNameEmpregados, r.Funcionarios);
                return true;
                
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao guardar dados:", e);
            }
        }


        /// <summary>
        /// Guarda num ficheiro binario uma lista de Clientes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <param name="c">Lista</param>
        /// <returns></returns>
        public static bool Save(string fileName,List<Cliente> c)
        {
            try
            {
                using (Stream str = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(str, c);
                    str.Close();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception("ERRO-", e);
            }
        }

        /// <summary>
        /// Guarda num ficheiro binario uma lista de Reservas
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <param name="c">Lista</param>
        /// <returns></returns>
        public static bool Save(string fileName, List<Reserva> c)
        {
            try
            {
                using (Stream str = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(str, c);
                    str.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO-", e);
            }
        }

        /// <summary>
        /// Guarda num ficheiro binario uma lista de Refeiçoes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <param name="c">Lista</param>
        /// <returns></returns>
        public static bool Save(string fileName, List<Refeicao> c)
        {
            try
            {
                using (Stream str = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(str, c);
                    str.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO-", e);
            }
        }

        /// <summary>
        /// Guarda num ficheiro binario uma lista de produtos
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <param name="c">Lista</param>
        /// <returns></returns>
        public static bool Save(string fileName, List<Produto> c)
        {
            try
            {
                using (Stream str = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(str, c);
                    str.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO-", e);
            }
        }


        /// <summary>
        /// Guarda num ficheiro binario uma lista de funcionarios
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <param name="c">Lista</param>
        /// <returns></returns>
        public static bool Save(string fileName, List<Funcionario> c)
        {
            try
            {
                using (Stream str = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(str, c);
                    str.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO-", e);
            }
        }


        /// <summary>
        /// Lê um ficheiro binario e retorna uma lista de clientes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static List<Cliente> ReadClientes(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    List<Cliente> c;
                    using (Stream str = File.OpenRead(fileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (List<Cliente>)bf.Deserialize(str);
                    }
                    return c;
                }
                else
                {
                    throw new Exception("Ficheiro não existe!!!");
                }
            }
            catch(Exception e)
            {
                throw new Exception("ERRO:Nao foi possivel ler o ficheiro!!!-", e);
            }
        }

        /// <summary>
        /// Lê um ficheiro binario e retorna uma lista de clientes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static List<Refeicao> ReadRefeicoes(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    List<Refeicao> c;
                    using (Stream str = File.OpenRead(fileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (List<Refeicao>)bf.Deserialize(str);
                    }
                    return c;
                }
                else
                {
                    throw new Exception("Ficheiro não existe!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO:Nao foi possivel ler o ficheiro!!!-", e);
            }
        }

        /// <summary>
        /// Lê um ficheiro binario e retorna uma lista de clientes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static List<Reserva> ReadReservas(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    List<Reserva> c;
                    using (Stream str = File.OpenRead(fileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (List<Reserva>)bf.Deserialize(str);
                    }
                    return c;
                }
                else
                {
                    throw new Exception("Ficheiro não existe!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO:Nao foi possivel ler o ficheiro!!!-", e);
            }
        }

        /// <summary>
        /// Lê um ficheiro binario e retorna uma lista de clientes
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static List<Produto> ReadProdutos(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    List<Produto> c;
                    using (Stream str = File.OpenRead(fileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (List<Produto>)bf.Deserialize(str);
                    }
                    return c;
                }
                else
                {
                    throw new Exception("Ficheiro não existe!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO:Nao foi possivel ler o ficheiro!!!-", e);
            }
        }


        /// <summary>
        /// Lê um ficheiro binario e retorna uma lista de Funcionarios
        /// </summary>
        /// <param name="fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static List<Funcionario> ReadFuncionarios(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    List<Funcionario> c;
                    using (Stream str = File.OpenRead(fileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (List<Funcionario>)bf.Deserialize(str);
                    }
                    return c;
                }
                else
                {
                    throw new Exception("Ficheiro não existe!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO:Nao foi possivel ler o ficheiro!!!-", e);
            }
        }
    }
}
