﻿using UnityEngine;

public class Room : MonoBehaviour
{
    public Position size;

    public Position Min { get { return transform.position; } }
    public Position Max { get { return Min + size; } }

    void OnDrawGizmos ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * size.x);
        Gizmos.DrawLine(transform.position + Vector3.up * size.y, transform.position + (Vector3)size);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * size.y);
        Gizmos.DrawLine(transform.position + Vector3.right * size.x, transform.position + (Vector3)size);
    }
}
