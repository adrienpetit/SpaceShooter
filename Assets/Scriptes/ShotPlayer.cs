using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    public float speedShot;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speedShot; // Donner une vitesse au gameObject shot
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
