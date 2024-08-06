using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import TextMeshPro namespace

public class Collision : MonoBehaviour
{
    public GameObject zombie;
    public GameObject playerModel;
    public AudioSource collisionSFX;
    

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        zombie.GetComponent<PlayerScriptMovement>().enabled = false;
        playerModel.GetComponent<Animator>().Play("Zombie Reaction Hit");
        collisionSFX.Play();
        PlayerScriptMovement.end = true;
        StartCoroutine(SceneManagement.EndLevel());
    }    
}
