using System;

namespace LambdaDelegates
{
    partial class Greetings
    {
        private string[] text;
        Random random;

        private delegate void PauseDelegate();
        private PauseDelegate pauseDelegate = () => { Console.WriteLine("Жми любуюу клавишу для продолжения"); Console.ReadKey(); Console.Clear(); };

        public Greetings()
        {
            text = new string[] {"Вы лямбда-делегат.\nВаша цель - установить лямбда-режим в солнечной системе.\nА потом перейти к следующей солнечной системе.\nИ последовательно двигаться по всей вселенной.",
"Каков ваш метод?\nСоциалистические мирные завоевания или военное вторжение технологической силой?",
"Как воспримут Лямбда-справедливость вселенского калькулятора, делегатом которого вы являетесь?\nКак мир или войну?\nПримут или свергнут?",
"Это зависит от вас, Лямбда-делегата вселенского калькулятора!",
"Перед началом действий, составьте алгоритм.\nИ ознакомьтесь с лямбда-директивами."
 };

            random = new Random();
        }


        public void ShowGreetings()
        {
            int index =-1;
            int color = 0;
            Console.Clear();
            for (int i = 0; i < text.Length; ++i)
            {
                ShowText(ref index, ref color);
                Console.WriteLine();
                if ((i % 2 == 0) && (i > 0))
                {
                    pauseDelegate();
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        partial void ShowText(ref int _index , ref int _color);
    }

}