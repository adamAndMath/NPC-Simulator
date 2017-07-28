using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Connection : MonoBehaviour
{
    public static readonly List<Connection> Connections = new List<Connection>();

    public Room roomA;
    public Room roomB;

    public Position position { get; private set; }

    void OnEnable()
    {
        if (!Application.isPlaying)
            return;
        
        Connections.Add(this);
        roomA.RegisterConnection(this);
        roomB.RegisterConnection(this);
        position = transform.position;

        if (World.Instance[position] == roomA.gameObject || World.Instance[position] == roomB.gameObject)
            World.Instance[position] = null;
    }

    void OnDisable()
    {
        Connections.Remove(this);
        roomA.RemoveConnection(this);
        roomB.RemoveConnection(this);
    }

    void Update()
    {
        if (roomA == null || roomB == null)
            return;

        if (roomA.Min.x == roomB.Max.x)
        {
            transform.position = new Vector3(roomA.Min.x, transform.position.y);
        }
        else if (roomA.Max.x == roomB.Min.x)
        {
            transform.position = new Vector3(roomB.Min.x, transform.position.y);
        }
        else if (roomA.Min.y == roomB.Max.y)
        {
            transform.position = new Vector3(transform.position.x, roomA.Min.y);
        }
        else if (roomA.Max.y == roomB.Min.y)
        {
            transform.position = new Vector3(transform.position.x, roomB.Min.y);
        }

        if (!Application.isPlaying)
            return;

        Position newPosition = transform.position;

        if (newPosition != position)
        {
            if (roomA.Min.x == position.x || roomA.Max.x == position.x)
            {
                if (roomA.Min.y <= position.y && position.y <= roomA.Max.y)
                {
                    World.Instance[position] = roomA.gameObject;
                }
                else if (roomB.Min.y <= position.y && position.y <= roomB.Max.y)
                {
                    World.Instance[position] = roomB.gameObject;
                }
            }
            else if (roomA.Min.y == position.y || roomA.Max.y == position.y)
            {
                if (roomA.Min.x <= position.x && position.x <= roomA.Max.x)
                {
                    World.Instance[position] = roomA.gameObject;
                }
                else if (roomB.Min.x <= position.x && position.x <= roomB.Max.x)
                {
                    World.Instance[position] = roomB.gameObject;
                }
            }

            if (World.Instance[newPosition] == roomA.gameObject || World.Instance[newPosition] == roomB.gameObject)
                World.Instance[newPosition] = null;

            position = newPosition;
        }
    }
}
