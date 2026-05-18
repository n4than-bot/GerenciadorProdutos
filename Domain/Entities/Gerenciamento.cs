public class Gerenciamento
{
    private readonly List<Produto> produtos;

    public Gerenciamento()
    {
        produtos = new List<Produto>();
    }

    public IReadOnlyList<Produto> Produtos => produtos.AsReadOnly();

    public void Adicionar(Produto produto)
    {
        if (produto == null)
            throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

        produtos.Add(produto);
    }

    public bool Remover(int id)
    {
        var produto = BuscarPorId(id);
        if (produto == null)
            return false;

        return produtos.Remove(produto);
    }

    public Produto? BuscarPorId(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return null;

        if (produto is IVerificarEstoque estoque && !estoque.verificarDisponibilidade())
            return null;

        return produto;
    }

    public Produto? BuscarPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return null;

        var produto = produtos.FirstOrDefault(p => string.Equals(p.Nome, nome, StringComparison.OrdinalIgnoreCase));
        if (produto == null)
            return null;

        if (produto is IVerificarEstoque estoque && !estoque.verificarDisponibilidade())
            return null;

        return produto;
    }

    public void Listar()
    {
        if (!produtos.Any())
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (var produto in produtos)
        {
            produto.exibirInfo();
            Console.WriteLine(new string('-', 30));
        }
    }
}