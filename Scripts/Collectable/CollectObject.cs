using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CollectObject : MonoBehaviour
{
    public AudioSource Collectable;
    void OnTriggerEnter(Collider other)
    {
        Collectable.Play();
        CollectableScript.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
