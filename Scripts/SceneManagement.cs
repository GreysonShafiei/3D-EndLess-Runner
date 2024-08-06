using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static GameObject FadeOut;
    public GameObject fadeout;
    
    // Start is called before the first frame update
    void Start()
    {
        FadeOut = fadeout;
        FadeOut.SetActive(false);
    }
    public static IEnumerator EndLevel()
    {
        PlayerScriptMovement.canMove = false;
        StartGame.GameOverScreen.gameObject.SetActive(true);
        StartGame.NormalScreen.gameObject.SetActive(false);
        SectionGenerator.sectionGeneration = false;
        yield return new WaitForSeconds(3.5f);
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(3.5f);        
        SceneManager.LoadScene(0);
    }

    void pressedStart()
    {
        SceneManager.LoadScene(1);
    }

}
