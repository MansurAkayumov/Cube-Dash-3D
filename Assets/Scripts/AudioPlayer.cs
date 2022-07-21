using UnityEngine;

public class AudioPlayer : MonoBehaviour 
{
    [SerializeField] private AudioClip[] _audioClips;
    [HideInInspector] public AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetClip(int count)
    {
        _audioSource.clip = _audioClips[count];
        _audioSource.Play();
        Invoke("SelfDestroy", _audioSource.clip.length);
    }

    private void SelfDestroy() => Destroy(gameObject);
}