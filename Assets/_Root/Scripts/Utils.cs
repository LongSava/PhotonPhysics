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

    public static async Task<T> InstantiateOrigin<T>(string path, Transform parent) where T : MonoBehaviour
    {
        var asset = await GetAsset<T>(path);

        var target = Object.Instantiate(asset, parent);
        target.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        return target;
    }
}
