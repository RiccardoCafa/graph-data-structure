using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Grafos.Graph;

namespace Grafos
{
    class Program
    {

        public static StaticGraph graphS = null;
        public static int GraphType = -1;
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao Graph Console.\n");

            Console.WriteLine("Seleciona o tipo de grafo.\n\n 1 - Grafo\n 2 - Digrafo");

            string ent = "";

            while (GraphType != 1 || GraphType != 2)
            {
                ent = Console.ReadLine();
                switch (ent[0])
                {
                    case '1':
                        GraphType = 1;
                        Console.WriteLine("Tipo Grafo selecionado");
                        break;
                    case '2':
                        GraphType = 2;
                        Console.WriteLine("Tipo Digrafo selecionado");
                        break;
                    default: WrongEntry(); break;
                }
                if (GraphType != 1 || GraphType != 2) break;
            }

            string SE;

            GraphTextEntry();

            while ((SE = Console.ReadLine()) != null)
            {

                GraphManager(SE);

                GraphTextEntry();
            }

        }

        public static void WrongEntry() => Console.WriteLine("Entrada inválida");

        public static void GraphTextEntry()
        {
            Console.WriteLine("\n\n1 X - Criar um " + (GraphType == 1 ? "Grafo" : "Digrafo") 
                                                    + " (sendo X o tamanho da matriz)\n");
            Console.WriteLine("2 - V1 V2 W - Criar uma aresta\n");
            Console.WriteLine("3 - V1 V2 Existe uma aresta\n");
            Console.WriteLine("4 - Tamanho do grafo em bytes (cuidado ao usar com grafos de ordem muito alta)");
        }

        public static bool GraphManager(string SE)
        {
            string[] Val = SE.Split(" ");
            int V1 = 0, V2 = 0, W = 0;

            int.TryParse(Val[0], out int Entry);
            if (Val.Length >= 2) int.TryParse(Val[1], out V1);
            if (Val.Length >= 3) int.TryParse(Val[2], out V2);
            if (Val.Length >= 4) int.TryParse(Val[3], out W);

            switch (Entry)
            {
                case 1:
                    int.TryParse(Val[1], out int tam);
                    if(GraphType == 1)
                    {
                        graphS = new GraphS(tam);
                    } else if(GraphType == 2)
                    {
                        graphS = new DigraphS(tam);
                    }else if(GraphType == 3)
                    {
                        graphS = new MDI(v, a);
                    }

                    Console.WriteLine("Grafo criado. Tamanho: " + tam);
                    break;

                case 2:
                    if (graphS == null) WrongEntry();

                    graphS.AddEdge(V1, V2, W);

                    Console.WriteLine("\nVértice " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2 + " com peso: " + graphS.GetWeight(V1, V2));

                    break;

                case 3:
                    if (graphS == null) WrongEntry();

                    if (graphS.ExistEdge(V1, V2))
                    {
                        Console.WriteLine("Existe a aresta: " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2);
                    }
                    else
                    {
                        Console.WriteLine("Não existe a aresta: " + V1 + " " + (GraphType == 1 ? "---" : "-->") + " " + V2);
                    }

                    break;
                case 4:
                    if(graphS != null)
                    {
                        using(Stream s = new MemoryStream())
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(s, graphS);
                            Console.WriteLine("Seu grafo tem \n\t| " + s.Length + " bit.");
                            Console.WriteLine("\t| " + (s.Length / 8) + " bytes.");
                            Console.WriteLine("\t| " + (s.Length / 8 / 1024) + " Kb.\n");
                        }
                    } else
                    {
                        Console.WriteLine("Grafo inexistente.\n");
                    }
                    break;
                default: WrongEntry(); return false;
            }
            return true;
        }
    }
}
