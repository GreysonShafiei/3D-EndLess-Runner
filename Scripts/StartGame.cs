using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static GameObject GameOverScreen;
    public static GameObject NormalScreen;
    public GameObject gameover;
    public GameObject normalscreen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen = gameover;
        NormalScreen = normalscreen;
        PlayerScriptMovement.canMove = true;
        CollectableScript.coinCount = 0;
    }

}
