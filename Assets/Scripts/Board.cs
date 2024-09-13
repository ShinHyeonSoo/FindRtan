using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject _card;

    GameObject[] cards;

    const int _size = 4;

    bool _isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        cards = new GameObject[_size * _size];

        for (int i = 0; i < _size * _size; ++i)
        {
            GameObject go = Instantiate(_card, transform);
            
            float x = (i % _size) * 1.4f - 2.1f;
            float y = (i / _size) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
            go.SetActive(false);
            go.GetComponent<Animator>().enabled = false;

            cards[i] = go;
        }

        GameManager._instance._cardCount = arr.Length;
    }

    // Update is called once per frame
    void Update()
    {
        GameStart();
    }

    void GameStart()
    {
        if(!_isStart)
        {
            StartCoroutine(CoroutineFlip());

            _isStart = true;
        }
    }

    IEnumerator CoroutineFlip()
    {
        int count = 0;

        while(count < _size * _size)
        {
            cards[count].SetActive(true);
            ++count;
            yield return new WaitForSeconds(0.1f);
        }

        GameManager._instance._isStart = true;

        for(int i = 0; i < _size * _size; ++i)
        {
            cards[i].GetComponent<Animator>().enabled = true;
        }

        yield return null;
    }
}
