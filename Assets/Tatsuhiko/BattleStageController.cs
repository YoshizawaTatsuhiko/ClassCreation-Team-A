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
    }

    private void FixedUpdate()
    {
        if (_generator.transform.childCount <= 0 && _generator.Count >= _generator.MaxQuantity)
        {
            _gm.GameClear();
            Debug.Log("–â‘è‚È‚µ");
        }
    }
}
