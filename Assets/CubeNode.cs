using System.Collections;
using UnityEngine;

public class CubeNode : Node
{
    [SerializeField] private Material _active;
    [SerializeField] private Material _inactive;

    private MeshRenderer _meshRenderer;

    protected override void Awake()
    {
        base.Awake();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void Act()
    {
        IEnumerator Flash()
        {
            _meshRenderer.material = _active;
            
            yield return new WaitForSeconds(0.1f);
            
            _meshRenderer.material = _inactive;
        }

        StartCoroutine(Flash());
    }
}