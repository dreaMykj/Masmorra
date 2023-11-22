public class Personagem
{
    public int Habilidade { get; set; }
    public int Energia { get; set; }

    private readonly Random random = new Random();

    protected int RolarDado() => random.Next(1, 7);

    public int ForcaDeAtaque() => Habilidade + RolarDado() + RolarDado();

    public void SofrerDano(int pontosDeDano)
    {
        Energia -= pontosDeDano;
    }

    public bool EstaMorto() => Energia <= 0;
}

