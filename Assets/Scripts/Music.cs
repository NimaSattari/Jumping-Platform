using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] public AudioClip[] myMusic;
    [SerializeField] static Music instance; 
    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = myMusic[0] as AudioClip;
    }
    void Start()
    {
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_audioSource.isPlaying)
            playRandomMusic();
    }
    void playRandomMusic()
    {
        _audioSource.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        _audioSource.Play();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}