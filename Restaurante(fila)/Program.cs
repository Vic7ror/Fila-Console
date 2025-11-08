using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_fila_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            int COD_cliente = 1;
            int cliente_anterior = 0;
            Fila pedidos = new Fila(100);
            Fila pagamentos = new Fila(100);
            Fila encomendas = new Fila(100);

            Console.WriteLine("1 - Inserção de cliente na fila de pedidos");
            Console.WriteLine("2 - Remoção de cliente da fila de pedidos");
            Console.WriteLine("3 - Remoção de cliente da fila de pagamentos");
            Console.WriteLine("4 - Remoção de cliente da fila de encomendas");
            Console.WriteLine("5 - Sair");

            while (opcao != 5)
            {
                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                {
                    if (pedidos.Cheia() == true)
                    {
                        Console.WriteLine("Fila de pedidos cheia!!");
                    }
                    else
                    {
                        Console.WriteLine();
                        cliente_anterior = COD_cliente;
                        pedidos.Enfileirar(COD_cliente);
                        Console.WriteLine("O cliente " + COD_cliente + " foi adicionado à fila de pedidos");
                        Console.WriteLine();
                        COD_cliente++;
                    }
                }
                else if (opcao == 2)
                {
                    if (pedidos.Vazia() == true)
                    {
                            Console.WriteLine("Fila de pedidos Vazia!!");
                    }
                    else
                    {
                        if (pagamentos.Cheia() == true)
                        {
                            Console.WriteLine("Fila de pagamentos cheia!!");
                        }
                        else
                        {
                            Console.WriteLine();
                            cliente_anterior = pedidos.Desenfileirar();
                            pagamentos.Enfileirar(cliente_anterior);
                            Console.WriteLine("O cliente " + cliente_anterior + " foi removido da fila de pedidos e adicionado à fila de pagamentos.");
                            Console.WriteLine();
                        }
                    }
                }
                else if (opcao == 3)
                {
                    if (pagamentos.Vazia() == true)
                    {
                        Console.WriteLine("Fila de pagamentos Vazia!!");
                    }
                    else
                    {
                        if (encomendas.Cheia() == true)
                        {
                            Console.WriteLine("Fila de encomendas cheia!!");
                        }
                        else
                        {
                            Console.WriteLine();
                            cliente_anterior = pagamentos.Desenfileirar();
                            encomendas.Enfileirar(cliente_anterior);
                            Console.WriteLine("O cliente " + cliente_anterior + " foi removido da fila de pagamentos e adicionado à fila de encomendas.");
                            Console.WriteLine();
                        }
                    }
                }
                else if (opcao == 4)
                {
                    if (encomendas.Vazia() == true)
                    {
                        Console.WriteLine("Fila de encomendas Vazia!!");
                    }
                    else
                    {
                        cliente_anterior = encomendas.Desenfileirar();
                        Console.WriteLine();
                        Console.WriteLine("O cliente " + cliente_anterior + " foi removido da fila de encomendas.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
