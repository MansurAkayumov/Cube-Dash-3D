using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioPlayerPrefab;
    [SerializeField] private GameObject _musicCheckMark;
    [SerializeField] private GameObject _soundCheckMark;
    [SerializeField] private AudioSource _musicSource;
    private AudioPlayer _audioPlayer;
    private bool _isSoundOn = true;
    private bool _isMusicOn = true;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Music")) 
            PlayerPrefs.SetInt("Music", 1);
        if(!PlayerPrefs.HasKey("Sound")) 
            PlayerPrefs.SetInt("Sound", 1);

        if(PlayerPrefs.GetInt("Music") == 1)
            _isMusicOn = true;
        else
            _isMusicOn = false;

        if(PlayerPrefs.GetInt("Sound") == 1)
            _isSoundOn = true;
        else
            _isSoundOn = false;

        if(_isMusicOn)
            _musicCheckMark.SetActive(true);
        else 
            _musicCheckMark.SetActive(false);

        if(_isSoundOn)
            _soundCheckMark.SetActive(true);
        else 
            _soundCheckMark.SetActive(false);
        _musicSource.volume = PlayerPrefs.GetInt("Music");
    }

    public void Play(int count)
    {
        if(_isSoundOn)
        {
            _audioPlayer = Instantiate(_audioPlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<AudioPlayer>();
            _audioPlayer.SetClip(count);
            _audioPlayer._audioSource.volume = PlayerPrefs.GetInt("Sound");
        }
    }

    public void MusicValueChange()
    {
        if(_isMusicOn)
        {
            _isMusicOn = false;
            _musicSource.volume = 0;
            PlayerPrefs.SetInt("Music", 0);
            _musicCheckMark.SetActive(false);
        }
        else if(!_isMusicOn)
        {
            _isMusicOn = true;
            _musicSource.volume = 1;
            PlayerPrefs.SetInt("Music", 1);
            _musicCheckMark.SetActive(true);
        }
    }

    public void SoundValueChange()
    {
        if(_isSoundOn)
        {
            _isSoundOn = false;
            PlayerPrefs.SetInt("Sound", 0);
            _soundCheckMark.SetActive(false);
        }
        else if(!_isSoundOn)
        {
            _isSoundOn = true;
            PlayerPrefs.SetInt("Sound", 1);
            _soundCheckMark.SetActive(true);
        }
    }
}
