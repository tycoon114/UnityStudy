#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SongSpec))]
public class SongSpecEditor : Editor
{
    const float THRESHOLD_GAIN = 1.2f;
    AudioClip _cachedAudioClip;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SongSpec songSpec = (SongSpec)target;
        
        using (new EditorGUILayout.VerticalScope())
        { 
            EditorGUILayout.Space();

            

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Audio spectrum sampling", EditorStyles.boldLabel);
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                _cachedAudioClip = (AudioClip)EditorGUILayout.ObjectField("Audio clip",
                                                                          _cachedAudioClip,
                                                                          typeof(AudioClip),
                                                                          false);
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                if (_cachedAudioClip == null)
                {
                    EditorGUI.BeginDisabledGroup(true);
                }

                if (GUILayout.Button("Bake peaks"))
                {
                    List<float> peaks = ExtractPeaks(_cachedAudioClip, songSpec.bpm);
                    songSpec.BakePeaks(_cachedAudioClip, peaks);

                    EditorUtility.SetDirty(songSpec);
                    AssetDatabase.SaveAssets();
                }

                if (_cachedAudioClip == null)
                {
                    EditorGUI.EndDisabledGroup();
                }
            }
        }
    }

    List<float> ExtractPeaks(AudioClip clip, float bpm)
    {
        int sampleCount = clip.samples;
        int channelCount = clip.channels;
        float[] raw = new float[sampleCount * channelCount];
        clip.GetData(raw, 0);

        // ä�ε� ��� (��� ä�η� ���� ��ȯ)
        float[] mono = new float[sampleCount];

        for (int i = 0; i < sampleCount; i++)
        {
            float sum = 0f;

            for (int c = 0; c < channelCount; c++)
            {
                sum += raw[i * channelCount + c];
            }

            mono[i] = sum / channelCount;
        }

        // ���� �� Ȯ�ο� RMS (Root Mean Square)
        float windowSize = 24 * clip.frequency / bpm; // �߰� �������� �׽�Ʈ�ϸ鼭 ã�ƾ���
        int windowCount = sampleCount / Mathf.FloorToInt(windowSize);
        float[] rmsArr = new float[windowCount];
        float meanRms = 0f;

        for (int w = 0; w < windowCount; w++)
        {
            double acc = 0;
            int start = w * Mathf.FloorToInt(windowSize);

            for (int i = 0; i < windowSize; i++)
            {
                float s = mono[start + i];
                acc += s * s;
            }

            float rms = Mathf.Sqrt((float)(acc / windowSize));
            rmsArr[w] = rms;
            meanRms += rms;
        }

        meanRms /= windowCount;

        double stdSum = 0;
        // ǥ������
        for (int w = 0; w < windowCount; w++)
        {
            float d = rmsArr[w] - meanRms;
            stdSum = d * d;
        }

        stdSum /= (double)windowCount;
        float stdRms = Mathf.Sqrt((float)stdSum);

        // �Ӱ谪 (��հ� + �Ӱ��� * ǥ������)
        float threshold = meanRms + THRESHOLD_GAIN * stdRms;

        // �Ӱ谪 �̻� ����
        List<float> peaks = new List<float>();
        float windowSec = windowSize / (float)clip.frequency;

        for (int w = 0; w < windowCount; w++)
        {
            if (rmsArr[w] >= threshold)
            {
                float time = (w + 0.5f) * windowSec;
                peaks.Add(time);
            }
        }

        return peaks;
    }
}
#endif