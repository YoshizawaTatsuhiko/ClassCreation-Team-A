using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("�J�E���g�̎d����؂�ւ���B\ntrue -> Count Up | false -> Count Down")]
    private bool _isCount = false;
    [SerializeField, Tooltip("��������")]
    private int _limitTime = 0;
    /// <summary>���Ԃ��v������^�C�}�[</summary>
    private float _timer = 0;
    [SerializeField, Tooltip("�^�C����\������Text")]
    private Text _timeText = null;
    [SerializeField, Tooltip("")]
    private UnityEvent _onGameClear = null;
    [SerializeField, Tooltip("")]
    private UnityEvent _onGameOver = null;

    private void Start()
    {
        if (_timeText == null) Debug.LogWarning("Text��assign����Ă��܂���B");
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

    /// <summary>�X�e�[�W�N���A�������ɌĂԊ֐�/summary>
    public void GameClear()
    {
        _onGameClear.Invoke();
    }

    /// <summary>�Q�[���I�[�o�[�������ɌĂԊ֐�</summary>
    public void GameOver()
    {
        _onGameOver.Invoke();
    }
}
