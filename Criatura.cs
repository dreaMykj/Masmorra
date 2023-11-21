public class Criatura : Personagem
{
    public string Nome;

    public Criatura(string nome, int habilidade, int energia)
    {
        Nome = nome;
        Habilidade = habilidade;
        Energia = energia;
    }
}