using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float velocityEnemy;
    public int scoreValue;
    public Score scoreM;
    public GameObject Explosion; // prefab explosion
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;//enemy speed move
        scoreM = FindObjectOfType<Score> ();
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D other)//gerer collision
    {
        if (other.tag == "PlayerLaser")//if collision with my laser
        {
            Destroy(other.gameObject);// destroy my laser bullet
            Destroy(gameObject);// destroy enemy
            scoreM.score += scoreValue = 10; // + 10 par ennemi buté 
            Instantiate(Explosion, transform.position, transform.rotation);// creer exlosion quand enemy meurt
        }
        
    }
}
