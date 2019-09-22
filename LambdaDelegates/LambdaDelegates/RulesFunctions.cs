using System;

namespace LambdaDelegates
{
    partial class Rules
    {
        partial void ShowRule(ref int _index, ref int _color)
        {
            _index++;

            _color = random.Next(0, 3);
            switch (_color)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;

                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    break;

                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    break;

                case 2:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
            }

            if (_index < directives.Length)
            {

                Console.WriteLine("Директива номер {0,-2:D2}", _index);
                Console.WriteLine(directives[_index]);
                Console.WriteLine();
            }
            else
            {
                _index = 0;
                Console.WriteLine("---");
                Console.WriteLine("Вывод директив завершен");
                Console.WriteLine("Директив всего: {0,-2:D2}", directives.Length);
                Console.WriteLine();
            }


        }
    }
}