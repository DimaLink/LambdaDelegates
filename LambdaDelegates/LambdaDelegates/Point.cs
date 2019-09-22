using System;
 

namespace LambdaDelegates
{
    struct Point
    {
        private int x;
        private int y;

        public Point(int _x, int _y)
        {
            x = 0;
            y = 0;
            SetData(_x, _y);
        }

        public void SetData(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int GetX()
        {
            return x;
        }

        public void SetX(int _x)
        {
            x = _x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int _y)
        {
            y = _y;
        }

    }
}