using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomRotateXController : MonoBehaviour
{
    [SerializeField, Tooltip("Room")]
    private GameObject _room = null;
    [SerializeField, Tooltip("")]
    private float _rotateTime = 1f;

    public void RoomRotateX(float eulerX)
    {
        Vector3 vec = new Vector3(eulerX, 0f, 0f);
        _room.transform.DORotate(vec, _rotateTime, RotateMode.Fast);
    }
}
