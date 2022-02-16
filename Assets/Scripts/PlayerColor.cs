using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private Material[] playerMaterials;

    private void OnCollisionEnter(Collision other)
    {
        var otherMaterial = other.transform.GetComponent<MeshRenderer>().sharedMaterial;
        foreach (var playerMaterial in playerMaterials)
        {
            if (playerMaterial == otherMaterial)
            {
                other.transform.GetComponent<CubeController>().SetDefaultMat();
                break;
            }   
        }
    }

    public Material[] GetMaterials()
    {
        return playerMaterials;
    }
}
