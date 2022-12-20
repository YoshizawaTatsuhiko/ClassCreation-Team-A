using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _jumpPower = 3;
    Rigidbody _rb = default;
    bool _isGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        var jump = Input.GetButtonDown("Jump");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // �J�����̃��[�J�����W�n����� dir ��ϊ�����
        dir = Camera.main.transform.TransformDirection(dir);
        // �J�����͎΂߉��Ɍ����Ă���̂ŁAY ���̒l�� 0 �ɂ��āuXZ ���ʏ�̃x�N�g���v�ɂ���
        dir.y = 0;
        // �ړ��̓��͂��Ȃ����͉�]�����Ȃ��B���͂����鎞�͂��̕����ɃL�����N�^�[��������B
        if (dir != Vector3.zero) this.transform.forward = dir;
        //_rb.velocity = dir.normalized * _moveSpeed;
        //���������̑��x��ێ�����
        Vector3 velocity = dir.normalized * _moveSpeed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        if (jump && _isGround == true)
        {
            _rb.AddForce(new Vector3(0, _jumpPower * 10, 0));
            _isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
        
    }
}
