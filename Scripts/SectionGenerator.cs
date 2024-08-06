using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    public static bool sectionGeneration = false;
    public GameObject[] sectionMap;
    public GameObject[] Boundaries;
    public int z = 0;
    public int rotationDegree90 = 90;
    public int rotationDegree180 = 180;
    public int rotationDegree270 = 270;    
    public int sectionNumber1;
    public int sectionNumber2;
    public int sectionNumber3;

    // Start is called before the first frame update
    void Start()
    {
        if (sectionGeneration == false)
        {
            sectionGeneration = true;
            StartCoroutine(SectionGen());            
        }
    }

    IEnumerator SectionGen()
    {
        while (sectionGeneration)
        {
            sectionNumber1 = Random.Range(0, sectionMap.Length);
            sectionNumber2 = Random.Range(0, sectionMap.Length);
            sectionNumber3 = Random.Range(0, sectionMap.Length);

            Quaternion rotation1 = GetRandomRotation();
            Quaternion rotation2 = GetRandomRotation();
            Quaternion rotation3 = GetRandomRotation();

            sectionMap[sectionNumber1].gameObject.SetActive(true);
            sectionMap[sectionNumber2].gameObject.SetActive(true);
            sectionMap[sectionNumber3].gameObject.SetActive(true);
            Boundaries[0].gameObject.SetActive(true);
            Boundaries[1].gameObject.SetActive(true);

            //Section generation
            Instantiate(sectionMap[sectionNumber1], new Vector3(0, 0, z), rotation1);
            Instantiate(sectionMap[sectionNumber2], new Vector3(60, 0, z), rotation2);
            Instantiate(sectionMap[sectionNumber3], new Vector3(-60, 0, z), rotation3);

            //Boundary generation
            Instantiate(Boundaries[0], new Vector3(-120, -4.25f, z), Quaternion.Euler(0, 90, 0));
            Instantiate(Boundaries[1], new Vector3(120, -4.25f, z), Quaternion.Euler(0, -90, 0));

            z += 60;
            yield return new WaitForSeconds(1.5f);
        }
    }

    

    Quaternion GetRandomRotation()
    {
        int randomRotation = Random.Range(0, 3);
        if (randomRotation == 0)
        {
            return Quaternion.Euler(0, rotationDegree90, 0);
        }
        else if (randomRotation == 1)
        {
            return Quaternion.Euler(0, rotationDegree180, 0);
        }
        else
        {
            return Quaternion.Euler(0, rotationDegree270, 0);
        }
    }
}
