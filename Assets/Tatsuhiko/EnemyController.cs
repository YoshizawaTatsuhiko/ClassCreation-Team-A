using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    /// <summary>Playerのゲームオブジェクト</summary>
    private GameObject _player = null;
    [SerializeField, Tooltip("移動速度")]
    private float _speed = 1f;
    /// <summary>EnemyのRigidbody</summary>
    private Rigidbody _rb = null;

    private void Start()
    {
        //Playerを見つけておく
        _player = GameObject.FindGameObjectWithTag("Player");

        //Enemy自身のRigidbodyを取得しておく
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        //Playerの方向に進む。
        Vector3 vec = _player.transform.position - transform.position;
        vec.y = 0;
        transform.forward = vec;
        _rb.velocity = transform.forward * _speed;

        //Playerに一定距離近づいたら、止まる。
        Vector2 playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 selfPos = new Vector2(transform.position.x, transform.position.z);
        if (Vector2.Distance(playerPos, selfPos) < 0.2f)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
