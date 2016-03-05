using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public enum SoundType {left1, left2, left3, right1, right2, right3};

public class CatMove : MonoBehaviour
{
	
	public float moveSpeed;
	public float jumpSpeed;
	public float rotateSpeed;
	bool onGrass;
	bool onWater;

    public bool SwingCall = false;
	
	/// Sounds	/// 
	public AudioClip sound;
	public AudioClip jumpSound;
	public AudioClip walkingSound;
	public AudioClip walkingSound2;
	public AudioClip walkingSound3;
	public AudioClip walkingSound4;
	public AudioClip walkingSound5;
	public AudioClip walkingSound6;
	
	public GameObject ground;
	CharacterController controller;
	AudioSource audio;
	
	public float gravity;// = 9.8f;
	protected bool jump;
	protected bool doublejump;
	Vector3 currentmovement;
	
	public bool healthImpactPos, healthImpactNeg;
	public float currHealth;
	public Slider healthBarSlider;  //reference for slider

	int soundTimer;
	
	private Animator anim;
	Touch myTouch;
	public Transform respawnPoint;
    public Transform sBase;

    float lockPosition = 0;
	
	// Use this for initialization
	
	void Start()
	{
		//moveSpeed = 3.0f; // J.G. Changed from 8 to 3 for testing // this value is not actually used anywhere. 
		jumpSpeed = 7.0f; // Changed from 5 to 7 -JG-
		rotateSpeed = 160;
		soundTimer = 0;
		controller = GetComponent<CharacterController>();
		audio = GetComponent<AudioSource>();
		jump = false;
		doublejump = false;
        healthImpactPos = false;
        healthImpactNeg = false;
		onGrass = true;
		onWater = false;
		
		anim = GetComponent<Animator>();
		if (respawnPoint == null)
		{
			Debug.Log("Cat does not have a spawn point");
			respawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
		}
		ResetPosition();
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "SeeSaw")
		{
			moveSpeed = 0;
            anim.SetBool("Collision", true);
			//Debug.Log("I am sitting on a seesaw, yay!");
		}

		/*The above if check is ran when the object(cat) triggers with the seesaw trigger on a StartPathNode object
         * This stops the cat moving so that it can travel along the curved path. The next action occurs on RockController 
         There is also another trigger check on the see saw object which checks for the player.. see SeeSawController*/
		
		if(other.gameObject.tag == "EndPathNode")
		{
			GetComponent<Trajectory>().DeactivateFlyby();
            anim.SetBool("Collision", false);
			moveSpeed = 3; //this should be changed *Jamie, Changed from 1 to 3*
			Debug.Log("I made it mom!");
		}

		if (other.gameObject.tag == "Food")
		{
			currHealth += 3;
			Destroy(other.gameObject);
            healthImpactPos = true;
		}

		if (other.gameObject.tag == "Insulin")
		{
			currHealth -=5;
			Destroy(other.gameObject);
            healthImpactNeg = true;
		}


	}
	// Update is called once per frame
	void Update()
	{

        this.transform.position = new Vector3(respawnPoint.position.x, transform.position.y, transform.position.z);
		currentmovement.z = moveSpeed;
		//text.text = "Health : " + currHealth;
		currentmovement = new Vector3(0, currentmovement.y, currentmovement.z);
		//healthBarSlider.value -= .00011f;
		
		if (!controller.isGrounded)
		{
			
			currentmovement -= new Vector3(0, gravity * Time.deltaTime * 2, 0);
			anim.SetBool("Jump", false);
		}
		else
		{
			currentmovement.y = 0;
			anim.SetFloat("Run", moveSpeed);
		}
		
		if (Input.GetMouseButtonDown (0)) {
			if (controller.isGrounded) {
				audio.PlayOneShot (jumpSound);
				// healthBarSlider.value -= .011f;
				currentmovement.y = jumpSpeed;
				anim.SetBool ("Jump", true);
				doublejump = true;
				
			} else {
				if (doublejump) {
					doublejump = false;
					currentmovement.y = jumpSpeed;
					audio.PlayOneShot (jumpSound);
				}
			}
			Debug.Log ("Jumpy jumpy jumparoo");
		}
        if (Input.GetMouseButtonDown(1))
        {
            ResetPosition();
        }
		
		controller.Move(currentmovement * Time.deltaTime);
		
		if (controller.isGrounded && onGrass == true)
		{
			//PLAY SOUND WHEN ON GRASS
			if(onGrass == true)
				//Debug.Log("Grass");
			soundTimer++;
			if (soundTimer >=20)
			{
				audioPlayGrass();
				soundTimer = 0;
			}
		}

        if(SwingCall == true)
        {
            Relocate();
            SwingCall = false;
        }
	}
	
	public void ResetPosition()
	{
		if (respawnPoint != null)
		{
			//Debug.Log("position of current spawnpoint" + respawnPoint.transform.position.y);
			this.gameObject.transform.position = respawnPoint.transform.position;
		}
	}

    public void SwingCaller()
    {
        Debug.Log("I'm a swing");
    }

    public void Relocate()
    {
        Debug.Log("activate relocate");
        if(sBase != null)
        {
            this.gameObject.transform.position = sBase.transform.position;
            Debug.Log("Freeze!");
        }
    }
		
	private SoundType RandomSound()
	{
		//RETURNS RANDOM SOUND TYPE
		return (SoundType)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(SoundType)).Length));
	}
	
	void audioPlayGrass()
	{
		//PLAY A NEW RANDOM SOUND WHEN SOUND TIMER REACHES THE NEXT 7
		
		foot(RandomSound()); 
	}
	
	void foot(SoundType soundType)
	{
		switch(soundType)
		{
			//PLAY SOUND FOR EACH FOOT AND THE DIFFERENT TYPES
		case SoundType.left1: audio.PlayOneShot(walkingSound);// Debug.Log ("One"); 
            break;
		case SoundType.left2: audio.PlayOneShot(walkingSound2);// Debug.Log ("Two");
            break;
		case SoundType.left3: audio.PlayOneShot(walkingSound3);// Debug.Log ("Three");
            break;
		case SoundType.right1: audio.PlayOneShot(walkingSound4); //Debug.Log ("Four");
            break;
		case SoundType.right2: audio.PlayOneShot(walkingSound5);// Debug.Log ("Five");
            break;
		case SoundType.right3: audio.PlayOneShot(walkingSound6); //Debug.Log ("Six");
            break;
		default: break;
		}
	}
}