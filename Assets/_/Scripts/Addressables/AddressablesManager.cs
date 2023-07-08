using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;

[Serializable]
public class AssetLoadSuccessEvent : UnityEvent<List<ScriptableObject>> { }

public class AddressablesManager : MonoBehaviour
{
    [SerializeField]
    private List<string> addressableLabels = new List<string> {};
    private AsyncOperationHandle<IList<ScriptableObject>> addressableLoadHandle;
    private List<ScriptableObject> data = new List<ScriptableObject> {};

    [SerializeField]
    protected AssetLoadSuccessEvent OnAssetLoadSuccess;



    private void Awake()
    {
        this.LoadAddressablesAsync();
    }

    private void OnDestroy() {
        // Release all the loaded assets associated with the given load handle
        Addressables.Release(addressableLoadHandle);
    }

    private void LoadAddressablesAsync()
    {
        this.addressableLoadHandle = Addressables.LoadAssetsAsync<ScriptableObject>(
            this.addressableLabels,         // Either a single key or list of keys
            null,                           // Callback that gets called for every loaded asset
            Addressables.MergeMode.Union,   // How to combine multiple labels
            false                           // Whether to fail if any asset fails to load
        );

        addressableLoadHandle.Completed += this.OnFinishLoading;
    }

    private void OnFinishLoading(AsyncOperationHandle<IList<ScriptableObject>> operation) 
    {
        if (operation.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Some assets did not load.");
        }

        else
        {
            this.data = (List<ScriptableObject>)operation.Result;
            Debug.Log("Loaded " + this.data.Count + " assets.");
            TryCallOnAssetLoadSuccessEvent();
        }
    }

    private void TryCallOnAssetLoadSuccessEvent()
    {
        if (this.OnAssetLoadSuccess != null)
        {
            this.OnAssetLoadSuccess.Invoke(this.data);
        }
    }
}
