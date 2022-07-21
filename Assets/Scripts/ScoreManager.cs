using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _recordText;

    [HideInInspector] public int _score;
    [HideInInspector] public int _record;

    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        _record = PlayerPrefs.GetInt("Record");
        if(_score > _record)
        {
            PlayerPrefs.SetInt("Record", _score);
            _record = PlayerPrefs.GetInt("Record");
        }
        _scoreText.text = _score.ToString();
        _recordText.text = "Best Score: " + _record;
    }

    public void SetScore(int score)
    {
        _score += score;
        UpdateScore();
    }

}