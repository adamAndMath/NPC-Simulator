using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class World : MonoBehaviour
{
    public static World Instance { get; private set; }

    private readonly Dictionary<Position, GameObject> Objects = new Dictionary<Position, GameObject>();

    public GameObject this[int x,  int y]
    {
        get { return this[new Position(x, y)]; }
        set { this[new Position(x, y)] = value; }
    }

    public GameObject this[Position p]
    {
        get { return Objects.ContainsKey(p) ? Objects[p] : null; }
        set
        {
            if (value == null)
            {
                Objects.Remove(p);
                return;
            }

            if (Objects.ContainsKey(p))
                throw new Exception(p + " is already ocupied");

            Objects.Add(p, value);
        }
    }

    void OnEnable()
    {
        Instance = this;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (Vector2 pos in Objects.Keys)
        {
            Gizmos.DrawLine(pos + new Vector2(-0.2F, -0.2F), pos + new Vector2(0.2F, 0.2F));
            Gizmos.DrawLine(pos + new Vector2(-0.2F, 0.2F), pos + new Vector2(0.2F, -0.2F));
        }
    }
}
