using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
[System.Serializable]

public class Boundary
{
	public float xMin,xMax,yMin,yMax;
}
public class Movement : MonoBehaviour
{
	public float speedMovement;
	public Boundary boundary;
    public float tilt;

    public Rigidbody2D rb;
    public GameObject shot;//this is the shot prefabs
    public Transform Shoot;//where the shoot starts
    public float speedFire=0.5F;//time between shots
    private float nextFire = 0.0F;
    public Slider LifeBar;//reference à la barre de vie 
    public int hp;
    public GameObject Explosion; // prefab explosion
    public GameObject RestartPanel;

    public Button gauche, droite, tirer;
    // Start is called before the first frame update
    void Start()
    {
        gauche.onClick.AddListener(Gauche);
        droite.onClick.AddListener(Droite);
        tirer.onClick.AddListener(Tirer);
    }
   
    // Update is called once per frame
    void Update()
    {
        LifeBar.value = hp; //10 points de vie donc si hp =5 la barre de vie pareil
        GetComponent<Transform>().position = new Vector2(
            Mathf.Clamp(GetComponent<Transform>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Transform>().position.y, boundary.yMin, boundary.yMax));

    	/*if (Input.GetKeyDown(KeyCode.RightArrow))
    	{
    		GetComponent<Rigidbody2D>().velocity = new Vector2 (speedMovement, 0);
    	}
    	if (Input.GetKeyDown(KeyCode.LeftArrow))
    	{
    		GetComponent<Rigidbody2D>().velocity = new Vector2 (-speedMovement, 0);
    	}

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextFire = Time.time + speedFire; // prochain shot apres tTime.time+speedFire
            Instantiate(shot, Shoot.position, Shoot.rotation);//creation du shot prefabs

        }
   
        /*if(hp == 0)
        {
            Destroy(gameObject);// Détruire notre vaisseau si plus de vie
        }*/
       

    }
    public void Gauche()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speedMovement, 0);

    }
    public void Droite()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedMovement, 0);

    }
    public void Tirer()
    {
        nextFire = Time.time + speedFire; // prochain shot apres tTime.time+speedFire
        Instantiate(shot, Shoot.position, Shoot.rotation);//creation du shot prefabs

    }
    void OnTriggerEnter2D(Collider2D other)//gerer collision de notre vaisseua
    {
        if (other.tag == "Enemy" || other.tag == "LaserEnemy")//if collision with my laser
        {
            hp--;
            //Destroy(other.gameObject);// destroy my laser bullet
           if(hp<0)
            {
                Instantiate(Explosion, transform.position, transform.rotation);

                Destroy(gameObject);// destroy ourself
                RestartPanel.SetActive(true);


            }
            // Destroy(gameObject);// destroy enemy
            //scoreM.score += scoreValue = 10; // + 10 par ennemi buté 
            //Instantiate(Explosion, transform.position, transform.rotation);// creer exlosion quand enemy meurt
        }

    }
}
