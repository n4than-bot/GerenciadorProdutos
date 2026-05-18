public class Limpeza : Produto, IVerificarEstoque
{
    public string Tipo{ get; private set; }
    
    public Limpeza(string nome, double preco, string validade, string marca,int quantidade, string tipo) : base(nome,preco,validade,marca, quantidade)
    {
        TipoDeUnidade(tipo);
        Tipo = tipo;
    }
    
    public override void exibirInfo()
    {
        base.exibirInfo();
        TipoDeUnidade(Tipo);
    }
    
    public void TipoDeUnidade(string Tipo)
    {
        if (Tipo == "kg" || Tipo == "KG")
        {
            Tipo = Tipo.ToUpper();
            Console.WriteLine($"{Tipo}");
        }
        else if (Tipo == "ml" || Tipo == "ML")
        {
            Tipo = Tipo.ToUpper();
            Console.WriteLine($"{Tipo}");
        }
        else
        {
            throw new ArgumentException("Tipo inválido. Use 'kg' ou 'ml'.", nameof(Tipo));
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