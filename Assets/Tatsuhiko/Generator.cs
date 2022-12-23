using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("��������Q�[���I�u�W�F�N�g")]
    private GameObject[] _go = null;
    [SerializeField, Tooltip("�Q�[���I�u�W�F�N�g�̍ő吶����")]
    private float _maxQuantity = 1f;
    /// <summary>�ő吶�����̃v���p�e�B</summary>
    public float MaxQuantity{ get => _maxQuantity; }
    /// <summary>���񐶐�������������ϐ�</summary>
    private float _count = 0f;
    /// <summary>�����񐔂̃v���p�e�B</summary>
    public float Count { get => _count; }
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
        if (Count < _maxQuantity)  // �I�u�W�F�N�g�𐶐������񐔂��K��񐔖�����������A��������B
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)  // �^�C�}�[���C���^�[�o���ȏ�ɂȂ�����A��������B
            {
                Instantiate(_go[n], transform);
                _timer = 0;
                _count++;
                Debug.Log(_count);
            }
        }

        else if (_count >= _maxQuantity && transform.childCount == 0)
        {
            Debug.Log("�����I��");
        }
    }
}
