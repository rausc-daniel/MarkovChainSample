using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private int _numberOfObjects;
    private bool _active;

    IEnumerator Cycle()
    {
        _active = true;
        
        for (var i = 0; i < 20; i++)
        {
            NodeManager.MoveNext();
            yield return new WaitForSeconds(0.1f);
        }

        _active = false;
    }

    public void Generate()
    {
        if(_active) return;

        StartCoroutine(Cycle());
    }
}