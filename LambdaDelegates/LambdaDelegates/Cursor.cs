using System;

namespace LambdaDelegates
{
    struct Cursor
    {
        Point point;


        public Cursor(Point _point)
        {
            point = _point;
        }


        public void SetData(Point _point)
        {
            SetX(_point.GetX());
            SetY(_point.GetY());
        }

        public Point GetData()
        {
            return point;
        }

        public void SetX(int _x)
        {
            if ((_x >= 0) && (_x < Settings.SPACE_WIDTH))
            {
                point.SetX(_x);
            }
            else
            {
                if (_x < 0)
                {
                    point.SetX(Settings.SPACE_WIDTH - 1);
                }
                else
                {
                    point.SetX(0);
                }
            }

        }

        public int GetX()
        {
            return point.GetX();
        }

        public void SetY(int _y)
        {
            if ((_y >= 0) && (_y < Settings.SPACE_HEIGHT))
            {
                point.SetY(_y);
            }
            else
            {
                if (_y < 0)
                {
                    point.SetY(Settings.SPACE_HEIGHT - 1);
                }
                else
                {
                    point.SetY(0);
                }
            }

        }

        public int GetY()
        {
            return point.GetY();
        }

    }
}