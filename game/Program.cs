class Program
{
    static int PlayerDefaultHealh = 100;
    static int MonsterDefaultHealh = 200;
    static int PlayerHealth = 100;
    static int MonsterHealth = 200;
    static int Heal;
    static int GiveDamage;
    static int TakeDamage;
    static int Selection = 0;
    static string CurrentSelection = "";
    static Random Random = new Random();

    static void Main()
    {
        StartMessage();
        Console.Clear();
        RunGame();
    }
    static void StartMessage()
    {
        Console.WriteLine(@"
Epic Monster Game

Press any key to start.");
        Console.ReadKey();  
    }
    static void RunGame()
    {
        Console.WriteLine("Current Player Health: " + PlayerHealth);
        Console.WriteLine("Current Monster Health: " + MonsterHealth);

        Console.WriteLine(@"
Select Option.
1. Attack Monster
2. Heal Player
3. Reset
");

        CurrentSelection = Console.ReadLine();

        //checks if input is an int
        if (!int.TryParse(CurrentSelection, out Selection))
            {
            Console.Clear();
            Console.WriteLine("invaild input.");
            Console.WriteLine("");
        }else
        {
            Selection = Int32.Parse(CurrentSelection);
        }

        switch (Selection)
        {
            case 1:
                AttackMonster();
                Thread.Sleep(1000);
                AttackPlayer();
                Thread.Sleep(1500);
                Console.Clear();
                break;
            case 2:
                HealPlayer();
                Thread.Sleep(1500);
                Console.Clear();
                break;
            case 3:
                Main();
                Console.Clear();
                break;
        }
        RunGame();
    }
    static void AttackMonster()
    {
        //removes health from monster
        Console.WriteLine("");
        GiveDamage = Random.Next(0, 100);
        Console.WriteLine("Attack Monster for " + GiveDamage);
        Console.WriteLine("");
        Thread.Sleep(1000);
        MonsterHealth = MonsterHealth - GiveDamage;

        if(MonsterHealth <= 0)
        {
            //outputs win message if monsters health is 0 or below
            Console.Clear();
            Console.WriteLine("You Won!");
            Reset();
            Main();
        }else
        {
            //if Monsters health is above 0 continues
            Console.WriteLine("Monster health left: " + MonsterHealth);
        }
    }
    static void AttackPlayer()
    {
        //removes health from player
        Console.WriteLine("");
        TakeDamage = Random.Next(0, 20);
        Console.WriteLine("Moster Attacked Player for " + TakeDamage);
        Console.WriteLine("");
        Thread.Sleep(1000);
        PlayerHealth = PlayerHealth - TakeDamage;

        if (PlayerHealth <= 0)
        {
            //outputs lose message when players health is 0 or below 
            Console.Clear();
            Console.WriteLine("You Lost!");
            Reset();
            Main();
        }
        else
        {
            //if players health is above 0 continues
            Console.WriteLine("Monster health left: " + PlayerHealth);
        }
    }
    static void HealPlayer()
    {
        if  (PlayerHealth < 100)
        {
            //heals player if health is below 100
            Console.WriteLine("");
            Heal = Random.Next(0, 100);
            PlayerHealth = PlayerHealth + Heal;
            Console.WriteLine("Player got healed for " + Heal);
            Console.WriteLine("");
            Thread.Sleep(1000);

            //sets player health to 100 if heald over 100
            if (PlayerHealth > 100)
                PlayerHealth = PlayerDefaultHealh;
            Console.WriteLine("Players new health: " + PlayerHealth);
            Thread.Sleep(1000);
        }
        else
        {
            //outputs message if player is already at max health
            Console.WriteLine("");
            Console.WriteLine("Player is at max health.");
            Thread.Sleep(1000);
        }
    }
    static void Reset()
    {
        //resets health
        PlayerHealth = PlayerDefaultHealh;
        MonsterHealth = MonsterDefaultHealh;
    }

}   