using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public string urlBase = "https://github.com/keijiro/unity-shader-ab-test/raw/master/AssetBundles/";

    IEnumerator Start ()
    {
        var url = urlBase + CurrentTargetDirectoryName + "/Cube.unity3d";

        Caching.CleanCache ();

        while (!Caching.ready) {
            yield return null;
        }

        while (true) {
            var www = WWW.LoadFromCacheOrDownload(url, 1);
            yield return www;

            var go = Instantiate (www.assetBundle.mainAsset) as GameObject;
            yield return null;
            yield return null;

            Destroy (go);
            yield return null;
            yield return null;

            www.assetBundle.Unload(false);
            yield return null;
            yield return null;
        }
    }

    static string CurrentTargetDirectoryName {
        get {
            #if UNITY_IPHONE
            return "iPhone";
            #elif UNITY_ANDROID
            return "Android";
            #else
            return "WebPlayer";
            #endif
        }
    }
}