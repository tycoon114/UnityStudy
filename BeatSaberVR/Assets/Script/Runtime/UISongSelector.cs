using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISongSelector : MonoBehaviour
{
    [SerializeField]
    class SongInfo
    {
        public string songTitle;
        public GameObject songCard;
        public SongSpec songSpec;
    }

    private void Start()
    {
        for(int i = 0; i < _songInfos.Length; i++)
        {
            _songInfos[i].songCard.SetActive(i==_selectedIndex);
        }
        _songTitle.text = _songInfos[_selectedIndex].songSpec.SongName; // 초기 제목 설정
    }

    public int selectedIndex
    {
        get => _selectedIndex;
        set
        {
            _songInfos[_selectedIndex].songCard.SetActive(false); // 이전 카드 비활
            _selectedIndex = value;
            _songInfos[_selectedIndex].songCard.SetActive(true); // 새 카드 활성화
            _songTitle.text = _songInfos[_selectedIndex].songTitle; // 제목 업데이트   
        }
    }

    [SerializeField] TMP_Text _songTitle;
    [SerializeField] SongInfo[] _songInfos;
    [SerializeField] Button _next;
    [SerializeField] Button _prev;
    [SerializeField] Button _play;
    int _selectedIndex;


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
        selectedIndex = (_selectedIndex - 1 + _songInfos.Length) % _songInfos.Length;
    }

    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

}
