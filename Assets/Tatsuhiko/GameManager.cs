using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("�J�E���g�̎d����؂�ւ���B\ntrue -> Count Up | false -> Count Down")]
    private bool _isCountState = false;
    [SerializeField, Tooltip("")]
    private float _moveTime = 3f;
    [SerializeField, Tooltip("��������")]
    private int _limitTime = 0;
    /// <summary>���Ԃ��v������^�C�}�[</summary>
    private float _timer = 0;
    [SerializeField, Tooltip("�^�C����\������Text")]
    private Text _timeText = null;
    [SerializeField, Tooltip("�Q�[���N���A�������ɌĂԃC�x���g")]
    private UnityEvent _onGameClear = null;
    [SerializeField, Tooltip("�Q�[���I�[�o�[�������ɌĂԃC�x���g")]
    private UnityEvent _onGameOver = null;
    private GameObject _player = null;
    private Rigidbody _playerRb = null;

    private void Start()
    {
        if (_timeText == null) Debug.LogWarning("Text��assign����Ă��܂���B");
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

    /// <summary>�X�e�[�W�N���A�������ɌĂԊ֐�</summary>
    public void GameClear()
    {
        _playerRb.isKinematic = true;
        _player.transform.DOMove(Vector3.zero, _moveTime);
        DOVirtual.DelayedCall(_moveTime, () =>
        {
            _onGameClear.Invoke();
        }, false);
        Debug.Log("GM�u�Q�[���N���A�v");
    }
}
