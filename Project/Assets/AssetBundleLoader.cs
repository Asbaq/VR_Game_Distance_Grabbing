using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoader : MonoBehaviour
{
    public string bundleURL;
    public string assetName = "YourAssetName";
    AssetBundle bundle;


    private void Start()
    {
        Debug.Log("Hi");
        StartCoroutine(DownloadAsset(bundleURL));
    }

    IEnumerator DownloadAsset(string assetUrl)
    {

        using (var uwr = UnityWebRequestAssetBundle.GetAssetBundle(assetUrl))
        {

            Debug.Log("www is using");

            uwr.SendWebRequest();

            if (uwr.error == "404" || uwr.error == "403" || uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("sda");
            }
            else
            {
                while (!uwr.isDone)
                {
                    yield return null;
                }

                bundle = ((DownloadHandlerAssetBundle)uwr.downloadHandler).assetBundle;
                if (bundle != null)
                {
                    Debug.Log("Bundle is not null");
                    // Prashant.Utils.loadedAssetBundles.Add(bundle.name, bundle);
                    Debug.Log("bundle.name " + bundle.name);
                    // Load Asset from AssetBundle
                    AssetBundleRequest assetLoadRequest = bundle.LoadAssetAsync<GameObject>(assetName);
                    yield return assetLoadRequest;

                    GameObject loadedAsset = assetLoadRequest.asset as GameObject;
                    Debug.Log("loadedAsset.name " + loadedAsset.name);
/*                    if (loadedAsset != null)
                    {
                        Instantiate(loadedAsset);
                        Debug.Log("Asset loaded and instantiated successfully");
                    }
                    else
                    {
                        Debug.LogError("Failed to load asset from bundle");
                    }*/
                }
                else
                {
                    Debug.Log("Bundle is null");
                }
            }
        }
    }
}
