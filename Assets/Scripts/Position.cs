using System;
using UnityEngine;

[Serializable]
public struct Position
{
    public static readonly Position Zero = new Position(0, 0);
    public static readonly Position Right = new Position(1, 0);
    public static readonly Position Up = new Position(0, 1);

    public int x;
    public int y;

    public Position (int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString ()
    {
        return string.Format("({0}, {1})", x, y);
    }

    public override int GetHashCode ()
    {
        return x ^ y;
    }

    public override bool Equals (object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Position && this == (Position) obj;
    }

    /// <summary>
    /// multiplies the x and y of the given position by a scale
    /// </summary>
    /// <param name="scalar">scale</param>
    /// <param name="position">position</param>
    /// <returns>scaled position</returns>
    public static Position operator * (int scalar, Position position)
    {
        return new Position(scalar * position.x, scalar * position.y);
    }

    /// <summary>
    /// Add the individiual components together
    /// </summary>
    /// <param name="a">a</param>
    /// <param name="b">b</param>
    /// <returns>(a.x+b.x, a.y+b.y)</returns>
    public static Position operator + (Position a, Position b)
    {
        return new Position(a.x + b.x, a.y + b.y);
    }

    /// <summary>
    /// Subtracts the individiual components together
    /// </summary>
    /// <param name="a">a</param>
    /// <param name="b">b</param>
    /// <returns>(a.x-b.x, a.y-b.y)</returns>
    public static Position operator - (Position a, Position b)
    {
        return new Position(a.x - b.x, a.y - b.y);
    }

    /// <summary>
    /// scales the position by -1
    /// </summary>
    /// <param name="position">position</param>
    /// <returns>(-p.x, -p.y</returns>
    public static Position operator - (Position position)
    {
        return new Position(-position.x, -position.y);
    }

    /// <summary>
    /// Returns true if the components are equal
    /// </summary>
    /// <param name="a">a</param>
    /// <param name="b">b</param>
    /// <returns>a.x == b.x && a.y == b.y</returns>
    public static bool operator == (Position a, Position b)
    {
        return a.x == b.x && a.y == b.y;
    }

    /// <summary>
    /// Returns true if the components are not equal
    /// </summary>
    /// <param name="a">a</param>
    /// <param name="b">b</param>
    /// <returns>a.x != b.x || a.y != b.y</returns>
    public static bool operator != (Position a, Position b)
    {
        return a.x != b.x || a.y != b.y;
    }

    public static implicit operator Position(Vector2 v)
    {
        return new Position(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
    }

    public static implicit operator Position(Vector3 v)
    {
        return new Position(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
    }

    public static implicit operator Vector2(Position p)
    {
        return new Vector2(p.x, p.y);
    }

    public static implicit operator Vector3(Position p)
    {
        return new Vector3(p.x, p.y);
    }
}
