using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    [SerializeField] private Image _timerDisplay;
    [SerializeField] private float _defaultTime;
    private float _timeRemaining;
    private bool _timeisRunning;

    public void Run()
    {
        _timeisRunning = true;
        _timeRemaining = _defaultTime;
    }

    private void Update() 
    {
        if(_timeisRunning)
        {
            if(_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                _timerDisplay.fillAmount = _timeRemaining / _defaultTime;
            }
            else
                StopTimer();
        }
    }

    private void StopTimer()
    {
        _timeisRunning = false;
        _timeRemaining = 0;
    }
}