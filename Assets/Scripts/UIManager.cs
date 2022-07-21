using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _pausePanel;
    public GameObject _losePanel;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _recordText;
    private ScoreManager _scoreManager;
    private Timer _timer;

    private void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _timer = FindObjectOfType<Timer>();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void ExitSettings()
    {
        _settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenLosePanel()
    {
        _losePanel.SetActive(true);
        _timer.Run();
        _scoreText.text = "Score: " + _scoreManager._score;
        _recordText.text = "Best Score: " + _scoreManager._record;
        FindObjectOfType<CubeController>()._canMove = false;
    }

    public void CloseLosePanel()
    {
        _losePanel.SetActive(false);
    }
}
