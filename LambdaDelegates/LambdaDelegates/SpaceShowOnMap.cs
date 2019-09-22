using System;

namespace LambdaDelegates
{
    partial struct Space
    { 
    partial void ShowElementsOnMap(int _x, int _y, ref bool _isObject)
    {


        for (int k = 0; k < elements.Length; ++k)
        {
            if ((elements[k].GetPoint().GetX() == _x - 1) && (elements[k].GetPoint().GetY() == _y))
            {

                switch (elements[k].GetStatus())
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case Status.NO_STATUS:
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case Status.OPONENT_OWNER:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        break;

                    case Status.CONQUERED:
                    case Status.SOCIALIZED:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                }



                switch (elements[k].GetType())
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case Type.STAR:
                        {
                            Console.Write("*");
                        }
                        break;

                    case Type.PLANET:
                        {
                            Console.Write("@");
                        }
                        break;
                }

                _isObject = true;
                break;

            }
        }
    }


    partial void ShowUnitEnemiesOnMap(int _x, int _y, ref bool _isObject)
    {
        for (int k = 0; k < unitEnemy.Length; ++k)
        {
            if (unitEnemy[k].GetType() != UnitType.NO_UNIT)
            {
                if ((unitEnemy[k].GetPoint().GetX() == _x - 1) && (unitEnemy[k].GetPoint().GetY() == _y))
                {


                    Console.ForegroundColor = ConsoleColor.Red;




                    switch (unitEnemy[k].GetType())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.NO_UNIT:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.AVENGER:
                            {
                                Console.Write("И");
                            }
                            break;

                        case UnitType.BATTLE_WAGON:
                            {
                                Console.Write("Л");
                            }
                            break;

                        case UnitType.BOMBER:
                            {
                                Console.Write("Б");
                            }
                            break;

                        case UnitType.UFO:
                            {
                                Console.Write("О");
                            }
                            break;

                            case UnitType.ROBO_WARRIOR:
                                {
                                    Console.Write("Р");
                                }
                                break;

                            case UnitType.SOCIALIST:
                                {
                                    Console.Write("С");
                                }
                                break;
                        }


                    _isObject = true;
                    break;

                }
            }

        }
    }



    partial void ShowUnitPlayerOnMap(int _x, int _y, ref bool _isObject)
    {
        for (int k = 0; k < unitPlayer.Length; ++k)
        {

            if (unitPlayer[k].GetType() != UnitType.NO_UNIT)
            {
                if ((unitPlayer[k].GetPoint().GetX() == _x - 1) && (unitPlayer[k].GetPoint().GetY() == _y))
                {


                    Console.ForegroundColor = ConsoleColor.Green;




                    switch (unitPlayer[k].GetType())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.NO_UNIT:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.AVENGER:
                            {
                                Console.Write("И");
                            }
                            break;

                        case UnitType.BATTLE_WAGON:
                            {
                                Console.Write("Л");
                            }
                            break;

                        case UnitType.BOMBER:
                            {
                                Console.Write("Б");
                            }
                            break;

                        case UnitType.UFO:
                            {
                                Console.Write("О");
                            }
                            break;

                            case UnitType.ROBO_WARRIOR:
                                {
                                    Console.Write("Р");
                                }
                                break;

                            case UnitType.SOCIALIST:
                                {
                                    Console.Write("С");
                                }
                                break;
                        }


                    _isObject = true;
                    break;

                }
            }

        }
    }


    partial void ShowFogOnMap(int _x, int _y)
    {
        if ((_y > Settings.SETTING_Y_UP - 1) && (_y < Settings.SETTING_Y_DOWN))
        {
            if ((_x > Settings.SETTING_X_LEFT) && (_x < Settings.SETTING_X_RIGHT + 1))
            {
                Console.Write("?");
            }
        }

    }

    partial void ShowElementsPreFogOnMap(int _x, int _y)
    {

        if ((_y <= Settings.SETTING_Y_UP - 1) || (_y >= Settings.SETTING_Y_DOWN) || (_x <= Settings.SETTING_X_LEFT) || (_x >= Settings.SETTING_X_RIGHT + 1))
        {
            bool isObject = false;

            for (int k = 0; k < elements.Length; ++k)
            {
                if ((elements[k].GetPoint().GetX() == _x - 1) && (elements[k].GetPoint().GetY() == _y))
                {

                    switch (elements[k].GetStatus())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case Status.NO_STATUS:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                        case Status.OPONENT_OWNER:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            break;

                        case Status.CONQUERED:
                        case Status.SOCIALIZED:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            break;
                    }



                    switch (elements[k].GetType())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case Type.STAR:
                            {
                                Console.Write("*");
                            }
                            break;

                        case Type.PLANET:
                            {
                                Console.Write("@");
                            }
                            break;
                    }

                    isObject = true;
                    break;

                }



            }



            if (isObject == true)
            {
                /*nothing to do*/
            }
            else
            {
                Console.Write(" ");
            }

        }
    }

    partial void ShowElementDetails()
    {
        for (int i = 0; i < elements.Length; ++i)
        {
            if ((cursor.GetX() == elements[i].GetPoint().GetX()) && (cursor.GetY() == elements[i].GetPoint().GetY()))
            {
                switch (elements[i].GetType())
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case Type.STAR:
                        {
                            Console.Write("Звезда");
                        }
                        break;

                    case Type.PLANET:
                        {
                            Console.Write("Планета");
                        }
                        break;


                }
                Console.Write($" {elements[i].GetName()} | ");

                    Console.WriteLine();

                switch (elements[i].GetStatus())
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case Status.NO_STATUS:
                        {
                            Console.Write("Ничейный объект");
                        }
                        break;

                    case Status.OPONENT_OWNER:
                        {
                            Console.Write("Объект опонента");
                        }
                        break;

                    case Status.CONQUERED:
                        {
                            Console.Write("Объект завоеван");
                        }
                        break;

                    case Status.SOCIALIZED:
                        {
                            Console.Write("Объект социализирован");
                        }
                        break;


                }
                    Console.Write(" | ");

                }
        }
    }


    partial void ShowUnitEnemiesDetails()
    {
        for (int i = 0; i < unitEnemy.Length; ++i)
        {
            if (unitEnemy[i].GetType() != UnitType.NO_UNIT)
            {
                if ((cursor.GetX() == unitEnemy[i].GetPoint().GetX()) && (cursor.GetY() == unitEnemy[i].GetPoint().GetY()))
                {
                    switch (unitEnemy[i].GetType())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.AVENGER:
                            {
                                Console.Write("Космическая группа истребителей");
                            }
                            break;

                        case UnitType.BATTLE_WAGON:
                            {
                                Console.Write("Космический линкор");
                            }
                            break;

                        case UnitType.BOMBER:
                            {
                                Console.Write("Космическая группа бомбардировщиков");
                            }
                            break;

                        case UnitType.UFO:
                            {
                                Console.Write("Космическая база");
                            }
                            break;

                            case UnitType.ROBO_WARRIOR:
                                {
                                    Console.Write("");
                                }
                                break;

                            case UnitType.SOCIALIST:
                                {
                                    Console.Write("");
                                }
                                break;
                        }
                        Console.Write(" |");
                        Console.WriteLine();
                        Console.Write("Объект опонента | ");


                }
            }

        }




    }



    partial void ShowUnitPlayerDetails()
    {
        for (int i = 0; i < unitPlayer.Length; ++i)
        {
            if (unitPlayer[i].GetType() != UnitType.NO_UNIT)
            {
                if ((cursor.GetX() == unitPlayer[i].GetPoint().GetX()) && (cursor.GetY() == unitPlayer[i].GetPoint().GetY()))
                {
                    switch (unitPlayer[i].GetType())
                    {
                        default:
                            {
                                /*nothing to do*/
                            }
                            break;

                        case UnitType.AVENGER:
                            {
                                Console.Write("Космическая группа истребителей");
                            }
                            break;

                        case UnitType.BATTLE_WAGON:
                            {
                                Console.Write("Космический линкор");
                            }
                            break;

                        case UnitType.BOMBER:
                            {
                                Console.Write("Космическая группа бомбардировщиков");
                            }
                            break;

                        case UnitType.UFO:
                            {
                                Console.Write("Космическая тарелка базирования вторжения");
                            }
                            break;

                            case UnitType.ROBO_WARRIOR:
                                {
                                    Console.Write("Армия робо-воинов для вторжения на планеты");
                                }
                                break;

                            case UnitType.SOCIALIST:
                                {
                                    Console.Write("Бригада социалистических мирных сил для социализации планеты");
                                }
                                break;
                        }
                        Console.Write(" |");
                        Console.WriteLine();
                        Console.Write("Объект Лямбда | ");


                }
            }

        }
    }


    }

}