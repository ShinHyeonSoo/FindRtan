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

    float _time = 0.0f;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _timeText.text = _time.ToString("N2");
    }

    public void Matched()
    {
        if (_firstCard._idx == _secondCard._idx)
        {
            _firstCard.DestroyCard();
            _secondCard.DestroyCard();
        }
        else
        {
            _firstCard.CloseCard();
            _secondCard.CloseCard();
        }

        _firstCard = null;
        _secondCard = null;
    }
}
