using System;

namespace LambdaDelegates
{
    partial struct Space
    {
        private const int MAX_UNITS = 50;

        private Element[] elements;
        private Unit[] unitPlayer;
        private Unit[] unitEnemy;
        private Cursor cursor;
        private bool isRunning;
        private bool isShowPhase;
        private SpacePhase phase;
        private ActionPhase actionPhase;
        private int selectedUnit;
        private int turnNo;
        private bool isPlayerTurn;
        private bool isShowTurnInfo;
        private int actionCursor;


        private int ActionCursor
        {
            set
            {
                int finalIndex = 0;
                if (unitPlayer[selectedUnit].GetType() != UnitType.UFO)
                {
                    finalIndex = 3;
                }
                else
                {
                    finalIndex = 4;
                }

                if ((value >= 1) && (value <= finalIndex))
                {
                    actionCursor = value;
                }
                else
                {
                    if (value < 1)
                    {
                        actionCursor = finalIndex;
                    }
                    else
                    {
                        actionCursor = 1;
                    }
                }
            }

            get
            {
                return actionCursor;
            }
        }

        private delegate void PhaseDelegate(string _text);
        private delegate void ClsScreenDelegate();

        private PhaseDelegate phaseDelegate;
        private ClsScreenDelegate clsScreenDelegate;

        public Space(int _levelIndex)
        {
            unitPlayer = new Unit[MAX_UNITS];
            unitEnemy = new Unit[MAX_UNITS];

            cursor = new Cursor(new Point(0, 0));
            isRunning = true;
            isShowPhase = true;
            phase = SpacePhase.SET_UFO;
            actionPhase = ActionPhase.SELECT_UNIT;
            selectedUnit = -1;


            turnNo = 1;
            isPlayerTurn = true;
            isShowTurnInfo = false;

            actionCursor = 1;

            phaseDelegate = (string _text) => Console.WriteLine(_text);
            clsScreenDelegate = () => { Console.WriteLine("     Жми любую клавишу для продолжения"); Console.ReadKey(); Console.Clear(); };


            for (int i = 0; i < MAX_UNITS; ++i)
            {
                unitPlayer[i].SetData(UnitType.NO_UNIT, new Point(0, 0));
                unitEnemy[i].SetData(UnitType.NO_UNIT, new Point(0, 0));
            }
            elements = null;

            switch (_levelIndex)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;

                case 1:
                    {
                        elements = new Element[3];

                        elements[0] = new Element(new Point(0, 0), "Зира", Type.STAR, Status.NO_STATUS); // 40  9
                        elements[1] = new Element(new Point(0, Settings.SPACE_HEIGHT - 1), "Унив", Type.PLANET, Status.OPONENT_OWNER);
                        elements[2] = new Element(new Point(Settings.SPACE_WIDTH - 1, Settings.SPACE_HEIGHT - 1), "Кло", Type.PLANET, Status.OPONENT_OWNER);

                        unitPlayer[0].SetData(UnitType.AVENGER, new Point(0, 3));
                        unitPlayer[1].SetData(UnitType.BATTLE_WAGON, new Point(10, 3));
                        unitPlayer[2].SetData(UnitType.BOMBER, new Point(20, 3));
                        unitPlayer[3].SetData(UnitType.UFO, new Point(30, 3));
                        unitPlayer[4].SetData(UnitType.ROBO_WARRIOR, new Point(40, 3));
                        unitPlayer[5].SetData(UnitType.SOCIALIST, new Point(50, 3));

                        unitEnemy[0].SetData(UnitType.AVENGER, new Point(5, 0));
                        unitEnemy[1].SetData(UnitType.BATTLE_WAGON, new Point(10, 0));
                        unitEnemy[2].SetData(UnitType.BOMBER, new Point(15, 0));
                        unitEnemy[3].SetData(UnitType.UFO, new Point(20, 0));
                    }
                    break;


                case 2:
                    {
                        elements = new Element[3];

                        elements[0] = new Element(new Point(40, 9), "Зира", Type.STAR, Status.NO_STATUS);
                        elements[1] = new Element(new Point(20, 5), "Унив", Type.PLANET, Status.OPONENT_OWNER);
                        elements[2] = new Element(new Point(60, 10), "Кло", Type.PLANET, Status.OPONENT_OWNER);
                    }
                    break;

                case 3:
                    {
                        elements = new Element[3];

                        elements[0] = new Element(new Point(40, 10), "Зира", Type.STAR, Status.NO_STATUS);
                        elements[1] = new Element(new Point(20, 5), "Унив", Type.PLANET, Status.OPONENT_OWNER);
                        elements[2] = new Element(new Point(60, 15), "Кло", Type.PLANET, Status.OPONENT_OWNER);
                    }
                    break;


            }

        }




        public void Run()
        {


            while (isRunning == true)
            {

                if (isShowPhase == true)
                {
                    ShowPhase();
                    isShowPhase = false;
                }
                else
                {
                    if (isShowTurnInfo == true)
                    {
                        ShowTurnInfo();
                    }
                    else
                    {
                        if (isPlayerTurn == true)
                        {
                            ShowScreen();
                            ManagePlayerInput();
                        }
                        else
                        {
                            ManageOponentTurn();

                        }

                    }


                }



            }
        }




        private void ManagePlayerInput()
        {
            ConsoleKeyInfo consoleKeyInfo;


            consoleKeyInfo = Console.ReadKey();

            switch (consoleKeyInfo.Key)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;

                case ConsoleKey.UpArrow:
                    {
                        if ((actionPhase == ActionPhase.MOVE) || (actionPhase == ActionPhase.SELECT_UNIT))
                        {
                            cursor.SetY(cursor.GetY() - 1);
                        }

                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if ((actionPhase == ActionPhase.MOVE) || (actionPhase == ActionPhase.SELECT_UNIT))
                        {
                            cursor.SetY(cursor.GetY() + 1);
                        }
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    {
                        if ((actionPhase == ActionPhase.MOVE) || (actionPhase == ActionPhase.SELECT_UNIT))
                        {
                            cursor.SetX(cursor.GetX() - 1);
                        }
                        else
                        {
                            if (actionPhase == ActionPhase.SELECT_ACTION)
                            {
                                ActionCursor--;
                            }
                        }
                    }
                    break;

                case ConsoleKey.RightArrow:
                    {
                        if ((actionPhase == ActionPhase.MOVE) || (actionPhase == ActionPhase.SELECT_UNIT))
                        {
                            cursor.SetX(cursor.GetX() + 1);
                        }
                        else
                        {
                            if (actionPhase == ActionPhase.SELECT_ACTION)
                            {
                                ActionCursor++;
                            }
                        }
                    }
                    break;

                case ConsoleKey.Escape:
                    {
                        isRunning = false;
                    }
                    break;

                case ConsoleKey.Spacebar:
                    {
                        bool isObject = false;

                        if (phase == SpacePhase.SET_UFO)
                        {
                            if ((cursor.GetX() < Settings.SETTING_X_LEFT) || (cursor.GetX() >= Settings.SETTING_X_RIGHT) || (cursor.GetY() < Settings.SETTING_Y_UP) || (cursor.GetY() >= Settings.SETTING_Y_DOWN))
                            {
                                for (int i = 0; i < elements.Length; ++i)
                                {
                                    if ((cursor.GetX() == elements[i].GetPoint().GetX()) && (cursor.GetY() == elements[i].GetPoint().GetY()))
                                    {
                                        isObject = true;
                                        break;
                                    }
                                }

                                if (isObject == false)
                                {
                                    unitPlayer[0] = new Unit(UnitType.UFO, new Point(cursor.GetX(), cursor.GetY()));
                                    phase = SpacePhase.PROCESS;
                                    isShowPhase = true;
                                    isShowTurnInfo = true;
                                }
                                else
                                {
                                    ShowMessage("На этом месте находится некий космический объект. Расположи в другом месте!");
                                }
                            }
                            else
                            {
                                ShowMessage("Сюда нельзя. Только на окраине можно. Расположи в другом месте!");
                            }
                        }
                        else
                        {
                            ManagePlayerTurn();
                            //isShowTurnInfo = true;
                            //isPlayerTurn = !isPlayerTurn;
                        }



                    }
                    break;

            }

        }



        private void ManagePlayerTurn()
        {
            if (unitPlayer[0].GetType() != UnitType.NO_UNIT)
            {
                int winCounter = 0;

                for (int i = 0; i < elements.Length; ++i)
                {
                    if ((elements[i].GetStatus() == Status.SOCIALIZED) || (elements[i].GetStatus() == Status.CONQUERED))
                    {
                        winCounter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (winCounter == elements.Length)
                {
                    isShowPhase = true;
                    phase = SpacePhase.WIN;
                    return;
                }

                switch (actionPhase) 
                {
                    default:
                        {
                            /*nothing to do*/
                        }
                        break;

                    case ActionPhase.SELECT_UNIT:
                        {

                            for (int i = 0; i < unitPlayer.Length; ++i)
                            {
                                if ((cursor.GetX() == unitPlayer[i].GetPoint().GetX()) && (cursor.GetY() == unitPlayer[i].GetPoint().GetY()))
                                {
                                    selectedUnit = i;
                                    actionPhase = ActionPhase.SELECT_ACTION;
                                    ActionCursor = 1;
                                    break;
                                }

                            }
                        }
                        break;

                    case ActionPhase.SELECT_ACTION:
                        {
                            if (unitPlayer[selectedUnit].GetType() != UnitType.UFO)
                            {
                                switch (actionCursor)
                                {
                                    default:
                                        {
                                            /*nothing to do*/
                                        }
                                        break;

                                    case 1:
                                        {
                                            actionPhase = ActionPhase.MOVE;
                                        }
                                        break;


                                    case 2:
                                        {
                                            actionPhase = ActionPhase.DEFENSE;
                                        }
                                        break;



                                    case 3:
                                        {
                                            actionPhase = ActionPhase.SELECT_UNIT;
                                        }
                                        break;

                                }
                            }
                            else
                            {
                                switch (actionCursor)
                                {
                                    default:
                                        {
                                            /*nothing to do*/
                                        }
                                        break;

                                    case 1:
                                        {
                                            actionPhase = ActionPhase.MOVE;
                                        }
                                        break;


                                    case 2:
                                        {
                                            actionPhase = ActionPhase.DEFENSE;
                                        }
                                        break;



                                    case 3:
                                        {
                                            actionPhase = ActionPhase.BUILD;
                                        }
                                        break;

                                    case 4:
                                        {
                                            actionPhase = ActionPhase.SELECT_UNIT;
                                        }
                                        break;

                                }
                            }

                           
                        }
                        break;


                    case ActionPhase.MOVE:
                        {


                                if ((cursor.GetX() == unitPlayer[i].GetPoint().GetX()) && (cursor.GetY() == unitPlayer[i].GetPoint().GetY()))
                                {
                                    selectedUnit = i;
                                    actionPhase = ActionPhase.SELECT_ACTION;
                                    ActionCursor = 1;
                                    break;
                                }


                        }
                        break;

                }

 



            }
            else
            {
                isShowPhase = true;
                phase = SpacePhase.LOOSE;
                return;
            }
        }




        private void ManageOponentTurn()
        {
            isPlayerTurn = true;
            isShowTurnInfo = true;
        }


        private void ManageUnits(int _index)
        {
            switch (actionPhase)
            {
                default:
                    {
                        /*nothing to do*/
                    }
                    break;

                //case ActionPhase.SELECT:
                //    {

                //    }
                //    break;

                case ActionPhase.MOVE:
                    {

                    }
                    break;

                case ActionPhase.DEFENSE:
                    {

                    }
                    break;
            }
        }


        private void ShowTurnInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("* *             *           *              *");
            Console.WriteLine("     *   *         *           *    *");
            Console.WriteLine("* *     *   *   *  * * *         *       *     *  *");
            Console.WriteLine("* *   *   *       *    *  *  *  *    *   *       *");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(new String('-',Settings.WIDTH));

 


            Console.WriteLine($"Вселенский Лямбда-ход номер {turnNo,-2:d2} \n\n");

            if (isPlayerTurn == true)
            {
                Console.WriteLine("Ход Лямбда-делегата");
            }
            else
            {
                Console.WriteLine("Ход опонета Лямбда-справедливости");
                turnNo++;
            }

            Console.WriteLine(new String('-', Settings.WIDTH));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nВселенная бесконечна и бесконечно стремление к Лямбда\nЛямбда есть само уравнение бесконечной вселенной\nПоэтому Лямбда стремится к бесконечности в своем распространении,\nуподобляясь вселенной");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nЖми любую клавишу для продолжения");
            Console.ReadKey();

            isShowTurnInfo = false;
        }

        partial void ShowPhase();
        partial void ShowScreen();
        partial void ShowMessage(string _text);


        partial void ShowElementsOnMap(int _x, int _y, ref bool _isObject);
        partial void ShowUnitEnemiesOnMap(int _x, int _y, ref bool _isObject);
        partial void ShowUnitPlayerOnMap(int _x, int _y, ref bool _isObject);
        partial void ShowFogOnMap(int _x, int _y);
        partial void ShowElementsPreFogOnMap(int _x, int _y);
        partial void ShowElementDetails();
        partial void ShowUnitEnemiesDetails();
        partial void ShowUnitPlayerDetails();

    }
}