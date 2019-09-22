using System;

namespace LambdaDelegates
{
    partial class Greetings
    {
        partial void ShowText(ref int _index, ref int _color)
        {

            _color = random.Next(0,3);

            switch (_color)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;

                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    break;

                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    break;

                case 2:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
            }

            _index++;

            if (_index < text.Length)
            {
                Console.WriteLine(text[_index]);
                Console.WriteLine("                         * * *");
            }
            else
            {
                _index = 0;
            }

        }
    }
}