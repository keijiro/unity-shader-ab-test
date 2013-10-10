using UnityEngine;
using UnityEditor;

public class AssetBundleExporter
{
    [MenuItem("Assets/Build AssetBundle From Selection")]
    static void BuildAssetBundleFromSelection ()
    {
        string path = EditorUtility.SaveFilePanel ("Save Asset Bundle", "", "assets", "unity3d");
        if (path.Length != 0) {
            Object[] selection = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundle (Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, CurrentTargetPlatform);
            Selection.objects = selection;
        }
    }

    static BuildTarget CurrentTargetPlatform {
        get {
#if UNITY_IPHONE
            return BuildTarget.iPhone;
#elif UNITY_ANDROID
            return BuildTarget.Android;
#else
            return BuildTarget.WebPlayer;
#endif
        }
    }
}