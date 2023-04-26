// See https://aka.ms/new-console-template for more information
var random = new Random();
startTheMachine();

void startTheMachine()
{
    bool isRejouer = false;
    do
    {
        isRejouer = jeuDeLotterie();
    } while (isRejouer);
}

bool jeuDeLotterie()
{
    bool isRejouer = false;
    afficherMenu();
    int[] centNumero = genererCentNumeros();
    int[] essaiDeClient = collecterChiffre();
    comparerDeuxTableaux(centNumero, essaiDeClient);
    isRejouer = validerRejouer();
    return isRejouer;
}

void afficherMenu()
{
    Console.WriteLine("*******************************************************");
    Console.WriteLine("******** Bienvenue dans le jeu Lotterie Cookie ********");
    Console.WriteLine("*******************************************************\n\n");
    Console.WriteLine("*** Veuillez saisir vos 5 nombres en 1 et 200 ***");
}
int[] genererCentNumeros()
{
    int[] laListe = new int[100];
    int numRandom;
    Array.Fill(laListe, random.Next(1, 201));
    for(int i=1; i<100; i++)
    {
        do
        {
            numRandom = random.Next(1, 201);
        } while (Array.Exists(laListe, num => num == numRandom));
        laListe[i] = numRandom;
    }
    return laListe;
}

int[] collecterChiffre()
{
    int[] essai = new int[5];
    string input;
    int number;
    for(int i=0; i<5; i++)
    {
        Console.WriteLine("Entrer un nombre et appuyer sur entrer:");
        input = Console.ReadLine()!;
        while(!Int32.TryParse(input, out number) || number<1 || number>200)
        {
            Console.WriteLine("Veuillez entrer un nombre compris entre 1 et 200 seulement");
            Console.WriteLine("Entrer un nombre et appuyer sur entrer:");
            input = Console.ReadLine()!;
        }
        essai[i] = number;
    }
    return essai;
}

void comparerDeuxTableaux(int[] ordi, int[] utilisateur)
{
    List<int> devine = new List<int>();
    for(int i=0; i<utilisateur.Length; i++)
    {
        if(Array.Exists(ordi, j => j == utilisateur[i]))
        {
            devine.Add(utilisateur[i]);
        }
    }
    Console.WriteLine("\n***************** Résultat *****************");
    if(devine.Count == 0)
    {
        Console.WriteLine("Vous avez obtenu 0 numero.");
    }
    else
    {
        Console.WriteLine("Vous avez obtenu les " + devine.Count + " numéros suivants:");
        devine.ForEach(delegate (int num)
        {
            Console.WriteLine(num);
        });
    }
}

bool validerRejouer()
{
    bool isRejouer = false;
    bool isRepeter;
    do
    {
        Console.WriteLine("Voulez-vous encore jouer (O/N) ?");
        isRepeter = false;
        switch (Console.ReadLine())
        {
            case "o":
                isRejouer = true;
                Console.Clear();
                break;
            case "n":
                break;
            default:
                isRepeter = true;
                break;
        }
    } while (isRepeter);
    return isRejouer;
}
