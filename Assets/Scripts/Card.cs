using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int _idx = 0;

    public GameObject _front;
    public GameObject _back;

    public Animator _anim;

    public SpriteRenderer _frontImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        _idx = number;
        _frontImage.sprite = Resources.Load<Sprite>($"rtan{_idx}");
    }

    public void OpenCard()
    {
        _anim.SetBool("isOpen", true);
        _front.SetActive(true);
        _back.SetActive(false);

        if(GameManager._instance._firstCard == null )
        {
            GameManager._instance._firstCard = this;
        }
        else
        {
            GameManager._instance._secondCard = this;
            GameManager._instance.Matched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        _anim.SetBool("isOpen", false);
        _front.SetActive(false);
        _back.SetActive(true);
    }
}
