
Menu();

Console.ReadKey();

static void Menu() 
{
    Console.Clear();
    Console.WriteLine("O que você deseja fazer? ");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");
    short opt = short.Parse(Console.ReadLine()!);

    switch(opt)
    {
        case 0:
            Environment.Exit(0); break;
        case 1:
            Abrir(); break;
        case 2:
            Editar(); break;
        default:
            Menu(); break;
    }
}

static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual caminho do arquivo?");
    string path = Console.ReadLine()!;

    using(var file = new StreamReader(path))
    {
        // Ler o arquivo até o final
        string tetx = file.ReadToEnd();
        Console.WriteLine(tetx);
    }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
    Console.WriteLine("----------------------");

    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

// Salva o arquivo
static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo? ");
    var path = Console.ReadLine()!;

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }
    Console.WriteLine("Arquivo salvo com sucesso!");
    Console.ReadLine();
    Menu();
}