using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

//Made By Noaman , Edited by Pete 

public class PlayerBehaviourScriptCs : PunBehaviour
{
    public GameObject player11;

    public AudioSource audFire;
    //Colors used to lerp 
    public Gradient gradiantColors;//
    private Renderer ren;//
    //-----------------------------/

    public bool onAndroid = false;
    public VirtualJoystickCs vs;

    //gun controll
    public GameObject projectile;
    public Transform firePos;
    public float fireBreak;
    private float tempfireBreak;

    public float speed;
    public float AngleToFlip;

    public Transform rotata;



    //public Camera main;

    //player behavour
    public float damage;
    public float increasedDamage;
    public float health;
    public float maxHealth;
	public float rotationSpeed = 5.0f;
	public float forwardVel;
    public GameObject healthBar;
	float forwardInput, straffeInput;
	private Vector3 velocity;
	Rigidbody rb;
    NetworkManager spawnpoints;
    PhotonConnect endgame;

    public float movementSpeed = 5f;
    public float strafeSpeed = 3f;

    public Plane playerPlane;
    public Transform Player;
    public Ray ray;

    public int lives = 5;
    public Text lifeTracker;
    Transform textChild;
    GameObject textobj,enemi;
    GameObject[] enem;
    public bool iWin;
    // Use this for initialization
    void Start()
	{
        if (this.GetComponent<Renderer>() !=null)
        {
            ren = gameObject.GetComponent<Renderer>();
        }
        else
        {
            ren = player11.GetComponentInChildren<Renderer>();
        }

        audFire = GetComponent<AudioSource>();
        //vs = GameObject.FindGameObjectWithTag("AndroidControl").GetComponentInChildren<VirtualJoystickCs>(); 

        if (photonView.isMine)
        {
            spawnpoints = FindObjectOfType<NetworkManager>();
            endgame = FindObjectOfType<PhotonConnect>();
            //Invoke("hi", 1f);
        }
        textobj = GameObject.FindGameObjectWithTag("Score");
        // textChild = transform.Find("TextA");
        //   lifeTracker = textChild.GetComponent<Text>();
        lifeTracker = textobj.GetComponent<Text>();


      //  transform.Rotate(Vector3, 0, 0, 180);
        health = maxHealth; 
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
        if (!photonView.isMine)
        {
            return;
        }
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        //win();
        lifeTracker.text = "lives: " + lives;
        movement();
       // BetterMoverment();
        FireProjectile();
        flip();
        // rotate();
#endif

        // modifies the players health color
        ren.material.color = gradiantColors.Evaluate(health / maxHealth);

    }

    public void FireProjectile()
    {

        fireBreak -= Time.deltaTime;
        //Debug.Log(fireBreak);
        if (Input.GetKey(KeyCode.Mouse0) && fireBreak <= 0)
        {
            photonView.RPC("FireProjectile2", PhotonTargets.All);
            audFire.Play();
        }
    }
    [PunRPC]
    private void FireProjectile2()
    {
        GameObject bullet = Instantiate(projectile, firePos.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(firePos.forward * 1000);
        fireBreak = 0.5f;
    }

    public void movement()
    {
        if (!photonView.isMine)
        {
            return;
        }
        Debug.DrawLine(transform.position, (Vector3.forward) * 5, Color.black);
        if (onAndroid == true)
        {
        forwardInput = vs.Vertical () * forwardVel;
        straffeInput = vs.Horizontal() * forwardVel;
        }
        else
        {
            forwardInput = Input.GetAxis("Vertical") * forwardVel;
            straffeInput = Input.GetAxis("Horizontal") * forwardVel;

        }

        velocity = new Vector3(straffeInput, 0, forwardInput);
        velocity = transform.TransformDirection(velocity);
        //velocity.y = rb.velocity.y; 
        rb.velocity = velocity;

        if (health <= 0)
        {
            loselife();
        }
    }

    public void loselife()
    {
            //Destroy(this.gameObject, 1.0f);
            health = maxHealth;
            gameObject.transform.position = spawnpoints.SpawnPoints[PhotonNetwork.player.ID - 1].transform.position;
            lives -= 1;

        if (lives == 0)
        {
            photonView.RPC("win", PhotonTargets.Others);
            Invoke("win", 0.5f);
        }
        
    }
    [PunRPC]
   public void win()
    {
       
        if (!photonView.isMine)
        {
             return;
        }
            //put counter for num of players when = > 2 is winner
        PhotonNetwork.Disconnect();
        if (lives > 0)
        {
            Application.LoadLevel("Win Screen");
            return;
        }
       
            Application.LoadLevel("Losing Screen");
      
       
    }
    public void BetterMoverment()
    {
        if (!photonView.isMine)
        {
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * strafeSpeed;
        }

        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * strafeSpeed;
        }

        playerPlane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = targetRotation;

        }
        if (health <= 0)
        {
            //Destroy(this.gameObject, 1.0f);
            health = maxHealth;
            gameObject.transform.position = spawnpoints.SpawnPoints[PhotonNetwork.player.ID - 1].transform.position;

        }
    }
    public void takeDamage()
    {
        //#if UNITY_ANDROID || UNITY_IOS
        health -= damage;
        float calcHealth = health / maxHealth;
        setHealth(calcHealth);
       Debug.Log(" takeDamage");
      // #endif
    }
    public void takeMoreDamage()
    {
      //  #if UNITY_ANDROID || UNITY_IOS
        health -= increasedDamage;
        float calcHealth = health / maxHealth;
        setHealth(calcHealth);
        Debug.Log(" takeMoreDamage");
      //  #endif
    }

    public void setHealth(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    // look towards the mouse position
    void rotate()
	{
		Vector3 look = Input.mousePosition;
		//look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
		//look = Camera.main.ScreenToWorldPoint(look);
        look -= transform.position;
		transform.LookAt(look);
	}
    public void FlipClockWise()
    {
        float step = speed * Time.deltaTime;
        rotata = this.gameObject.transform.GetChild(0);
        Quaternion r = Quaternion.Euler(0,0, -AngleToFlip);
        rotata.transform.rotation *= r;
    }
   public  void FlipAntiClockWise()
    {
        float step = speed * Time.deltaTime;
        rotata = this.gameObject.transform.GetChild(0);
        Quaternion r = Quaternion.Euler(0,0, AngleToFlip);
        rotata.transform.rotation *= r;
    }

    void flip()
    {
        float step = speed * Time.deltaTime;
        rotata = this.gameObject.transform.GetChild(0);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Quaternion r = Quaternion.Euler(0, 0, AngleToFlip);
            rotata.transform.rotation *= r;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Quaternion r = Quaternion.Euler(0, 0, -AngleToFlip);
            rotata.transform.rotation *= r;
        }
    }


void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(health);
            stream.SendNext(lives);

        }
        else
        {
            this.health = (float)stream.ReceiveNext();
            this.lives = (int)stream.ReceiveNext();
        }
    }
    //private void hi()
    //{
    //    enem = GameObject.FindGameObjectsWithTag("Player");
    //    foreach(GameObject enemy in enem)
    //    {
    //        if(enemy != gameObject)
    //        {
    //            enemi = enemy;
    //        }
    //    }

    //}
	/*void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
	}*/

}
