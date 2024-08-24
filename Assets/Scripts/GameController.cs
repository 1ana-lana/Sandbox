using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Pool _pool;

    [SerializeField]
    private Transform _spawnPoint;

    private async void Awake()
    {
        var obstaclePrefab = await _pool.GetGameObject("PrefabObstacle");
        var obstacle = Instantiate(obstaclePrefab, _spawnPoint.position, new Quaternion());

        var player = await _pool.GetPlayerController("Vehicle");
        player.transform.position = _spawnPoint.position;
    }
}
