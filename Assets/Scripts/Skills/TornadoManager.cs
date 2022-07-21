using UnityEngine;
using UnityEngine.UI;

public class TornadoManager : MonoBehaviour
{
    [SerializeField] private GameObject _tornado;
    [SerializeField] private Text _amountText;
    private AudioManager _audioManager;
    private CubeSpawner _cubeSpawner;
    private int _amount;
    private bool _isOpened;

    private void Start() 
    {
        _amount = PlayerPrefs.GetInt("Tornado");
        UpdateAmount();
        _cubeSpawner = FindObjectOfType<CubeSpawner>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartingTornado()
    {
        if(_amount >= 1)
        {
            _cubeSpawner.SpawnTornadoCube();
            _amount--;
            UpdateAmount();
        }
    }

    public void SpawnTornado()
    {
        Instantiate(_tornado, _cubeSpawner.transform.position, Quaternion.identity);
        _audioManager.Play(5);
    }

    public void AddTornado()
    {
        _amount++;
        FindObjectOfType<NewCubeManager>().CloseNewCubePanel();
        UpdateAmount();
    }

    private void UpdateAmount()
    {
        _amountText.text = _amount.ToString();
        PlayerPrefs.SetInt("Tornado", _amount);
        Debug.Log("amount: " + _amount);
    }
}
