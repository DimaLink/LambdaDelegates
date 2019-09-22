using System;

namespace LambdaDelegates
{
    class Character
    {
        private Random random;

        private int name;
        private int id1;
        private int id2;
        private int id3;
        private int id4;
        private int id5;
        private int id6;
        private int id7;
        private int id8;

        public Character()
        {
            random = new Random();
        }

        public void GenerateCharacter()
        {
            GenerateData(out name, out id1, out id2, out id3, out id4, out id5, out id6, out id7, out id8 );
        }

        public void ShowName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ваше лямбда-имя: {name}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowIds()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Идентификационные номера, присвоенные Лямбда-калькулятором:");
            Console.WriteLine($"Идентификационный номер 1: {id1}");
            Console.WriteLine($"Идентификационный номер 2: {id2}");
            Console.WriteLine($"Идентификационный номер 3: {id3}");
            Console.WriteLine($"Идентификационный номер 4: {id4}");
            Console.WriteLine($"Идентификационный номер 5: {id5}");
            Console.WriteLine($"Идентификационный номер 6: {id6}");
            Console.WriteLine($"Идентификационный номер 7: {id7}");
            Console.WriteLine($"Идентификационный номер 8: {id8}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowData()
        {
            ShowName();
            ShowIds();
        }

        private void GenerateData( out int _name, out int _id1 , out int _id2, out int _id3, out int _id4, out int _id5, out int _id6, out int _id7, out int _id8)
        {
            _name = random.Next(1024,2147483647);
            _id1 = random.Next(1024, 2147483647);
            _id2 = random.Next(1024, 2147483647);
            _id3 = random.Next(1024, 2147483647);
            _id4 = random.Next(1024, 2147483647);
            _id5 = random.Next(1024, 2147483647);
            _id6 = random.Next(1024, 2147483647);
            _id7 = random.Next(1024, 2147483647);
            _id8 = random.Next(1024, 2147483647);
        }



    }
}