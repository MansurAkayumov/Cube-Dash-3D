using UnityEngine;

public class Vibrator : MonoBehaviour 
{
    public static Vibrator Instance;
    [SerializeField] private GameObject _checkMark;
    private int _state = 1;

    private void Start() 
    {
        if(Instance == null)
            Instance = this;

        if(!PlayerPrefs.HasKey("Vibrator")) 
            PlayerPrefs.SetInt("Vibrator", 1); 
        _state = PlayerPrefs.GetInt("Vibrator");
        if(_state == 1)
            _checkMark.SetActive(true);
        else if(_state == 0)
            _checkMark.SetActive(false);
    }

    public void Vibrate()
    {
        if(_state == 1)
            Handheld.Vibrate();
    }

    public void StateChange()
    {
        if(_state == 1)
        {
            _state = 0;
            _checkMark.SetActive(false);
            PlayerPrefs.SetInt("Vibrator", 0);
        }
        else if(_state == 0)
        {
            _state = 1;
            _checkMark.SetActive(true);
            PlayerPrefs.SetInt("Vibrator", 1);
        }
    }
}