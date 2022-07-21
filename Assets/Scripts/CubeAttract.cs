using UnityEngine;

public class CubeAttract : MonoBehaviour 
{
    [SerializeField] private GameObject _parentCube; 
    [SerializeField] private float _attractSpeed;
    private CubeValue _cubeValue;

    private void Start() 
    {
        _cubeValue = GetComponentInParent<CubeValue>();    
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            if(other.gameObject != _parentCube)
            {
                if(_cubeValue._value == other.gameObject.GetComponent<CubeValue>()._value)
                {
                    _parentCube.transform.position = Vector3.MoveTowards(_parentCube.transform.position, other.transform.position, _attractSpeed * Time.deltaTime);
                }
            }    
        }
    }    
}