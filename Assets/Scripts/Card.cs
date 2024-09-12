using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int _idx = 0;

    public SpriteRenderer _front;

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
        _front.sprite = Resources.Load<Sprite>($"rtan{_idx}");
    }
}
