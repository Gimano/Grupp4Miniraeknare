using Grupp4Miniräknare;

bool running = true;
while (running)
{
    Console.WriteLine("Välkommen till våra miniräknare!");
    Console.WriteLine("Välj ett alternativ:");
    Console.WriteLine("1. Martins miniräknare");
    Console.WriteLine("2. Markus miniräknare");
    Console.WriteLine("3. Krittapats miniräknare");
    Console.WriteLine("4. Exit");
    Console.WriteLine("--------------------------------");
    int val = 0;
    if (int.TryParse(Console.ReadLine(), out int result))
        val = result;

    switch (val)
    {
        case 1:
            MartinKalkylator.Program();
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            running = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("\nEj ett valbart alternativ.\n");
            break;
    }
}