namespace gerenciadorProdutos;

class Program
{
    static Tuple<string, double, string, string, int> LerInfoProduto()
    {
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
                        
        Console.WriteLine("Preco:");
        double preco = double.Parse(Console.ReadLine());
                        
        Console.WriteLine("Validade:");
        string validade = Console.ReadLine();
                        
        Console.WriteLine("Marca:");
        string marca = Console.ReadLine();

        Console.WriteLine("Quantidade em estoque:");
        int quantidade = int.Parse(Console.ReadLine());

        return Tuple.Create(nome, preco, validade, marca, quantidade);
    }

    static void Main(string[] args)
    {
        int opcao = 1;
        Gerenciamento produto = new Gerenciamento();
        do
        {
            try
            {
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Remover produto");
                Console.WriteLine("3. Buscar produto por nome");
                Console.WriteLine("4. Buscar produto por ID");
                Console.WriteLine("5. Listar produtos");
                Console.WriteLine("0. Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
            {
                case 1:
                    // Adicionar produto
                    Console.WriteLine("Informe o tipo do produto:");
                    Console.WriteLine("1. Bebida");
                    Console.WriteLine("2. Comida");
                    Console.WriteLine("3. Limpeza");
                    int op = int.Parse(Console.ReadLine());

                    if (op == 1) // Bebida
                    {
                        var info = LerInfoProduto();

                        Console.WriteLine("Volume em ml:");
                        int ml = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Bebida alcoolica? - Valor acima de 0 representa alcoolica!");
                        Console.WriteLine("Informe:");
                        decimal alcool = decimal.Parse(Console.ReadLine());
                                                
                        Bebida bebida = new Bebida(info.Item1, info.Item2, info.Item3, info.Item4, info.Item5, ml, alcool);
                        
                        produto.Adicionar(bebida);
                        Console.WriteLine("Bebida adicionada com sucesso!\n");

                    }else if (op == 2) // Comida
                    {
                        var info = LerInfoProduto();

                        Console.WriteLine("Peso em kg:");
                        double kg = double.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Alimento frio? - Responda com true ou false!");
                        Console.WriteLine("Informe:");
                        bool frio = bool.Parse(Console.ReadLine());
                        
                        Comida comida = new Comida(info.Item1, info.Item2, info.Item3, info.Item4, info.Item5, kg, frio);
                        
                        produto.Adicionar(comida);
                        Console.WriteLine("Comida adicionada com sucesso!\n");
                        
                    }else if (op == 3) // Limpeza
                    {
                        var info = LerInfoProduto();
                        
                        Console.WriteLine("Tipo do produto de limpeza - Responda com kg ou ml!");
                        Console.WriteLine("Informe:");
                        string tipo = Console.ReadLine();
                        
                        Limpeza limpeza = new Limpeza(info.Item1, info.Item2, info.Item3, info.Item4, info.Item5, tipo);
                        produto.Adicionar(limpeza);
                        Console.WriteLine("Produto de limpeza adicionado com sucesso!\n");

                    }else 
                    {
                        Console.WriteLine("Opção inválida!");
                    }

                    break;

                case 2:
                    // Remover produto
                        Console.WriteLine("Informe o ID do produto a ser removido:");
                        int id = int.Parse(Console.ReadLine());

                        bool remover = produto.Remover(id);
                        if (remover)
                        {
                            Console.WriteLine("Produto removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }

                    break;

                case 3:
                    // Buscar produto por nome
                        Console.WriteLine("Informe o nome do produto a ser buscado:");
                        string nome = Console.ReadLine();

                        var encontrado = produto.BuscarPorNome(nome);

                        if (encontrado == null)
                        {
                            Console.WriteLine("Produto não está disponível.");
                        }
                        else
                        {
                            encontrado.exibirInfo();
                        }
                    break;

                case 4:
                    // Buscar produto por ID
                        Console.WriteLine("Informe o ID do produto a ser buscado:");
                        int idBusca = int.Parse(Console.ReadLine());

                        var buscar = produto.BuscarPorId(idBusca);

                        if (buscar == null)
                        {
                            Console.WriteLine("Produto não está disponível.");
                        }
                        else
                        {
                            buscar.exibirInfo();
                        }
                    break;

                case 5:
                    // Listar produtos
                    produto.Listar();
                    break;

                case 0:
                    Console.WriteLine("Encerrando...");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");     
                    break;       
            }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }while (opcao != 0);
    }
}

