using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Utils : MonoBehaviour
{
    public static async Task<T> GetAsset<T>(string path)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(path);
        await handle.Task;
        return handle.Result.GetComponent<T>();
    }
}
