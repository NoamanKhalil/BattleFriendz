using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//----------------------------------------------------------------------/
// offline player behaviour script
//---------------------------------------------------------------------/
public class OfflinePlayerBehaviourScriptCs : MonoBehaviour
{
    public GameObject UiDeath;
   // public GameObject shield;
    public AudioSource audFire;
    //Colors used to lerp 
    public Gradient gradiantColors;//
    private Renderer ren;//
    //-----------------------------/

    //components for andord to work , includes android UI
    public bool onAndroid= false;//
    public VirtualJoystickCs vs;//
    //----------------------------/
    
    public float damage;//
    public float increasedDamage;//
    public float health;//
    public float maxHealth;//
	public float rotationSpeed = 5.0f;//
	public float forwardMovement;//
    public GameObject healthBar;//
	float forwardInput, straffeInput;//
	private Vector3 velocity; // leon was here 
	private Rigidbody rB;//

    // speed and angle to slip with 
    public float speed;//
    public float angleToFlip;//
    //------------------------------/
    //Variables for firing projectiles 
    public GameObject projectile;//
    public float projectileSpeed;
    public Transform firePos;//
    public float fireBreak;
    private float tempfireBreak;
    // ----------------------------/

    public Transform objectToRotate;//

    // Use this for initialization
    void Start()//
	{
        audFire = GetComponent<AudioSource>();
        // vs = GameObject.FindGameObjectWithTag("AndroidControl").GetComponentInChildren<VirtualJoystickCs>(); 

        UiDeath.SetActive(false);

        health = maxHealth; 
		rB = GetComponent<Rigidbody>();
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()//
    {
        // input for andorid 
        if (onAndroid == true)
        {
            forwardInput = vs.Vertical() * forwardMovement;   /* Input.GetAxis("Vertical") * forwardVel;*/
            straffeInput = vs.Horizontal() * forwardMovement;  /*   Input.GetAxis("Horizontal") * forwardVel;*/
        }
        // input for normal pc controls 
        else
        {
            forwardInput = Input.GetAxis("Vertical") * forwardMovement;
            straffeInput = Input.GetAxis("Horizontal") * forwardMovement;
        }
        
    
        velocity = new Vector3(straffeInput,0, forwardInput);
		//velocity = transform.TransformDirection(velocity);
		//velocity.y = rb.velocity.y; 
		rB.velocity = velocity;

        if (health <=0 )
        {
            UiDeath.SetActive(true);
            Destroy(this.gameObject, 0.2f);
        }

        fireBreak -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && fireBreak <= 0 && onAndroid== false)
        {
            FireProjectile();
            
        }
        flip();
        // modifies the players health color
        ren.material.color = gradiantColors.Evaluate(health / maxHealth);
    }
    //code to fre projectile 

    public void FireProjectile()//
    {
        GameObject bullet = Instantiate(projectile, firePos.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(firePos.forward * projectileSpeed);
        fireBreak = 0.5f;
        audFire.Play();
       // Debug.Log("Shots fired");
    }
    //code to flip on PC 
    void flip()//
    {
        float step = speed * Time.deltaTime;
        //objectToRotate = this.gameObject.transform.GetChild(0);
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("E detected");
            Quaternion r = Quaternion.Euler(0, 0, angleToFlip);
            objectToRotate.transform.rotation *= r;
            //objectToRotate.Rotate(0, angleToFlip, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Q detected");
            Quaternion r = Quaternion.Euler(0,0,  -angleToFlip);
            objectToRotate.transform.rotation *= r;
           // objectToRotate.Rotate(0,-angleToFlip,0);
        }
    }
    //code to flip on andorid 
    public void FlipClockWise()//
    {
        float step = speed * Time.deltaTime;
        objectToRotate = this.gameObject.transform.GetChild(0);
        Quaternion r = Quaternion.Euler(0,0, -angleToFlip);
        objectToRotate.transform.rotation *= r;
    }
    public void FlipAntiClockWise()//
    {
        float step = speed * Time.deltaTime;
        objectToRotate = this.gameObject.transform.GetChild(0);
        Quaternion r = Quaternion.Euler(0,0, angleToFlip);
        objectToRotate.transform.rotation *= r;
    }

    public void takeDamage()//
    {
        health -= damage;
        float calcHealth = health / maxHealth;
        setHealth(calcHealth);
      // Debug.Log(" takeDamage");
    }
    public void takeMoreDamage()//
    {
        health -= increasedDamage;
        float calcHealth = health / maxHealth;
        setHealth(calcHealth);
       // Debug.Log(" takeMoreDamage");
    }
    // controls health bar 
    public void setHealth(float myHealth)//
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    // look towards the mouse position
   /* void rotate()
	{
		Vector3 look = Input.mousePosition;
		look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
		look = Camera.main.ScreenToWorldPoint(look);
		transform.LookAt(look);
	}*/

    //gizmos to test 
	/*void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
	}*/

}
