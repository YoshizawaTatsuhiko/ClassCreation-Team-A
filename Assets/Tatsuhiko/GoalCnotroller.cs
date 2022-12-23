using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]

public class GoalCnotroller : MonoBehaviour
{
    /// <summary>GameManager</summary>
    private GameManager _gm = null;
    /// <summary>Collider</summary>
    private BoxCollider _boxCol = null;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _boxCol = GetComponent<BoxCollider>();
        _boxCol.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Player")
        {
            _gm.GameClear();
            Debug.Log("�Ă񂾁H");
        }
    }
}
