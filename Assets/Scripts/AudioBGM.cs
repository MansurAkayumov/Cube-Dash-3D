using UnityEngine;

public class AudioBGM : MonoBehaviour 
{
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Play();
    }

    private void Play()
    {
        int rand = Random.Range(0, _audioClips.Length);
        _audioSource.clip = _audioClips[rand];
        _audioSource.Play();
    }
}