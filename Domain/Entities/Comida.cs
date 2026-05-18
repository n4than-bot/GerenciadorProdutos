public class Comida : Produto, IVerificarEstoque
{
    public double PesoKG{ get; private set; }
    public bool Frios{ get; private set; }
    
    public Comida(string nome, double preco, string validade, string marca, int quantidade, double pesoKG, bool frios) 
        : base(nome,preco, validade, marca, quantidade)
    {
        if (pesoKG <= 0)
            throw new ArgumentException("O peso deve ser maior que zero.", nameof(pesoKG));
        PesoKG = pesoKG;
        Frios = frios;
    }
    
    public override void exibirInfo()
    {
        base.exibirInfo();
        Console.WriteLine($"Peso em KG: {PesoKG}");
        if (Frios == true)
        {
            Console.WriteLine("Alimento Frio");
        } else
        {
            Console.WriteLine("Alimento Normal");  
        }
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

