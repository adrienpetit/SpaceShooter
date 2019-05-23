using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpan : MonoBehaviour
{
    bool Span = false;
    public float MinSpanTime = 5f; //Time min span
    public float MaxSpanTime = 5f; // Time max span
    public GameObject[] ennemies;

    //initiliasation
    IEnumerator SpawnObject (int index, float secondes)
    {
        yield return new WaitForSeconds(secondes);//time before span
        Instantiate(ennemies[index], transform.position, transform.rotation);//permet de span
        Span = false;// other ennemies will arrive
    }
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (!Span)
        {
            Span = true;//active le span
            int enemyIndex = Random.Range(0, ennemies.Length);// Random gameObject from the list
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(MinSpanTime, MaxSpanTime)));//Important the span start here
        }


    }
}
