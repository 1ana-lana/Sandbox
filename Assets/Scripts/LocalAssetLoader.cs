using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LocalAssetLoader<T> : MonoBehaviour
{
    private AsyncOperationHandle<T> _handle;

    public async Task<T> LoadAssetAsync(string address)
    {
        _handle = Addressables.LoadAssetAsync<T>(address);

        await _handle.Task;

        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            return _handle.Result;
        }
        else
        {
            Debug.LogError("Failed to load asset: " + address);
            return default(T);
        }
    }

    protected void UnloadInternal()
    {
        if (_handle.Result == null) return;

        Addressables.Release(_handle);

        if (!_handle.IsValid())
        {
            Debug.Log("Handle is no longer valid. Unload likely succeeded.");
            _handle = default;
        }
        else
        {
            Debug.LogWarning("Handle is still valid. Unload may not have succeeded.");
        }
    }
}

