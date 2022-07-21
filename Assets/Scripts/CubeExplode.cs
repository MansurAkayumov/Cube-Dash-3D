using UnityEngine;
using System.Collections.Generic;

public class CubeExplode : MonoBehaviour
{
    [SerializeField] private GameObject _explodeParticle;
    [SerializeField] private float _forceY;
    [SerializeField] private float _forceZ;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void Explode()
    {
        Instantiate(_explodeParticle, transform.position, Quaternion.identity);
        ForceCube();
        _animator.SetBool("isExplode", true);
    }

    private void ForceCube()
    {
        _rigidbody.velocity = new Vector3(0, _forceY, _forceZ);
    }

    public void Finish()
    {
        _animator.SetBool("isExplode", false);
    }
}
