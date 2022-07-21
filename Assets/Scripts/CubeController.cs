using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _freezeDelay;
    [SerializeField] private float _force;
    private AudioManager _audioManager;
    private GameObject _movableObject;
    private GameObject _prompt;
    private Transform _rightBorder;
    private Transform _leftBorder;
    private Rigidbody _rigidbody;
    private float _mousePositionZ;
    [HideInInspector] public BoxCollider _boxCollider;
    [HideInInspector] public bool _canMove;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _rightBorder = GameObject.Find("RightBorder").GetComponent<Transform>();
        _leftBorder = GameObject.Find("LeftBorder").GetComponent<Transform>();
        _canMove = true;
    }

    private void OnMouseDown()
    {
        _movableObject = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>()._lastSpawnedCube;
        _rigidbody = _movableObject.GetComponent<Rigidbody>();
        if(_movableObject.transform.childCount > 5)
            _prompt = _movableObject.transform.GetChild(6).gameObject;
        else
            _prompt = _movableObject.transform.GetChild(1).gameObject;
        _mousePositionZ = Camera.main.WorldToScreenPoint(_movableObject.transform.position).z;
    }   

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mousePositionZ;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if(_canMove)
        {
            _movableObject.transform.position = GetMouseWorldPos();
            Vector3 freezePosition = new Vector3(_movableObject.transform.position.x, 1f, -5.25f);
            _movableObject.transform.position = freezePosition;

            if (_movableObject.transform.position.x > _rightBorder.position.x)
                _movableObject.transform.position = _rightBorder.position;
            else if (_movableObject.transform.position.x < _leftBorder.position.x)
                _movableObject.transform.position = _leftBorder.position;
        }
    }

    private void OnMouseUp()
    {
        if(_canMove)
        {
            Destroy(_prompt);
            _audioManager.Play(2);
            _rigidbody.velocity = Vector3.forward * _force;
            _boxCollider.enabled = false;
            _canMove = false;
            _movableObject.GetComponent<BoxCollider>().enabled = true;
            FindObjectOfType<CubeSpawner>().Spawn();
            Invoke("CanMove", _freezeDelay);
        }
    }

    public void CanMove()
    {
        _canMove = true;
        _boxCollider.enabled = true;
    }
}