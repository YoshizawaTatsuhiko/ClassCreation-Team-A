using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    Rigidbody _rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
         _rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //bool isClick;
        var click = Input.GetMouseButton(0);
        if (other.gameObject.tag == "Enemy" && click)
        {
            //Debug.Log("aaa");
            Destroy(other.gameObject);
        }
    }
}
