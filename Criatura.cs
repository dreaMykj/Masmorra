public class Criatura : Personagem
{
    public string Nome;
    public bool Estado = true;
    public Criatura(string nome, int habilidade, int energia)
    {
        Nome = nome;
        Habilidade = habilidade;
        Energia = energia;
    }
}