public class Bebida : Produto, IVerificarAlcool, IVerificarEstoque
{
    private int VolumeMl { get; }
    public bool Alcoolico { get; private set; }
    private decimal PercentualAlcool { get; }
    
    public Bebida(string nome, double preco, string validade, string marca, int quantidade, int volumeMl, decimal percentualAlcool) 
        : base(nome, preco, validade, marca, quantidade) 
    {
        if (volumeMl <= 0)
            throw new ArgumentException("O volume deve ser maior que zero.", nameof(volumeMl));

        VolumeMl = volumeMl;
        if (percentualAlcool > 0)
        {
            Alcoolico = true;
        }else 
        {
            Alcoolico = false;
        }
        PercentualAlcool = percentualAlcool;
    }

    public override void exibirInfo()
    {
        base.exibirInfo();
        Console.WriteLine($"Volume em ml: {VolumeMl}");

        if (Alcoolico == true)
        {
            decimal alcool = quantidadeAlcool();
            Console.WriteLine($"Bebida alcoólica: {alcool}%");   
        }
    }
    
    public decimal quantidadeAlcool() 
    {
        return PercentualAlcool;
    }

    public bool verificarDisponibilidade()
    {
        if (Quantidade > 0)
        {
            Console.WriteLine($"Produto disponível! Quantidade em estoque: {Quantidade}");
            return true;
        }
        else
        {
            Console.WriteLine("Produto indisponível");
            return false;
        }
    }
}