using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyLaser : MonoBehaviour
{
    public float velocityEnemy;
    public int scoreValue;
    public Score scoreM;
    public GameObject Explosion; // prefab explosion
    public GameObject shoot;// tire enemy
    public GameObject shootSpan;
    public bool okShoot;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;//enemy speed move
        scoreM = FindObjectOfType<Score>();
    }
     void Update()
    {
        if(Time.time>nextFire)
        {
            nextFire = Time.time + fireRate; // prochain shot apres tTime.time+speedFire
            Instantiate(shoot, shootSpan.transform.position, shootSpan.transform.rotation);//creation du shot prefab
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)//gerer collision
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
