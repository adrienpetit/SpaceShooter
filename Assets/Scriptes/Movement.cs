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
    public float speedFire=50F;//time between shots
    private float nextFire = 0.0F;
    public Slider LifeBar;//reference à la barre de vie 
    public int hp;
    public GameObject Explosion; // prefab explosion
    public GameObject RestartPanel;
    float accelStartY;

    public Button gauche, droite, tirer;
    // Start is called before the first frame update
    public void Init()
    {

        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
    void Start()
    {
        /*gauche.onClick.AddListener(Gauche);
        droite.onClick.AddListener(Droite);
        tirer.onClick.AddListener(Tirer);*/

        accelStartY = Input.acceleration.y;
    }
   
    // Update is called once per frame
    void Update()
    {
        LifeBar.value = hp; //10 points de vie donc si hp =5 la barre de vie pareil
        GetComponent<Transform>().position = new Vector2(
            Mathf.Clamp(GetComponent<Transform>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Transform>().position.y, boundary.yMin, boundary.yMax));

        /*if (Input.GetTouch > boundary.xMax)
    	{
    		GetComponent<Rigidbody2D>().velocity = new Vector2 (speedMovement, 0);
    	}

        if (Input.GetTouch < boundary.xMax)
        {
    		GetComponent<Rigidbody2D>().velocity = new Vector2 (-speedMovement, 0);
    	}
        */
         if (Input.touchCount>0)
        
        {
            //nextFire = Time.time + speedFire; // prochain shot apres tTime.time+speedFire
            Instantiate(shot, Shoot.position, Shoot.rotation);//creation du shot prefabs

        }
   
        /*if(hp == 0)
        {
            Destroy(gameObject);// Détruire notre vaisseau si plus de vie
        }*/
        float x = Input.acceleration.x;
        float y = 0;

        Vector2 direction = new Vector2(x, y);

        if (direction.sqrMagnitude > 1)
            direction.Normalize();



        Move(direction);


    }
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.2f;
        min.x = min.x - 0.2f;

       // min.y = min.y - 0.5f;
       // max.y = max.y - 0.5f;

        Vector2 pos = transform.position;
        pos += direction * speedMovement * Time.deltaTime * 5;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
       // pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    /*public void Gauche()
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
    */   
    void OnTriggerEnter2D(Collider2D other)//gerer collision de notre vaisseua
    {
        if (other.tag == "Enemy" || other.tag == "LaserEnemy")//if we  collision with laser or enemy
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
