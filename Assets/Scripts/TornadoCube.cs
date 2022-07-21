using UnityEngine;

public class TornadoCube : MonoBehaviour
{
    private TornadoManager _tornadoManager;
    private CubeExplode _cubeExplode;
    private bool once = false;

    private void Start()
    {
        _tornadoManager = FindObjectOfType<TornadoManager>();
        _cubeExplode = GetComponent<CubeExplode>();
        transform.GetChild(2).rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Cube"))
        {
            if(once == false)
            {
                once = true;
                _tornadoManager.SpawnTornado();
                Destroy(gameObject);
                _cubeExplode.Explode();
            }
        }
    }   
}
