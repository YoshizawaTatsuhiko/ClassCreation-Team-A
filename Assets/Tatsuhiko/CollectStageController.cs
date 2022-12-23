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

    private void Update()
    {
        if (Count == _item.Length)
        {
            _gm.GameClear();
        }
    }
}
