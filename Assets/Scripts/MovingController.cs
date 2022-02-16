using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingController : MonoBehaviour
{
    private List<PlayerColor> _players = new List<PlayerColor>();
    private float _distanceToTarget = 0.05f;
    
    [SerializeField]private float speed = 1f;

    private void Awake()
    {
        var playersColors = FindObjectsOfType<PlayerColor>();
        foreach (var player in playersColors)
        {
            _players.Add(player);
        }
    }

    public void FixTarget(Vector3 target, Material fixMaterial)
    {
        List<GameObject> correctPlayers = new List<GameObject>();
        foreach (var player in _players)
        {
            foreach (var playerMaterial in player.GetMaterials())
            {
                if (playerMaterial == fixMaterial)
                {
                    correctPlayers.Add(player.gameObject);
                }
            }
        }
        
        StartCoroutine(StartMove(correctPlayers[Random.Range(0, correctPlayers.Count)].transform, target));
    }

    private IEnumerator StartMove(Transform movingObj, Vector3 target)
    {
        var startPosition = movingObj.position;
        var direction = target - startPosition;

        yield return Move(movingObj, direction, target);
        
        direction = startPosition - movingObj.position;
        
        yield return Move(movingObj, direction, startPosition);
    }

    private IEnumerator Move(Transform movingObj, Vector3 direction, Vector3 target)
    {
        while (Vector3.Distance(movingObj.position, target) > _distanceToTarget)
        {
            movingObj.Translate(
                (direction.x * speed * Time.deltaTime),
                (direction.y * speed * Time.deltaTime),
                (direction.z * speed * Time.deltaTime),
                Space.World);
            
            yield return null;
        }
    }
}
