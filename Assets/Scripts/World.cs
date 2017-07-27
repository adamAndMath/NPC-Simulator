using System;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World Instance { get; private set; }

    private readonly Dictionary<Position, GameObject> Objects = new Dictionary<Position, GameObject>();

    public GameObject this[Position p]
    {
        get { return Objects[p]; }
        set
        {
            if (Objects.ContainsKey(p))
                throw new Exception(p + " is already ocupied");

            Objects.Add(p, value);
        }
    }

    void OnEnabled()
    {
        Instance = this;
    }
}
