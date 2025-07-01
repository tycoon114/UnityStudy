using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "SongSpec", menuName = "Scriptable Objects/SongSpec")]
public class SongSpec : ScriptableObject
{
    [field: SerializeField] public string SongName { get; private set; }
    [field: SerializeField] public float BPM { get; private set; }
    public AudioClip AudioClip { get; private set; }
    public List<float> Peaks { get; private set; }
}
