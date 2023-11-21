public class Personagem
{
    public int habilidade;
    public int energia;

    private readonly Random random = new Random();

    protected int RolarDado() => random.Next(1, 7);

    public int ForcaDeAtaque() => habilidade + RolarDado() + RolarDado();

    public void SofrerDano(int pontosDeDano)
    {
        energia -= pontosDeDano;
    }

    public bool EstaMorto() => energia <= 0;
}

