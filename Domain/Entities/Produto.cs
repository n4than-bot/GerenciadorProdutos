public abstract class Produto 
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public double Preco { get; private set; }
    public string Validade { get; private set; }
    public string Marca { get; private set; }
    public int Quantidade { get; protected set; }
    private static int ContatorId = 0;
    
    protected Produto(string nome, double preco, string validade, string marca, int quantidade = 0) 
    {
        ContatorId++;
        Id = ContatorId;
        
        Nome = nome;
        if (preco < 1)
            throw new ArgumentException("O preço deve ser maior que zero.", nameof(preco));
        Preco = preco; 
        Validade = validade;
        Marca = marca;
        if (quantidade < 0)
            throw new ArgumentException("A quantidade não pode ser negativa.", nameof(quantidade));
        Quantidade = quantidade;
    }
    
    public virtual void exibirInfo() 
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Preço: {Preco:N2}");
        Console.WriteLine($"Validade: {Validade}");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Quantidade em estoque: {Quantidade}");
    }
}