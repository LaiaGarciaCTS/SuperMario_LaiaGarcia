using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip gameMusic;

    private AudioSource _audioSource;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartBGM();
    }


    void Start()
    {
        StartBGM();
    }


    void StartBGM()
    {
        _audioSource.loop = true;
        _audioSource.clip = gameMusic;
        _audioSource.Play();

        //_audioSource.Stop();
        //_audioSource.Pause();
    }

    public void Win()
    {
        _audioSource.Stop();
    }

    public void StopBGM()
    {
        _audioSource.Stop();
    }


}