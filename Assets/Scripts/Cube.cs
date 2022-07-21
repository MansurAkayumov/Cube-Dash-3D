using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour 
{
    private AudioManager _audioManager;
    private ScoreManager _scoreManager;
    private CubeController _cubeController;
    private CubeExplode _cubeExplode;
    private CubeValue _cubeValue;
    private Renderer _renderer;
    private Rigidbody _rigidbody;
    [HideInInspector] public bool _isCollided;
    private int _triggerOrder;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _cubeController = GameObject.Find("Player").GetComponent<CubeController>();
        _cubeExplode = GetComponent<CubeExplode>();
        _cubeValue = GetComponent<CubeValue>();
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Cube"))
        {
            if(!_isCollided)
            {
                _isCollided = true;
                _audioManager.Play(1);
                _rigidbody.constraints = RigidbodyConstraints.None;
                Destroy(transform.GetChild(6).gameObject);
                Vibrator.Instance.Vibrate();
            }

            if(Skill.Instance._isTeleportEnabled)
            {
                Skill.Instance._isTeleportEnabled = false;
                Cube[] cubes = FindObjectsOfType<Cube>();
                foreach (var cube in cubes)
                {
                    cube.GetComponent<BoxCollider>().enabled = true;
                    cube.GetComponent<Rigidbody>().isKinematic = false;
                    ColorManager.Instance.SetAlpha(cube.GetComponent<Renderer>().material, 1f);
                    ColorManager.Instance.SetTextAlpha(cube._cubeValue._valueTexts, 1f);
                }
            }
        }

        if(other.gameObject.CompareTag("Cube"))
        {
            if(_cubeValue._value == other.gameObject.GetComponent<CubeValue>()._value)
            {
                Destroy(other.gameObject);
                _isCollided = true;
                _audioManager.Play(0);
                _cubeValue.SetValue(_cubeValue._value + 1);
                _cubeExplode.Explode();
                _scoreManager.SetScore(_cubeValue._point);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("DeathZone"))
        {
            if(_triggerOrder > 0)
            {
                Lose();
            }
            else
                _triggerOrder++;
        }
    }

    private void Lose()
    {
        var uiManager = FindObjectOfType<UIManager>();
        uiManager.OpenLosePanel();
        _audioManager.Play(4);
        Invoke("FreezeController", 0.21f);
    }

    private void FreezeController()
    {
        _cubeController._boxCollider.enabled = false;
        _cubeController._canMove = false;
    }
}