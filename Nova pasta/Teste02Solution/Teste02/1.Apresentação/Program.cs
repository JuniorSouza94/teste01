using System;
using System.Collections.Generic;
using Teste02._2.Domínio;

namespace Teste02
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }
        static void MenuPrincipal()
        {
            int opcao;
            do
            {
                Console.WriteLine("=========== MENU ===========");
                Console.WriteLine("1 - Controle de Equipamentos");
                Console.WriteLine("2 - Controle de Chamados");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        MenuEquipamentos();
                        break;
                    case 2:
                        MenuChamados();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);
        }
        static void MenuEquipamentos()
        {
            int opcao;
            do
            {
                Console.WriteLine("======= CONTROLE DE EQUIPAMENTOS =======");
                Console.WriteLine("1 - Registrar Equipamento");
                Console.WriteLine("2 - Visualizar Equipamentos");
                Console.WriteLine("3 - Editar Equipamento");
                Console.WriteLine("4 - Excluir Equipamento");
                Console.WriteLine("0 - Voltar");
                Console.WriteLine("=========================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        RegistrarEquipamento();
                        break;
                    case 2:
                        VisualizarEquipamentos();
                        break;
                    case 3:
                        EditarEquipamento();
                        break;
                    case 4:
                        ExcluirEquipamento();
                        break;
                    case 0:
                        Console.WriteLine("Voltando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);

            void RegistrarEquipamento()
            {
                Equipamento novoEquipamento = new Equipamento();
                Console.WriteLine("======= EQUIPAMENTOS =======");

                Console.WriteLine("Digite o nome do equipamento:");
                novoEquipamento.Nome = Console.ReadLine();

                Console.WriteLine("Informe o preço:");
                novoEquipamento.PrecoAquisicao = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite o número de série:");
                int.TryParse(Console.ReadLine(), out int nSerie);
                novoEquipamento.NumeroSerie = nSerie;

                Console.WriteLine("Informe a data de fabricação:");
                novoEquipamento.DataFabricacao = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Informe o nome do fabricante:");
                novoEquipamento.Fabricante = Console.ReadLine();

                _equipamentoDao.AdicionarEquipamento(novoEquipamento);

            }
            void VisualizarEquipamentos()
            {
                Console.WriteLine("======= EQUIPAMENTOS =======");

                List<Equipamento> buscarTodos = _equipamentoDao.BuscarTodosEquipamentos();

                foreach (var item in buscarTodos)
                {
                    Console.WriteLine($"Nome: {item.Nome} / Número de série: {item.NumeroSerie} / Nome do fabricante: {item.Fabricante}");
                }
                Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
            }
            void EditarEquipamento()
            {
                Equipamento equipamento = new Equipamento();
                string atualizar = null;

                do
                {
                    Console.Clear();
                    Console.WriteLine("======= EQUIPAMENTOS =======");
                    Console.WriteLine("Informe o número de série do equipamento que deseja atualizar:");
                    int.TryParse(Console.ReadLine(), out int nSerie);

                    equipamento = _equipamentoDao.BuscarProdutoPorNdeSerie(nSerie);

                    if (equipamento.NumeroSerie == 0)
                    {
                        Console.WriteLine("Equipamento não encontrado!\n");
                        Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
                    }

                    Console.WriteLine($"Nome: {equipamento.Nome} / Preço de aquisição: R${equipamento.PrecoAquisicao}" +
                $" / Número de série: {equipamento.NumeroSerie} / Data de Fabricação: {equipamento.DataFabricacao}" +
                $" / Nome do fabricante: {equipamento.Fabricante}");

                    Console.WriteLine("Você realmente deseja atualizar este equipamento? [S] sim ou [N] não para retornar ao menu anterior");
                    atualizar = Console.ReadLine();

                    if (atualizar.ToUpper() == "S")
                    {
                        Console.WriteLine("Informe o novo nome do equipamento:");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Informe o novo preço:");
                        double preco = double.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o novo número de série:");
                        int.TryParse(Console.ReadLine(), out int numeroSerie);

                        Console.WriteLine("Informe a nova data de fabricação:");
                        var dataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Informe o nome do fabricante:");
                        string nomeFabricante = Console.ReadLine();

                        Equipamento equipamentoAtualizado = new Equipamento(nome, preco, numeroSerie, dataDeFabricacao, nomeFabricante);
                        _equipamentoDao.AtualizarEquipamento(equipamentoAtualizado);

                        Console.WriteLine("Produto atualizado");

                        Console.WriteLine("Você deseja continuar alterando o preço dos produtos? [S] sim ou [N] não para retornar ao menu anterior");

                        atualizar = Console.ReadLine();
                        if (atualizar.ToUpper() == "N")
                        {
                            Console.WriteLine("Aperte qualquer tecla para continuar");
                        }
                    }
                    else if (atualizar.ToUpper() == "N")
                    {
                        Console.WriteLine("Aperte qualquer tecla para continuar");
                        break;
                    }
                    else
                        Console.WriteLine("Opçãp inválida");

                } while (atualizar.ToUpper() != "N");
            }
            void ExcluirEquipamento()
            {
                Equipamento equipamento = new Equipamento();
                string atualizar;

                do
                {
                    Console.Clear();
                    Console.WriteLine("======= EQUIPAMENTOS =======");
                    Console.WriteLine("Informe o número de série do equipamento que deseja deletar:");
                    int.TryParse(Console.ReadLine(), out int nSerie);

                    equipamento = _equipamentoDao.BuscarProdutoPorNdeSerie(nSerie);

                    Console.WriteLine($"Nome: {equipamento.Nome} / Preço de aquisição: R${equipamento.PrecoAquisicao}" +
                $" / Número de série: {equipamento.NumeroSerie} / Data de Fabricação: {equipamento.DataFabricacao}" +
                $" / Nome do fabricante: {equipamento.Fabricante}");


                    Console.WriteLine("Você realmente deseja deletar esse item? [S] sim ou [N] não ");
                    atualizar = Console.ReadLine();

                    if (atualizar.ToUpper() == "S")
                    {
                        _equipamentoDao.DeletarEquipamento(equipamento);

                        Console.WriteLine("Equipamento deletado");

                        Console.WriteLine("Você deseja deletar outro equipamento? [S] sim ou [N] não");

                        atualizar = Console.ReadLine();
                        if (atualizar.ToUpper() == "N")
                        {
                            Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
                        }
                    }
                    else if (atualizar.ToUpper() == "N")
                    {
                        Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
                        break;
                    }
                    else
                        Console.WriteLine("Opçãp inválida");

                } while (atualizar.ToUpper() != "N");
            }
        }
        static void MenuChamados()
        {
            int opcao;
            do
            {
                Console.WriteLine("======= CONTROLE DE CHAMADOS =======");
                Console.WriteLine("1 - Registrar Chamado");
                Console.WriteLine("2 - Visualizar Chamados");
                Console.WriteLine("3 - Excluir Chamado");
                Console.WriteLine("0 - Voltar");
                Console.WriteLine("=====================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        RegistrarChamado();
                        break;
                    case 2:
                        VisualizarChamados();
                        break;
                    case 3:
                        ExcluirChamado();
                        break;
                    case 0:
                        Console.WriteLine("Voltando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);

            void RegistrarChamado()
            {
                Chamado novoChamado = new Chamado();
                Console.WriteLine("======= CHAMADOS =======");

                Console.WriteLine("Digite o título do chamado:");
                novoChamado.Titulo = Console.ReadLine();

                Console.WriteLine("Informe a descrição do chamado:");
                novoChamado.Descricao = Console.ReadLine();

                Equipamento equipamento = new Equipamento();
                Console.WriteLine("Informe o número de série do equipamento relacionado ao chamado:");
                int.TryParse(Console.ReadLine(), out int nSerie);
                novoChamado.Equipamento.NumeroSerie = nSerie;

                novoChamado.Equipamento = _equipamentoDao.BuscarProdutoPorNdeSerie(nSerie);

                Console.WriteLine("Informe a data de abertura do chamado:");
                novoChamado.DataAbertura = Convert.ToDateTime(Console.ReadLine());

                _chamadoDao.AdicionarChamado(novoChamado);
            }
            void VisualizarChamados()
            {
                Console.WriteLine("======= CHAMADOS =======");
                List<Chamado> buscarChamados = _chamadoDao.BuscarChamados();

                foreach (var item in buscarChamados)
                {
                    Console.WriteLine($"Título do chamado: {item.Titulo} / Equipamento: {item.Equipamento.Nome} / Data de abertura do chamado: {item.DataAbertura} / Número de dias que o chamado está aberto: {item.NumeroDiasAberto}");
                }
            }
            void ExcluirChamado()
            {
                Chamado deletarChamado = new Chamado();
                string atualizar;

                do
                {
                    Console.Clear();
                    Console.WriteLine("======= CHAMADOS =======");
                    Console.WriteLine("Informe o número do ID do chamado:");
                    int.TryParse(Console.ReadLine(), out int id);

                    deletarChamado = _chamadoDao.BuscarPorId(id);

                    Console.WriteLine($"Título do Chamado: {deletarChamado.Titulo} / Equipamento: {deletarChamado.Equipamento.Nome} / Data de abertura do chamado: {deletarChamado.DataAbertura} / Número de dias que o chamado está aberto: {deletarChamado.NumeroDiasAberto}");
                
                    Console.WriteLine("Você realmente deseja deletar esse chamado? [S] sim ou [N] não ");
                    atualizar = Console.ReadLine();

                    if (atualizar.ToUpper() == "S")
                    {
                        _chamadoDao.DeletarChamado(deletarChamado);

                        Console.WriteLine("Chamado deletado");

                        Console.WriteLine("Você deseja deletar outro chamado?");

                        atualizar = Console.ReadLine();
                        if (atualizar.ToUpper() == "N")
                        {
                            Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
                        }
                    }
                    else if(atualizar.ToUpper() == "N")
                    {
                        Console.WriteLine("Aperte qualquer tecla para retornar ao menu anterior");
                        break;
                    }
                    else
                        Console.WriteLine("Opção inválida!");
                } 
                while (atualizar.ToUpper() != "N");
            }
        }
    }
}

