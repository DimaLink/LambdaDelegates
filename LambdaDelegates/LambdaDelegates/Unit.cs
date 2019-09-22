using System;

namespace LambdaDelegates
{
    struct Unit
    {

        private UnitType type;
        private Point point;

        public Unit(UnitType _type, Point _point)
        {
            type = _type;
            point = _point;
        }

        public void SetData(UnitType _type, Point _point)
        {
            type = _type;
            point = _point;
        }

        public void SetType(UnitType _type)
        {
            type = _type;
        }

        public UnitType GetType()
        {
            return type;
        }

        public void SetPoint(Point _point)
        {
            point = _point;
        }

        public Point GetPoint()
        {
            return point;
        }
    }
}