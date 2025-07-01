using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MapAudioEqualizerEffector : MonoBehaviour
{
    [SerializeField] GameObject _unitPrefab;
    [SerializeField] float _unitLengthZ = 1f;
    [SerializeField] Vector3 _spawningOffset;
    [SerializeField, Range(64, 512)] int _spawnCount = 128;
    [SerializeField] float _scaleYMax = 5f;
    [SerializeField] float _gamma = 2f;
    [SerializeField] bool _doShuffle = true;


    AudioSource _source;
    Transform[] _spawnedUnits;
    float[] _spectrumData;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _spawnedUnits = new Transform[_spawnCount];
        _spectrumData = new float[_spawnCount];

        for (int i = 0; i < _spawnCount; i++)
        {
            Transform spawned = Instantiate(_unitPrefab).transform;
            spawned.position = _spawningOffset + new Vector3(0, 0, i * _unitLengthZ);
            _spawnedUnits[i] = spawned;
        }
    }

    private void Update()
    {
        _source.GetSpectrumData(_spectrumData, 0, FFTWindow.Hamming);

        if(_doShuffle)
        {
            _spectrumData.Shuffle();
            _doShuffle = false;

        }

        _spectrumData[0] = _spectrumData[_spawnCount - 1] = 0f;
        _spawnedUnits[0].localScale = _spawnedUnits[_spawnCount - 1].localScale = new Vector3(1, 0.01f, 0.01f);

        for (int i = 0; i < _spawnCount; i++)
        {
            _spectrumData[i] = Mathf.Log(_spectrumData[i] + 1f, 2);  // todo: MAx scale�� �����ؾ���
            _spectrumData[i] = Mathf.Pow(_spectrumData[i], _gamma);
            _spectrumData[i] = (_spectrumData[i - 1] + _spectrumData[i] + _spectrumData[i + 1]) / 3f; // smoothing
            float prevScaleY = _spawnedUnits[i].localScale.y;
            _spawnedUnits[i].localScale = new Vector3(1, Mathf.Lerp(prevScaleY, _spectrumData[i], Time.deltaTime * 30f), 1);

        }
    }
}
