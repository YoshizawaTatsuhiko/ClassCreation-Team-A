using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("カウントの仕方を切り替える。\ntrue -> Count Up | false -> Count Down")]
    private bool _isCountState = false;
    [SerializeField, Tooltip("")]
    private float _moveTime = 3f;
    [SerializeField, Tooltip("制限時間")]
    private int _limitTime = 0;
    /// <summary>時間を計測するタイマー</summary>
    private float _timer = 0;
    [SerializeField, Tooltip("タイムを表示するText")]
    private Text _timeText = null;
    [SerializeField, Tooltip("ゲームクリアした時に呼ぶイベント")]
    private UnityEvent _onGameClear = null;
    [SerializeField, Tooltip("ゲームオーバーした時に呼ぶイベント")]
    private UnityEvent _onGameOver = null;
    private GameObject _player = null;
    private Rigidbody _playerRb = null;

    private void Start()
    {
        if (_timeText == null) Debug.LogWarning("Textがassignされていません。");
        _timeText = _timeText.GetComponent<Text>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRb = _player.GetComponent<Rigidbody>();
        _playerRb.isKinematic = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_isCountState)
        {
            _timeText.text = _timer.ToString("F2");
            if (_timer >= _limitTime)
            {
                _onGameOver.Invoke();
            }
        }
        else
        {
            _timeText.text = Mathf.Clamp(_limitTime - _timer, 0f, _limitTime).ToString("F2");
            if (_limitTime == 0f)
            {
                _onGameOver.Invoke();
            }
        }
    }

    /// <summary>ステージクリアした時に呼ぶ関数</summary>
    public void GameClear()
    {
        _playerRb.isKinematic = true;
        _player.transform.DOMove(Vector3.zero, _moveTime);
        DOVirtual.DelayedCall(_moveTime, () =>
        {
            _onGameClear.Invoke();
        }, false);
        Debug.Log("GM「ゲームクリア」");
    }
}
