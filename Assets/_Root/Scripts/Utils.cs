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
}
