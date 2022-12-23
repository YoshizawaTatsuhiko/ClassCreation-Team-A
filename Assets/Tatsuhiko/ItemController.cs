using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ItemController : MonoBehaviour
{
    /// <summary>AudioSource</summary>
    private AudioSource _audio = null;
    /// <summary></summary>
    private CollectStageController _collector = null;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.playOnAwake = false;
        _collector = FindObjectOfType<CollectStageController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Player")
        {
            _audio.Play();
            _collector.Count++;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
