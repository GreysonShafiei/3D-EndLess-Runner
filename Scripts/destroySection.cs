using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySection : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name.Trim();
        Debug.Log("Parent Name: " + parentName);
        StartCoroutine(DestroySection());
    }

    IEnumerator DestroySection()
    {
        yield return new WaitForSeconds(50);
        if (parentName.Contains("Section(Clone)") ||
            parentName.Contains("treasure Island with environment (1)(Clone)") || parentName.Contains("treasure Island with environment(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
