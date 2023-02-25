using System;

namespace Teste_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma lista de equipamentos
            List<Equipamento> equipamentos = new List<Equipamento>();

            // Menu principal
            int opcao = 0;
            while (opcao != 5)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Registrar equipamento");
                Console.WriteLine("2. Visualizar equipamentos");
                Console.WriteLine("3. Editar equipamento");
                Console.WriteLine("4. Excluir equipamento");
                Console.WriteLine("5. Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        // Registrar equipamento
                        Console.WriteLine("Digite o nome do equipamento:");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o preço de aquisição:");
                        double preco = double.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o número de série:");
                        string numeroSerie = Console.ReadLine();
                        Console.WriteLine("Digite a data de fabricação (dd/mm/aaaa):");
                        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a fabricante:");
                        string fabricante = Console.ReadLine();
                        Equipamento equipamento = new Equipamento(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        equipamentos.Add(equipamento);
                        Console.WriteLine("Equipamento registrado com sucesso.");
                        break;
                    case 2:
                        // Visualizar equipamentos
                        Console.WriteLine("Equipamentos registrados:");
                        foreach (Equipamento e in equipamentos)
                        {
                            Console.WriteLine($"Nome: {e.Nome}, Número de Série: {e.NumeroSerie}, Fabricante: {e.Fabricante}");
                        }
                        break;
                    case 3:
                        // Editar equipamento
                        Console.WriteLine("Digite o número de série do equipamento a ser editado:");
                        string numSerie = Console.ReadLine();
                        Equipamento equip = equipamentos.Find(e => e.NumeroSerie == numSerie);
                        if (equip != null)
                        {
                            Console.WriteLine("Digite o novo nome:");
                            equip.Nome = Console.ReadLine();
                            Console.WriteLine("Digite o novo preço de aquisição:");
                            equip.Preco = double.Parse(Console.ReadLine());
                            Console.WriteLine("Digite a nova data de fabricação (dd/mm/aaaa):");
                            equip.DataFabricacao = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Digite a nova fabricante:");
                            equip.Fabricante = Console.ReadLine();
                            Console.WriteLine("Equipamento editado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Equipamento não encontrado.");
                        }
                        break;
                    case 4:
                        // Excluir equipamento
                        Console.WriteLine("Digite o número de série do equipamento a ser excluído:");
                        string numeroSerieExcluir = Console.ReadLine();
                        int index = equipamentos.FindIndex(e => e.NumeroSerie == numeroSerieExcluir);
                        if (index != -1)
                        {
                            equipamentos.RemoveAt(index);
                            Console.WriteLine("Equipamento excluído com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Equipamento não encontrado.");
                        }
                        break;
                    case 5:
                        // Sair
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
