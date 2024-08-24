using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Pool : LocalAssetLoader<GameObject>
{
    private GameObjectAssetLoader _gameObjectAssetLoader;

    public async Task<GameObject> GetGameObject(string path)
    {
        var gameObject = await LoadAssetAsync(path);
        //UnloadInternal();
        return gameObject;
    }

    public async Task<PlayerController> GetPlayerController(string path)
    {
        var playerController = await _gameObjectAssetLoader.Load<PlayerController>(path);
        return playerController;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _gameObjectAssetLoader.Unload();
        }
    }


}
