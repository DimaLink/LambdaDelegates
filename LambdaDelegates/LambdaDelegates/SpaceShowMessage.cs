using System;

namespace LambdaDelegates
{
    partial struct Space
    {

        partial void ShowPhase()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" \\                      \\                        \\   ");
            Console.WriteLine("  \\                      \\                        \\  ");
            Console.WriteLine("   \\                      \\                        \\ ");
            Console.WriteLine("    \\                      \\                        \\ ");
            Console.WriteLine("    /\\                     /\\                       /\\ ");
            Console.WriteLine("   /  \\                   /  \\                     /  \\ ");
            Console.WriteLine("  /    \\                 /    \\                   /    \\ ");
            Console.WriteLine(" /      \\               /      \\                 /      \\");


            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < 7; ++i)
            {
                Console.WriteLine();
            }

            switch (phase)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;


                case SpacePhase.SET_UFO:
                    {
                        phaseDelegate("     Фаза расположения");
                        phaseDelegate("     Поставь космическую тарелку вторжения");
                    }
                    break;

                case SpacePhase.PROCESS:
                    {
                        phaseDelegate("     Фаза вторжения");
                        phaseDelegate("     Установи Лямбда-справедливость в этой солнечной системе!");
                        phaseDelegate("     Социализируй или завоевывай,\nпокажи опонентам космическую справедливость Лямбда-калькулятора!");
                    }
                    break;

                case SpacePhase.LOOSE:
                    {
                        phaseDelegate("     Вторжение окончилось полным провалом!");
                        phaseDelegate("     Игра окончена");
                        isRunning = false;
                    }
                    break;

                case SpacePhase.WIN:
                    {
                        phaseDelegate("     Вторжение завершилось успехом");
                        phaseDelegate("     Солнечная система приведена к Лямбда-справедливости");
                        isRunning = false;
                    }
                    break;


            }



            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("");
            }

            clsScreenDelegate();
        }



        partial void ShowScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            bool isObject = false;


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('-', Settings.WIDTH));

            for (int j = 0; j < Settings.SPACE_HEIGHT; ++j)
            {

                for (int i = 0; i < Settings.WIDTH; ++i)
                {

                    if ((i == 0) || (i == Settings.WIDTH - 1))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                    else
                    {

                        if ((cursor.GetX() == i - 1) && (cursor.GetY() == j))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Settings.CHAR_CURSOR);
                        }
                        else
                        {
                            if (phase == SpacePhase.SET_UFO)
                            {
                                ShowElementsPreFogOnMap(i, j);
                                ShowFogOnMap(i, j);
                            }
                            else
                            {
                                ShowElementsOnMap(i, j, ref isObject);

                                ShowUnitEnemiesOnMap(i, j, ref isObject);

                                ShowUnitPlayerOnMap(i, j, ref isObject);


                                if (isObject == true)
                                {
                                    isObject = false;
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                        }

                    }
                }
                Console.WriteLine();
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('-', Settings.WIDTH));
            Console.Write($"Координаты:{cursor.GetX()};{cursor.GetY()} | ");

            ShowElementDetails();
            ShowUnitEnemiesDetails();
            ShowUnitPlayerDetails();
            if (phase == SpacePhase.SET_UFO)
            {
                Console.WriteLine("Выберите квадрант базирования космической тарелки");
            }
            else
            {
                switch (actionPhase)
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case ActionPhase.SELECT_UNIT:
                        {
                            Console.WriteLine("Выберите лямбда-объект для действия");
                        }
                        break;

                    case ActionPhase.SELECT_ACTION:
                        {
                            Console.WriteLine("Выберите лямбда-действие");

                            char isAction1 = Settings.NOT_SELECTED_INDEX_CHAR;
                            char isAction2 = Settings.NOT_SELECTED_INDEX_CHAR;
                            char isAction3 = Settings.NOT_SELECTED_INDEX_CHAR;
                            char isAction4 = Settings.NOT_SELECTED_INDEX_CHAR;

                            switch (ActionCursor)
                            {
                                default:
                                    {
                                        /*nothing to do*/
                                    }
                                    break;

                                case 1:
                                    {
                                        isAction1 = Settings.SELECTED_INDEX_CHAR;

                                    }
                                    break;

                                case 2:
                                    {
                                        isAction2 = Settings.SELECTED_INDEX_CHAR;
                                    }
                                    break;

                                case 3:
                                    {
                                        isAction3 = Settings.SELECTED_INDEX_CHAR;
                                    }
                                    break;

                                case 4:
                                    {
                                        isAction4 = Settings.SELECTED_INDEX_CHAR;
                                    }
                                    break;
                            }

                            switch (unitPlayer[selectedUnit].GetType())
                            {
                                default:
                                    {
                                        /*nothing to do*/
                                    }
                                    break;

                                case UnitType.AVENGER:
                                case UnitType.BOMBER:
                                case UnitType.BATTLE_WAGON:
                                case UnitType.ROBO_WARRIOR:
                                case UnitType.SOCIALIST:
                                    {
                                        Console.WriteLine($"|{isAction1}движение{isAction1}|{isAction2}Оборона{isAction2}|{isAction3}вернуться к выбору объекта{isAction3}|");
                                    }
                                    break;

                                case UnitType.UFO:
                                    {
                                        Console.WriteLine($"|{isAction1}движение{isAction1}|{isAction2}Оборона{isAction2}|{isAction3}Строить{isAction3}|{isAction4}вернуться к выбору объекта{isAction4}|");
                                    }
                                    break;

                            }

                           

                        }
                        break;

                    case ActionPhase.MOVE:
                        {
                            Console.WriteLine($"Выбран , укажите точку назначения");
                        }
                        break;

                    case ActionPhase.DEFENSE:
                        {

                        }
                        break;
                }
            }
            
        }



        partial void ShowMessage(string _text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', Settings.WIDTH));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(_text);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', Settings.WIDTH));


            Console.WriteLine("Жми любую клавишу для продолжения");
            Console.ReadKey();
        }


    }
}