using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    /// <summary></summary>
    private GameObject _player = null;
    [SerializeField, Tooltip("")]
    private float _speed = 1f;
    /// <summary></summary>
    private Rigidbody _rb = null;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        Vector3 vec = _player.transform.position - transform.position;
        vec.y = 0;
        transform.forward = vec;
        _rb.velocity = transform.forward * _speed;
        Vector2 playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 selfPos = new Vector2(transform.position.x, transform.position.z);
        if (Vector2.Distance(playerPos, selfPos) < 0.2f)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
