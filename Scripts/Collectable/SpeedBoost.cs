using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpeedBoost : MonoBehaviour
{
    public AudioSource Collectable;
    public GameObject zombie;

    void OnTriggerEnter(Collider other)
    {
        Collectable.Play();
        zombie.GetComponent<Animator>().Play("Goofy Running");
        StartCoroutine(speedBoost());
        
    }

    IEnumerator speedBoost() 
    {
        PlayerScriptMovement.speedBoost = true;
        yield return new WaitForSeconds(10);
        PlayerScriptMovement.speedBoost = false;
        zombie.GetComponent<Animator>().Play("Injured Run");
        this.gameObject.SetActive(false);
    }

}
