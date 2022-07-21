using UnityEngine;

public class Respawner : MonoBehaviour 
{
    private SphereCollider _sphereCollider;
    private bool _isEnabled;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            if(_isEnabled)
            {
                Destroy(other.gameObject);
                Invoke("DisableCollider", 1.5f);
            }
        }
    }

    public void Respawn()
    {
        _isEnabled = true;
        _sphereCollider.enabled = true;
        FindObjectOfType<UIManager>().CloseLosePanel();
        FindObjectOfType<CubeController>().CanMove();
    }

    private void DisableCollider()
    {
        _isEnabled = false;
        _sphereCollider.enabled = false;
    }
}