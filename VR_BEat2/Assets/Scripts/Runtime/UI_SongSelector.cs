using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SongSelector : MonoBehaviour
{
    [Serializable]
    class SongInfo
    {
        public GameObject songCard;
        public SongSpec songSpec;
    }

    public int selectedIndex
    {
        get => _selectedIndex;
        set
        {
            _songInfos[_selectedIndex].songCard.SetActive(false); // ���� ī�� ��Ȱ��ȭ
            _selectedIndex = value;
            _songInfos[_selectedIndex].songCard.SetActive(true); // ���� ī�� Ȱ��ȭ
            _songTitle.text = _songInfos[_selectedIndex].songSpec.title; // �뷡���� �ٲ���
        }
    }


    [SerializeField] TMP_Text _songTitle;
    [SerializeField] SongInfo[] _songInfos;
    [SerializeField] Button _next;
    [SerializeField] Button _prev;
    [SerializeField] Button _play;
    int _selectedIndex;


    private void Start()
    {
        for (int i = 0; i < _songInfos.Length; i++)
        {
            _songInfos[i].songCard.SetActive(i == _selectedIndex);
        }

        _songTitle.text = _songInfos[_selectedIndex].songSpec.title;
    }

    private void OnEnable()
    {
        _next.onClick.AddListener(Next);
        _prev.onClick.AddListener(Prev);
        _play.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _next.onClick.RemoveListener(Next);
        _prev.onClick.RemoveListener(Prev);
        _play.onClick.RemoveListener(Play);
    }

    public void Next()
    {
        selectedIndex = (_selectedIndex + 1) % _songInfos.Length;
    }

    public void Prev()
    {
        selectedIndex = (_selectedIndex + _songInfos.Length - 1) % _songInfos.Length;
    }

    public void Play()
    {
        GameManager.gameSession.selectedSongSpec = _songInfos[_selectedIndex].songSpec;
        SceneManager.LoadScene("InGame");
    }
}
