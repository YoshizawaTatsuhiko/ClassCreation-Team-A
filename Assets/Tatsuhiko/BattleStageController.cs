using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStageController : MonoBehaviour
{
    /// <summary>GameManager</summary>
    private GameManager _gm = null;
    /// <summary>Generator</summary>
    private Generator _generator = null;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _generator = FindObjectOfType<Generator>();
        Cursor.visible = false;
    }

    private bool _isFrag = true;

    private void FixedUpdate()
    {
        if (_generator.transform.childCount <= 0 && _generator.Count >= _generator.MaxQuantity && _isFrag)
        {
            _gm.GameClear();
            _isFrag = false;
            Debug.Log("–â‘è‚È‚µ");
        }
    }
}
