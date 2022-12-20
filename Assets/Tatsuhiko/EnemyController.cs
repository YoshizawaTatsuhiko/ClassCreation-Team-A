using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    /// <summary>Player�̃Q�[���I�u�W�F�N�g</summary>
    private GameObject _player = null;
    [SerializeField, Tooltip("�ړ����x")]
    private float _speed = 1f;
    /// <summary>Enemy��Rigidbody</summary>
    private Rigidbody _rb = null;

    private void Start()
    {
        //Player�������Ă���
        _player = GameObject.FindGameObjectWithTag("Player");

        //Enemy���g��Rigidbody���擾���Ă���
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        //Player�̕����ɐi�ށB
        Vector3 vec = _player.transform.position - transform.position;
        vec.y = 0;
        transform.forward = vec;
        _rb.velocity = transform.forward * _speed;

        //Player�Ɉ�苗���߂Â�����A�~�܂�B
        Vector2 playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 selfPos = new Vector2(transform.position.x, transform.position.z);
        if (Vector2.Distance(playerPos, selfPos) < 0.2f)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
