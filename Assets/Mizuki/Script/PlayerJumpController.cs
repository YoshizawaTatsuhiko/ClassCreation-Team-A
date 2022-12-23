using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float _jumpPower = 55;
    Rigidbody _rb = default;
    bool _isGround = default;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var jump = Input.GetButtonDown("Jump");
        if (jump && _isGround == true)
        {
            //Debug.Log("Jump");
            _rb.AddForce(new Vector3(0, _jumpPower * 10, 0));
            _isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            _isGround = true;
        }
    }
}
