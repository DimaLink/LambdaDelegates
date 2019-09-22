using System;
using System.Threading;

namespace LambdaDelegates
{

    public delegate void StringLineDelegate();
    public delegate string RandomStarsDelegate(char _symbol);

    public delegate void PressAnyKeyDelegate();
    public delegate string OneStringDelegate();

    public delegate void SymbolDelegate();
    public delegate void LambdaCategoryDelegate(string _text);

    public delegate void MissionDelegate(int _index);


    enum Type : int { NO_TYPE = 0, STAR = 1, PLANET = 2 };
    enum Status : int { NO_STATUS = 0, OPONENT_OWNER, SOCIALIZED, CONQUERED };

    enum UnitType : int { NO_UNIT = 0, BATTLE_WAGON, AVENGER, BOMBER, UFO, ROBO_WARRIOR, SOCIALIST };

    enum SpacePhase : int { NO_PHASE = 0, SET_UFO, PROCESS, WIN, LOOSE };

    enum ActionPhase : int {NO_ACTION=0, SELECT_UNIT,SELECT_ACTION, MOVE, DEFENSE, BUILD };

    class Program
    {
        static void Main(string[] args)
        {

            //PressAnyKeyDelegate pressAnyKeyDelegate = () => Console.ReadKey();
            //OneStringDelegate oneStringDelegate = () => "Жми любуюу клавишу для продолжения";
            //LambdaCategoryDelegate lambdaCategoryDelegate = (string _text) => 
            //{
            //    Console.Clear();

            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("======================================================\n");

            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("        \\");
            //    Console.WriteLine("         \\");
            //    Console.WriteLine("          \\");
            //    Console.WriteLine("           \\");
            //    Console.WriteLine("            \\");
            //    Console.WriteLine("             \\");
            //    Console.WriteLine("              \\");
            //    Console.WriteLine("               \\    {0}", _text);
            //    Console.WriteLine("               /\\");
            //    Console.WriteLine("              /  \\");
            //    Console.WriteLine("             /    \\");
            //    Console.WriteLine("            /      \\");
            //    Console.WriteLine("           /        \\");
            //    Console.WriteLine("          /          \\");
            //    Console.WriteLine("         /            \\");
            //    Console.WriteLine("        /              \\");


            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("\n======================================================\n");
            //    System.Threading.Thread.Sleep(3000);
            //    while (Console.KeyAvailable)
            //    {
            //        Console.ReadKey(false);
            //    }
            //    Console.Clear();
            //};



            //lambdaCategoryDelegate("директивы");

            //Rules rules = new Rules();
            //rules.ShowRules();

            //Console.WriteLine(oneStringDelegate()); 
            //pressAnyKeyDelegate();

            //lambdaCategoryDelegate("приветствие");

            //Greetings greetings = new Greetings();
            //greetings.ShowGreetings();

            //SymbolDelegate symbolDelegate = () => 
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("======================================================\n");

            //    Console.ForegroundColor = ConsoleColor.Magenta;

            //    Console.WriteLine("          \\");
            //    Console.WriteLine("           \\");
            //    Console.WriteLine("            \\");
            //    Console.WriteLine("             \\");
            //    Console.WriteLine("              \\");
            //    Console.WriteLine("               \\");
            //    Console.WriteLine("               /\\");
            //    Console.WriteLine("              /  \\");
            //    Console.WriteLine("             /    \\");
            //    Console.WriteLine("            /      \\");
            //    Console.WriteLine("           /        \\");
            //    Console.WriteLine("          /          \\");


            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("\n======================================================\n");
            //};

            //symbolDelegate();


            //Console.WriteLine(oneStringDelegate());
            //pressAnyKeyDelegate();
            //Console.Clear();


            //lambdaCategoryDelegate("личность");
            //Character character = new Character();
            //character.GenerateCharacter();
            //character.ShowData();

            //Console.WriteLine(oneStringDelegate());
            //pressAnyKeyDelegate();

            ////делегаты
            //Console.Clear();
            //StringLineDelegate stringLineDelegate = delegate
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    for (int i = 0; i < Settings.WIDTH; ++i)
            //    {
            //        Console.Write("#");
            //    }
            //    Console.WriteLine();
            //};

            //stringLineDelegate += delegate
            // {
            //     Console.ForegroundColor = ConsoleColor.Green;
            //     for (int i = 0; i < Settings.WIDTH; ++i)
            //     {
            //         Console.Write("#");
            //     }
            //     Console.WriteLine();
            // };

            //stringLineDelegate += delegate
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    for (int i = 0; i < Settings.WIDTH; ++i)
            //    {
            //        Console.Write("#");
            //    }
            //    Console.WriteLine();
            //};

            //int yLimit = Settings.HEIGHT / 3;
            //for (int i = 0; i < yLimit; ++i)
            //{
            //    stringLineDelegate();
            //}
            //Console.ForegroundColor = ConsoleColor.White;
            ////делегаты

            //System.Threading.Thread.Sleep(3000);
            //Console.Clear();


            ////делегаты
            //RandomStarsDelegate randomStarsDelegate = delegate (char _symbol)
            //{
            //    string result = "";

            //    Random random = new Random();

            //    int rate = random.Next(10, 91);

            //    for (int y = 0; y < Settings.HEIGHT; ++y)
            //    {
            //        for (int x = 0; x < Settings.WIDTH; ++x)
            //        {
            //            if (random.Next(0, 100) <= rate)
            //            {

            //                result += _symbol;
            //            }
            //            else
            //            {
            //                result += " ";
            //            }

            //        }
            //        result += "\n";
            //    }

            //    return result;
            //};


            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(randomStarsDelegate('*'));

            //System.Threading.Thread.Sleep(3000);
            //Console.Clear();

            //while (Console.KeyAvailable)
            //{
            //    Console.ReadKey(false);
            //}




            MissionDelegate missionDelegate = (int _index) =>
            {
                Console.Clear();
                Console.WriteLine($"{_index,-2:D2}");
                Console.WriteLine("Жми любуюу клавишу для продолжения вторжения");
                Console.ReadKey();
            };



            //делегаты


            Space space = new Space(1);
            space.Run();






        }
    }
}
