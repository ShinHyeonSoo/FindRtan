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

    AudioSource _audioSource;
    public AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
        if (!GameManager._instance._isStart) return;
        if (GameManager._instance._secondCard != null) return;

        _audioSource.PlayOneShot(_clip);
        _anim.SetBool("isOpen", true);
        //_front.SetActive(true);
        //_back.SetActive(false);
        Invoke("InvokeFlip", 0.35f);

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
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        _anim.SetBool("isOpen", false);
        _front.SetActive(false);
        _back.SetActive(true);
    }
    void InvokeFlip()
    {
        _front.SetActive(true);
        _back.SetActive(false);
    }
}
