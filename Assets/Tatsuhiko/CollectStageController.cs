using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStageController : MonoBehaviour
{
    /// <summary>GameManager</summary>
    private GameManager _gm = null;
    [SerializeField, Tooltip("�l������A�C�e��")]
    private GameObject[] _item = null;

    public int Count { get; set; }

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        if (_item == null)
        { Debug.LogWarning("Item��assign����Ă��܂���B"); }
    }

    private bool _isFrag = true;

    private void FixedUpdate()
    {
        if (Count > _item.Length && _isFrag)
        {
            _gm.GameClear();
            _isFrag = false;
            Debug.Log("�m�F�I");
        }
    }
}
