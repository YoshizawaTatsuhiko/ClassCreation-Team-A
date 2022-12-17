using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("生成するゲームオブジェクト")]
    private GameObject[] _go = null;
    [SerializeField, Tooltip("ゲームオブジェクトの最大生成個数")]
    private float _maxQuantity = 1f;
    /// <summary></summary>
    private float _count = 0f;
    [SerializeField, Tooltip("生成間隔")]
    private float _interval = 1f;
    /// <summary>時間を計測するタイマー</summary>
    private float _timer = 0f;

    private void Start()
    {
        if (_go == null) Debug.LogWarning("生成するゲームオブジェクトがassignされていません。");
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
            Debug.Log("生成終了");
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
