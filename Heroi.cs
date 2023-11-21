public class Heroi : Personagem
{
    private readonly Random random = new Random();

    public int sorte { get; protected set; }

    public Heroi()
    {
        habilidade = RolarDado() + 6;
        energia = RolarDado() + RolarDado() + 12;
        sorte = RolarDado() + 6;
    }

    public bool PodeTestarSorte() => sorte > 0;

    public bool EstaComSorte()
    {
        if (sorte <= 0)
        {
            Console.WriteLine("Não possui pontos de sorte suficientes.");
        }

        bool resultado = RolarDado() + RolarDado() <= sorte;
        sorte--;

        return resultado;
    }
}