using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomRotateZConrtoller : MonoBehaviour
{
    [SerializeField, Tooltip("Room")]
    private GameObject _room = null;
    [SerializeField, Tooltip("")]
    private float _rotateTime = 1f;

    public void RoomRotateZ(float eulerZ)
    {
        Vector3 vec = new Vector3(0f, 0f, eulerZ);
        _room.transform.DORotate(vec, _rotateTime, RotateMode.Fast);
    }
}
