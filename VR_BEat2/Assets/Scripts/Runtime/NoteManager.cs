using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] GameObject _notePrefab;
    [SerializeField] Vector2 _spawnRange = new Vector2(1f, 1f);
    List<float> _peaks;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _peaks = GameManager.gameSession.selectedSongSpec.peaks;
        StartSpawn();
    }

    public void StartSpawn()
    { 
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        int index = 0;
        float playTime = _audioSource.clip.length;
        float playSpeed = GameManager.gameSession.playSpeed;

        while (index < _peaks.Count)
        {

            while (true)
            {
                if (_audioSource.time >= _peaks[index])
                {
                    GameObject note = Instantiate(_notePrefab);
                    int x = Random.Range(-1, 2);
                    int y = Random.Range(-1, 2);
                    note.transform.position = new Vector3(x * _spawnRange.x / 2f, y * _spawnRange.y / 2f, _peaks[index] * playSpeed);
                    index++;
                }
                else
                {
                    break;
                }
            }
            yield return null;
        }
    }
}
