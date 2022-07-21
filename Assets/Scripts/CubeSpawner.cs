using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [HideInInspector] public GameObject _lastSpawnedCube;
    [SerializeField] private GameObject _tornadoCube;
    [SerializeField] private GameObject _cube;
    [SerializeField] private int[] _valuesToSpawn;
    [SerializeField] private float _spawnDelay;
    public Transform _spawnPoint;

    private bool _once;

    private void Awake()
    {
        SpawnCube();
    }

    // private void Update()
    // {
    //     if(GameObject.Find("Player").GetComponent<CubeController>()._canMove == false)
    //     {
    //         if(_once)
    //         {
    //             _once = false;
    //             if(FindObjectOfType<UIManager>()._losePanel.activeSelf == false)
    //                 Invoke("SpawnCube", _spawnDelay);
    //         }
    //     }
    // }

    public void Spawn()
    {
        if(GameObject.Find("Player").GetComponent<CubeController>()._canMove == false)
        {
            if(_once)
            {
                _once = false;
                if(FindObjectOfType<UIManager>()._losePanel.activeSelf == false)
                    Invoke("SpawnCube", _spawnDelay);
            }
        }
    }

    public void SpawnTornadoCube()
    {
        Destroy(_lastSpawnedCube);
        _lastSpawnedCube = Instantiate(_tornadoCube, _spawnPoint.position, Quaternion.identity);
        _once = true;
    }

    private void SpawnCube()
    {
        int rand = Random.Range(0, _valuesToSpawn.Length);
        _lastSpawnedCube = Instantiate(_cube, _spawnPoint.position, Quaternion.identity);
        _lastSpawnedCube.GetComponent<CubeValue>().SetValue(_valuesToSpawn[rand]);
        _once = true;
    }
}
