using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Vertex va = new Vertex(0, 0);
        Vertex vb = new Vertex(0, 1.1);
        Vertex vc = new Vertex(1.1, 1.1);
        var vd = Rectangles.FindFourthVertex(va, vb, vc);
        Console.Write(vd);
    }
}
public class Rectangles
{
    /// <summary>
    /// Find the fourth vertex of a rectangle 
    /// </summary>
    public static Vertex FindFourthVertex(Vertex va, Vertex vb, Vertex vc)
    {
        Vertex vd = null;
        if (getLastCoordinateIfRightAngle(va, vb, vc, out vd))//if B is at the right angle
        {
            //filtering or other housekeeping if not all coordinates can be candidates, or 
            //for example looking for largest by area..
        }
        else if (getLastCoordinateIfRightAngle(va, vc, vb, out vd))//if C is at the right angle
        {
        }
        else if (getLastCoordinateIfRightAngle(vb, va, vc, out vd))//if A is at the right angle
        {
        }
        return vd;
    }

    static bool isRighAngle(Vertex a, Vertex b, Vertex c)
    {
        bool bOkAB, bOkBC;
        bOkAB = (b - a).normalize(out var uAB);
        bOkBC = (c - b).normalize(out var uBC);

        return bOkAB && bOkBC && Math.Abs(uAB.dot(uBC)) < Vertex.MY_EPSILON;
    }

    static bool getLastCoordinateIfRightAngle(Vertex a, Vertex b, Vertex c, out Vertex d)
    {
        if (isRighAngle(a, b, c))
        {
            d = (a + c) - b;
            return true;
        }
        d = null;
        return false;
    }
}


public class Vertex
{
    public const double MY_EPSILON = 1E-6;
    public double X;
    public double Y;
    public Vertex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static Vertex operator +(Vertex a, Vertex b)
    {
        return new Vertex(a.X + b.X, a.Y + b.Y);
    }
    public static Vertex operator -(Vertex a, Vertex b)
    {
        return new Vertex(a.X - b.X, a.Y - b.Y);
    }

    public double dot(Vertex v) { return X * v.X + Y * v.Y; }
    public double length() { return Math.Sqrt(X * X + Y * Y); }
    public bool normalize(out Vertex normal)
    {
        double len = length();
        normal = null;
        if (len > MY_EPSILON)
        {
            normal = new Vertex(X / len, Y / len);
        }
        else return false;
        return true;
    }
    public override string ToString()
    {
        return "(" + X + ";" + Y + ")";
    }
}
