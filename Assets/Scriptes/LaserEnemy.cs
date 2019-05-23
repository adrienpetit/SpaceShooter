using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * moveSpeed;//faire bouger le laser enemy dans bonne direction
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
