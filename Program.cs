using System.Runtime.InteropServices;
using System.Security.Cryptography;

Console.WriteLine("--- Masmorra ---");

List<Criatura> criaturas = new List<Criatura>();

criaturas.Add(new Criatura(nome: "Lobo Cinzento", habilidade: 3, energia: 3));
criaturas.Add(new Criatura(nome: "Lobo Branco", habilidade: 3, energia: 3));
criaturas.Add(new Criatura(nome: "Goblin", habilidade: 5, energia: 4));
criaturas.Add(new Criatura(nome: "Orc Vesgo", habilidade: 5, energia: 5));
criaturas.Add(new Criatura(nome: "Orc Barbudo", habilidade: 5, energia: 5));
criaturas.Add(new Criatura(nome: "Zumbi Manco", habilidade: 6, energia: 7));
criaturas.Add(new Criatura(nome: "Zumbi Balofo", habilidade: 6, energia: 7));
criaturas.Add(new Criatura(nome: "Troll", habilidade: 8, energia: 7));
criaturas.Add(new Criatura(nome: "Ogro", habilidade: 8, energia: 9));
criaturas.Add(new Criatura(nome: "Ogro Furioso", habilidade: 10, energia: 9));
criaturas.Add(new Criatura(nome: "Necromante Maligno", habilidade: 12, energia: 12));

Heroi heroi= new Heroi();

Console.WriteLine("Rolando os dados...");
Thread.Sleep(1000);
Console.WriteLine($"Herói: Habilidade = {heroi.Habilidade}  Energia = {heroi.Energia}  Sorte = {heroi.Sorte}");

foreach (Criatura criatura in criaturas)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Enfrentando {criatura.Nome} \n");
    Console.ResetColor();
    Console.WriteLine($"{criatura.Nome}: Habilidade = {criatura.Habilidade} Energia = {criatura.Energia}");

    while(criatura.Energia > 0)
    {
        int ataque = heroi.ForcaDeAtaque();
        int defesa = criatura.ForcaDeAtaque();

        bool empate = ataque == defesa;

        if (empate)
        {
            Console.WriteLine("Ambos erraram!!\n");
            continue;
        }

        bool acertou = ataque > defesa;

        if (acertou)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Herói acertou!!\n");
            Console.ResetColor();

            int dano = 2;
            bool testeDeSorte = false;

        while(heroi.PodeTestarSorte())
        {
            Console.WriteLine($"Deseja usar a sorte para aumentar o dano? (Sorte = {heroi.Sorte} [s/n]) ");
            string opcao = Console.ReadLine()!;
            testeDeSorte = opcao.Trim().ToUpper() == "S";
            break;
        }

        if (testeDeSorte)
            {    
                if (heroi.EstaComSorte())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Está com sorte!!\n");
                    Console.ResetColor();

                    dano = 4;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Está com azar..\n");
                    Console.ResetColor();

                    dano = 1;
                }
            }

        criatura.SofrerDano(dano);
        Console.WriteLine($"{criatura.Nome} sofre {dano} ponto(s) de dano {(!criatura.EstaMorto() ? ", mas ainda não" : " e")} está morto.\n");
    }

    bool foiAcertado = defesa > ataque;

    if (foiAcertado)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Criatura acertou!!");
        Console.ResetColor();

        int dano = 2;
        bool testeDeSorte = false;

         while(heroi.PodeTestarSorte())
        {
            Console.WriteLine($"Deseja usar a sorte para reduzir o dano? (Sorte = {heroi.Sorte} [s/n]) ");
            string opcao = Console.ReadLine()!;
            testeDeSorte = opcao.Trim().ToUpper() == "S";
            break;
        }
            if (heroi.EstaComSorte())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Está com sorte!!");
                Console.ResetColor();

                dano = 1;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Está com azar..");
                Console.ResetColor();
                dano = 3;
            }
    
        heroi.SofrerDano(dano);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nHerói = Energia: {heroi.Energia}");
        Console.ResetColor();
        Console.WriteLine($"{criatura.Nome} causa {dano} ponto(s) de dano{(!heroi.EstaMorto() ? ", mas você ainda não" : " e você")} está morto.\n");
        }
    }
}

if (heroi.EstaMorto())
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n--- Game over ---");
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n--- Você venceu, parabéns! ---");
}
Console.ResetColor();