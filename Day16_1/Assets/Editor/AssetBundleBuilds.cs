using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuilds
{
    //에디터에 메뉴를 등록해주는 기능
    [MenuItem("Asset Bundle/Build")]
    public static void AssetBundleBuild() {
        ////현재 번들의 위치
        //string directory = "./Bundle";

        ////디렉토리가 없다면 디렉토리를 생성
        //if (!Directory.Exists(directory)) { 

        //    Directory.CreateDirectory(directory);
        //}
        ////해당 경로에 에셋 번들에 대한 설정과 빌드 플랫폼을 설정해서 빌드를 진행하는 코드
        //BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        BuildPipeline.BuildAssetBundles("Assets/Bundles",BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows);


        //에디터에서 보여주는 다이얼로그(타이틀,내용,확인메세지)
        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle Build Complite", "comp[lite");

    }
}
