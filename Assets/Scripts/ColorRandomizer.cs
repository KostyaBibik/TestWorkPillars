using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorRandomizer : MonoBehaviour
{
    private readonly List<MeshRenderer> _cubes = new List<MeshRenderer>();
    [SerializeField] private Material[] materials;
    [SerializeField] private float timeInterval = 5f;
    
    private Material _defaultMaterial;
    private MovingController _movingController;
    
    private void Awake()
    {
        _movingController = FindObjectOfType<MovingController>();
        var controllers = FindObjectsOfType<CubeController>();
        foreach (var cubeController in controllers)
        {
            _cubes.Add(cubeController.GetComponent<MeshRenderer>());
        }
    }

    private void Start()
    {
        _defaultMaterial = _cubes[0].sharedMaterial;
        StartCoroutine(nameof(RandomizeColors));
    }
    
    private IEnumerator RandomizeColors()
    {
        do
        {
            yield return new WaitForSeconds(timeInterval);

            var randomCube =_cubes[Random.Range(0, _cubes.Count)];
            var randomColor = materials[Random.Range(0, materials.Length)];
            
            randomCube.sharedMaterial = randomColor;
            _movingController.FixTarget(randomCube.transform.position, randomColor);
            
            yield return new WaitUntil(() => randomCube.sharedMaterial == _defaultMaterial);
        } while (true);
    }
}



