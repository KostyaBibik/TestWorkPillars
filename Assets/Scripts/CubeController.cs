using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Material _defaultMaterial;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _defaultMaterial = _meshRenderer.sharedMaterial;
    }

    public void SetDefaultMat()
    {
        _meshRenderer.material = _defaultMaterial;
    }
}
