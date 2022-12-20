using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("生成するゲームオブジェクト")]
    private GameObject[] _go = null;
    [SerializeField, Tooltip("ゲームオブジェクトの最大生成個数")]
    private float _maxQuantity = 1f;
    /// <summary>何回生成したか数える変数</summary>
    private float _count = 0f;
    [SerializeField, Tooltip("生成間隔")]
    private float _interval = 1f;
    /// <summary>時間を計測するタイマー</summary>
    private float _timer = 0f;

    private void Start()
    {
        if (_go == null) Debug.LogWarning("生成するゲームオブジェクトがassignされていません。");
    }

    /// <summary>ゲームクリアを1度だけ呼ぶための変数</summary>
    private bool _iscall = true;

    private void FixedUpdate()
    {
        int n = Random.Range(0, _go.Length);
        if (_count < _maxQuantity)  // オブジェクトを生成した回数が規定回数未満だったら、生成する。
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)  // タイマーがインターバル以上になったら、生成する。
            {
                Instantiate(_go[n], transform);
                _timer = 0;
                _count++;
            }
        }

        else if (_count >= _maxQuantity && Count() == 0 && _iscall)
        {
            _iscall = false;
            Debug.Log("生成終了");
        }
    }

    /// <summary>子オブジェクトの個数</summary>
    /// <returns>現在の子オブジェクトの個数</returns>
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
