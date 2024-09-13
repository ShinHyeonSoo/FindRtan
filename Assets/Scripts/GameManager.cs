using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public Card _firstCard;
    public Card _secondCard;

    public Text _timeText;
    public GameObject _endText;

    AudioSource _audioSource;
    public AudioClip _clip;
    public AudioClip _incorrectClip;

    public int _cardCount = 0;
    float _time = 0.0f;

    public bool _isStart = false;
    bool _isHurry = false;
    bool _isEnd = false;
    bool _isGameOver = false;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
            return;

        if (!_isEnd)
        {
            _time += Time.deltaTime;
            _timeText.text = _time.ToString("N2");

            if(!_isHurry && _time >= 20.0f)
            {
                AudioManager._instance.ChangeBgm(AudioManager.audioType.TIMER);
                _isHurry = true;
            }

            if (_time >= 30.0f)
                EndGame();
        }
    }

    public void Matched()
    {
        Invoke("InvokeMatched", 0.5f);
    }

    void InvokeMatched()
    {
        if (_firstCard._idx == _secondCard._idx)
        {
            _audioSource.PlayOneShot(_clip);
            _firstCard.DestroyCard();
            _secondCard.DestroyCard();
            _cardCount -= 2;

            if (_cardCount == 0)
            {
                _isEnd = true;
                Invoke("EndGame", 1.0f);
            }
        }
        else
        {
            _audioSource.PlayOneShot(_incorrectClip);
            _firstCard.CloseCard();
            _secondCard.CloseCard();
        }

        _firstCard = null;
        _secondCard = null;
    }

    void EndGame()
    {
        if (!_isGameOver)
        {
            AudioManager._instance.ChangeBgm(AudioManager.audioType.GAMEOVER);
            Time.timeScale = 0.0f;
            _endText.SetActive(true);

            _isGameOver = true;
        }
    }
}
