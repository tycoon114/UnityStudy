using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;



public class BlueArchiveMaterialSetter : MonoBehaviour
{
    // Assets �޴��� BlueArchiveMaterialSetter �׸��� �߰��Ѵ�
    [MenuItem("Assets/BlueArchiveMaterialSetter")]
    public static void Setup()
    {
        // ������Ʈ �信�� ���õ� ���׸����� �����´�
        List<Material> selectedMaterials = new List<Material>(
            Selection.GetFiltered(typeof(Material), SelectionMode.DeepAssets).OfType<Material>());

        // ���׸����� ���õ� ���� ������ ������ �߻��Ѵ�
        if (selectedMaterials.Count < 1)
        {
            Debug.LogWarning("No material selected.");
            return;
        }

        // ù ���׸����� �ִ� ������ ���߿� ������ �����Ѵ�
        string baseMatDir =
            Path.GetDirectoryName(AssetDatabase.GetAssetPath(selectedMaterials[0]));

        foreach (var mat in selectedMaterials)
        {
            Debug.Log("Material Name: " + mat.name);
            // ���̴��� "SimpleNiloToonURP"�� �����Ѵ�
            mat.shader = Shader.Find("SimpleURPToonLitExample(With Outline)");

            if (mat.name.Contains("_Face") || mat.name.Contains("_EyeMouth") || mat.name.Contains("_Eyebrow"))
            {
                // ���̴����� _IsFace �� True��
                mat.SetFloat("_IsFace", 1);
            }

            if (mat.name.Contains("_Hair") || mat.name.Contains("_Body") || mat.name.Contains("_Weapon") ||
                mat.name.Contains("_Shield"))
            {
                // Occulsion ����
                Texture2D occlusionMap = (Texture2D)AssetDatabase.LoadAssetAtPath(baseMatDir + "/Texture2D/" + mat.name + "_Mask.png", typeof(Texture2D));
                if (occlusionMap != null)
                {
                    mat.SetFloat("_UseOcclusion", 1);

                    // occlusionMap Texture Type to Normal Map : ��ָ��� �ƴ����� Linear �̹����� ������ �ؽ��� Ÿ���� Normal Map���� �������ش�
                    string path = AssetDatabase.GetAssetPath(occlusionMap);
                    TextureImporter ti = (TextureImporter)TextureImporter.GetAtPath(path);
                    ti.textureType = TextureImporterType.NormalMap;
                    ti.SaveAndReimport();

                    mat.SetTexture("_OcclusionMap",
                        (Texture2D)AssetDatabase.LoadAssetAtPath(baseMatDir + "/Texture2D/" + mat.name + "_Mask.png",
                            typeof(Texture2D)));
                    mat.SetVector("_OcclusionMapChannelMask", new Vector4(0, 1, 0, 0));
                    mat.SetFloat("_OcclusionRemapStart", 1);
                    mat.SetFloat("_OcclusionRemapEnd", 0.5f);
                }

            }
        }
        AssetDatabase.SaveAssets();
    }


}
