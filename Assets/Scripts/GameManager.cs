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

    public int _cardCount = 0;
    float _time = 0.0f;

    bool _isEnd = false;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnd)
        {
            _time += Time.deltaTime;
            _timeText.text = _time.ToString("N2");

            if (_time >= 30.0f)
                EndGame();
        }
    }

    public void Matched()
    {
        if (_firstCard._idx == _secondCard._idx)
        {
            _firstCard.DestroyCard();
            _secondCard.DestroyCard();
            _cardCount -= 2;

            if(_cardCount == 0)
            {
                _isEnd = true;
                Invoke("EndGame", 1.0f);
            }
        }
        else
        {
            _firstCard.CloseCard();
            _secondCard.CloseCard();
        }

        _firstCard = null;
        _secondCard = null;
    }

    void EndGame()
    {
        Time.timeScale = 0.0f;
        _endText.SetActive(true);
    }
}
