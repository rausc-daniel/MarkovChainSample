using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private static readonly Dictionary<Node, List<Connection>> NodeCache = new Dictionary<Node, List<Connection>>();
    private static readonly List<Node> NodeList = new List<Node>();
    private static Node _currentNode = null;
    private static readonly System.Random Rnd = new System.Random();

    public static void Register(Node node, List<Connection> con)
    {
        NodeList.Add(node);
        NodeCache.Add(node, con);
    }

    public static void MoveNext()
    {
        if (_currentNode == null) _currentNode = NodeList[Random.Range(0, NodeList.Count)];
        var next = Rnd.NextDouble();
        float current = 0;

        for (var i = 0; i < NodeCache[_currentNode].Count; i++)
        {
            if (next > current && next < NodeCache[_currentNode][i].Probability + current)
            {
                //Testing 1L
                var tmp = _currentNode;
                _currentNode = NodeCache[_currentNode][i].Neighbor;
                //Testing 1L
                Debug.Log(
                    $"Moved: Node{tmp.name} -> Node{_currentNode.name}, with {current:F}/{next:F}/{NodeCache[tmp][i].Probability + current:F}");
                _currentNode.Act();
                return;
            }
            current += NodeCache[_currentNode][i].Probability;
        }
    }
}