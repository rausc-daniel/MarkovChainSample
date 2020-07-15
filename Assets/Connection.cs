using System;
using UnityEngine;

[Serializable]
public struct Connection
{
    [SerializeField] private Node _neighbor;

    public Node Neighbor => _neighbor;

    [SerializeField, Range(0, 1)] private float _probability;

    public float Probability => _probability;
}