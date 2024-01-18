using System.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class Utils
{
    public static async Task<T> GetAsset<T>(string path)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(path);
        await handle.Task;
        return handle.Result.GetComponent<T>();
    }

    public static async Task<T> InstantiateOrigin<T>(this NetworkRunner runner, string path, Transform parent) where T : MonoBehaviour
    {
        var asset = await GetAsset<T>(path);

        var target = runner.InstantiateInRunnerScene(asset);
        target.transform.SetParent(parent);
        target.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        return target;
    }

    public static void EnableComponentsInChildren<T>(this GameObject gameObject, bool enabled) where T : UnityEngine.Behaviour
    {
        var components = gameObject.GetComponentsInChildren<T>();
        if (components.Length > 0) foreach (var component in components) component.enabled = enabled;
    }

    public static void EnableGameObjectsInChildren<T>(this GameObject gameObject, bool enabled) where T : UnityEngine.Behaviour
    {
        var components = gameObject.GetComponentsInChildren<T>();
        if (components.Length > 0) foreach (var component in components) component.gameObject.SetActive(enabled);
    }
}
