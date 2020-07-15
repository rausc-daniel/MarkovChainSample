using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    [SerializeField] private List<Connection> _connections = new List<Connection>();

    protected virtual void Awake()
    {
        if (CheckConnections())
        {
            NodeManager.Register(this, _connections);
        }
    }

    private bool CheckConnections()
    {
        float temp = 0;

        foreach (var c in _connections)
        {
            temp += c.Probability;
        }

        return !(temp < 1 && temp > 1);
    }

    public abstract void Act();
}