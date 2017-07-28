using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Position size;

    private readonly List<Connection> connections = new List<Connection>();

    public Position Min { get { return transform.position; } }
    public Position Max { get { return Min + size; } }

    public void RegisterConnection(Connection connection)
    {
        connections.Add(connection);
    }

    public void RemoveConnection(Connection connection)
    {
        connections.Remove(connection);
    }

    void OnEnable()
    {
        Position pos = new Position();

        for (pos.x = Min.x; pos.x <= Max.x; pos.x++)
        {
            pos.y = Min.y;
            if (World.Instance[pos] == null && connections.All(con => con.position != pos))
                World.Instance[pos] = gameObject;
            pos.y = Max.y;
            if (World.Instance[pos] == null && connections.All(con => con.position != pos))
                World.Instance[pos] = gameObject;
        }

        for (pos.y = Min.y; pos.y <= Max.y; pos.y++)
        {
            pos.x = Min.x;
            if (World.Instance[pos] == null && connections.All(con => con.position != pos))
                World.Instance[pos] = gameObject;
            pos.x = Max.x;
            if (World.Instance[pos] == null && connections.All(con => con.position != pos))
                World.Instance[pos] = gameObject;
        }
    }

    void OnDisable()
    {
        for (int x = Min.x; x <= Max.x; x++)
        {
            if (World.Instance[x, Min.y] == gameObject)
                World.Instance[x, Min.y] = null;
            if (World.Instance[x, Max.y] == gameObject)
                World.Instance[x, Max.y] = null;
        }

        for (int y = Min.y + 1; y < Max.y; y++)
        {
            if (World.Instance[Min.x, y] == gameObject)
                World.Instance[Min.x, y] = null;
            if (World.Instance[Max.x, y] == gameObject)
                World.Instance[Max.x, y] = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * size.x);
        Gizmos.DrawLine(transform.position + Vector3.up * size.y, transform.position + (Vector3)size);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * size.y);
        Gizmos.DrawLine(transform.position + Vector3.right * size.x, transform.position + (Vector3)size);
    }
}
