using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SongSpec))]
public class SongSpecEditor : Editor
{
    const float THRESHOLD_GAIN = 1.2f;
    AudioClip _cachedAudioClip;

    private override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SongSpec songSpec = (SongSpec)target;

        using (new EditorGUILayout.VerticalScope())
        {
            EditorGUILayout.Space();

            using (var scope = new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Song Name", EditorStyles.boldLabel);

                EditorGUILayout.ObjectField("Audio clip", _cachedAudioClip, typeof(AudioClip), false);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
            }
        }
        List<float> ExtractPeaks(AudioClip clip)
        {
            int sampleCount = clip.samples;
            int channelCount = clip.channels;
            float[] raw = new float[sampleCount * channelCount];
            clip.GetData(raw, 0);

            float[] mono = new float[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                float sum = 0f;
                for (int j = 0; j < channelCount; j++)
                {
                    sum += raw[i * channelCount + j];
                }
                mono[i] = sum / channelCount;
            }
            float windowSize = clip.frequency / bpm;
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

            double sum = 0;

            for (int w = 0; w < windowCount; w++)
            {
                float d = rmsArr[w] - meanRms;
                sum = d * d;
            }
            sum /= (double)windowCount;
            float stdRms = Mathf.Sqrt((float)sum);

            float threshold = meanRms + stdRms * THRESHOLD_GAIN;

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

            return null;
        }
    }
}
