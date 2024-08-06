using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class CollectableScript : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject finalCoinCountDisplay;
    public GameObject distanceDisplay;
    public GameObject finalDistanceDisplay;

    // Update is called once per frame

    private void Start()
    {
        coinCount = 0;
    }
    void Update()
    {
        coinCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
        float roundedDistance = Mathf.Round(PlayerScriptMovement.distanceCalc * 100f) / 100f;
        distanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + roundedDistance;
        finalCoinCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
        finalDistanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + roundedDistance;

    }
}
