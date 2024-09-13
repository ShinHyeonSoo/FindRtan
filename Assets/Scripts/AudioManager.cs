using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    AudioSource _audioSource;
    public AudioClip[] _clip;

    public enum audioType
    {
        MAIN,
        TIMER,
        GAMEOVER,
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        //_audioSource.clip = _clip;
        //_audioSource.Play();
        ChangeBgm(audioType.MAIN);
    }

    public void ChangeBgm(audioType index)
    {
        _audioSource.Stop();
        _audioSource.clip = _clip[(int)index];
        _audioSource.Play();
    }
}
