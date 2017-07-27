using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Connection : MonoBehaviour
{
    public static readonly List<Connection> Connections = new List<Connection>();

    public Room roomA;
    public Room roomB;

    void OnEnable()
    {
        if (Application.isPlaying)
            Connections.Add(this);
    }

    void OnDisable()
    {
        Connections.Remove(this);
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
    }
}
