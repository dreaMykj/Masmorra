public class Heroi : Personagem
{
    private readonly Random random = new Random();

    public int Sorte;

    public Heroi()
    {
        Habilidade = RolarDado() + 6;
        Energia = RolarDado() + RolarDado() + 12;
        Sorte = RolarDado() + 6;
    }

    public bool PodeTestarSorte() => Sorte > 0;

    public bool EstaComSorte()
    {
        if (Sorte <= 0)
        {
            Console.WriteLine("Não possui pontos de sorte suficientes.");
        }

        bool resultado = RolarDado() + RolarDado() <= Sorte;
        Sorte--;

        return resultado;
    }
}