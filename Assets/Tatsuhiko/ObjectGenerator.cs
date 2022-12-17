using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("��������Q�[���I�u�W�F�N�g")]
    private GameObject[] _go = null;
    [SerializeField, Tooltip("�Q�[���I�u�W�F�N�g�̍ő吶����")]
    private float _maxQuantity = 1f;
    /// <summary></summary>
    private float _count = 0f;
    [SerializeField, Tooltip("�����Ԋu")]
    private float _interval = 1f;
    /// <summary>���Ԃ��v������^�C�}�[</summary>
    private float _timer = 0f;

    private void Start()
    {
        if (_go == null) Debug.LogWarning("��������Q�[���I�u�W�F�N�g��assign����Ă��܂���B");
    }

    private void FixedUpdate()
    {
        int n = Random.Range(0, _go.Length);
        if (_count < _maxQuantity)
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)
            {
                Instantiate(_go[n], transform);
                _timer = 0;
                _count++;
            }
            Debug.Log(_count);
        }

        else if (_count >= _maxQuantity && Count() == 0)
        {
            Debug.Log("�����I��");
        }
    }

    private int Count()
    {
        int count = 0;

        foreach (Transform child in transform)
        {
            count++;
        }
        return count;
    }
}
