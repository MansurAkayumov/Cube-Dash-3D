using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private Transform _tornadoCenter;
    [SerializeField] private float _shotForce;
    [SerializeField] private float _pullForce;
    [SerializeField] private float _refreshRate;
    [SerializeField] private float _destroyTime;

    private void Start() 
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * _shotForce;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            StartCoroutine(PullObject(other, true));
            Invoke("SelfDestroy", _destroyTime);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            StartCoroutine(PullObject(other, false));
        }
    }

    private IEnumerator PullObject(Collider other, bool shouldPull)
    {
        if(shouldPull && other != null)
        {
            Vector3 direction = _tornadoCenter.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * _pullForce * Time.deltaTime);
            yield return _refreshRate;
            StartCoroutine(PullObject(other, shouldPull));
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
