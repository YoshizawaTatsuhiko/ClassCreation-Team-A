using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("カウントの仕方を切り替える。\ntrue -> Count Up | false -> Count Down")]
    private bool _isCount = false;
    [SerializeField, Tooltip("制限時間")]
    private int _limitTime = 0;
    /// <summary>時間を計測するタイマー</summary>
    private float _timer = 0;
    [SerializeField, Tooltip("タイムを表示するText")]
    private Text _timeText = null;
    [SerializeField, Tooltip("")]
    private UnityEvent _onGameClear = null;
    [SerializeField, Tooltip("")]
    private UnityEvent _onGameOver = null;

    private void Start()
    {
        if (_timeText == null) Debug.LogWarning("Textがassignされていません。");
        _timeText = _timeText.GetComponent<Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_isCount)
        {
            _timeText.text = _timer.ToString("F2");
        }
        else
        {
            _timeText.text = Mathf.Clamp(_limitTime - _timer, 0f, _limitTime).ToString("F2");
        }
    }

    /// <summary>ステージクリアした時に呼ぶ関数/summary>
    public void GameClear()
    {
        _onGameClear.Invoke();
    }

    /// <summary>ゲームオーバーした時に呼ぶ関数</summary>
    public void GameOver()
    {
        _onGameOver.Invoke();
    }
}
