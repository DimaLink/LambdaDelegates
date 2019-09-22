using System;

namespace LambdaDelegates
{
    struct Element
    {
        Point point;
        string name;
        Type type;
        Status status;

        public Element(Point _point, string _name, Type _type, Status _status)
        {

            point = new Point(_point.GetX(), _point.GetY());
            name = _name;
            type = _type;
            status = _status;
        }

        public Point GetPoint()
        {
            return point;
        }

        public string GetName()
        {
            return name;
        }

        public Type GetType()
        {
            return type;
        }

        public Status GetStatus()
        {
            return status;
        }
    }
}