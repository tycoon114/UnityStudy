using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuilds
{
    //�����Ϳ� �޴��� ������ִ� ���
    [MenuItem("Asset Bundle/Build")]
    public static void AssetBundleBuild() {
        ////���� ������ ��ġ
        //string directory = "./Bundle";

        ////���丮�� ���ٸ� ���丮�� ����
        //if (!Directory.Exists(directory)) { 

        //    Directory.CreateDirectory(directory);
        //}
        ////�ش� ��ο� ���� ���鿡 ���� ������ ���� �÷����� �����ؼ� ���带 �����ϴ� �ڵ�
        //BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        BuildPipeline.BuildAssetBundles("Assets/Bundles",BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows);


        //�����Ϳ��� �����ִ� ���̾�α�(Ÿ��Ʋ,����,Ȯ�θ޼���)
        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle Build Complite", "comp[lite");

    }
}
