using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatMove : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public float rotateSpeed;
    public AudioClip sound;
    public AudioClip walkingSound;
    public AudioClip jumpSound;
    CharacterController controller;
    AudioSource audio;

    public float gravity;// = 9.8f;
    protected bool jump;
    protected bool doublejump;
    Vector3 currentmovement;

    float MaxHealth;
    float currHealth;
    public Slider healthBarSlider;  //reference for slider
    float soundTimer;

    public Transform respawnPoint;

    // Use this for initialization

    void Start()
    {
        //moveSpeed = 3.0f; // J.G. Changed from 8 to 3 for testing // this value is not actually used anywhere. 
        jumpSpeed = 5.0f;
        rotateSpeed = 160;
        soundTimer = 0;
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
        jump = false;
        doublejump = false;
        if (respawnPoint == null)
        {
            Debug.Log("Cat does not have a spawn point");
            respawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        }
        ResetPosition();

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "insulin")
        {
            healthBarSlider.value += 0.8f;
            audio.PlayOneShot(sound);

            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Food")
        {
            healthBarSlider.value -= 0.3f;
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SeeSaw")
        {
            moveSpeed = 0;
            Debug.Log("I am sitting on a seesaw, yay!");
        }
        /*The above if check is ran when the object(cat) triggers with the seesaw trigger on a StartPathNode object
         * This stops the cat moving so that it can travel along the curved path. The next action occurs on RockController 
         There is also another trigger check on the see saw object which checks for the player.. see SeeSawController*/
        
        if(other.gameObject.tag == "EndPathNode")
        {
            GetComponent<Trajectory>().DeactivateFlyby();
            moveSpeed = 1; //this should be changed
            Debug.Log("I made it mom!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentmovement.z = moveSpeed;
        currentmovement = new Vector3(currentmovement.x, currentmovement.y, currentmovement.z);
        //healthBarSlider.value -= .00011f;

        if (!controller.isGrounded)
        {

            currentmovement -= new Vector3(0, gravity * Time.deltaTime * 2, 0);
        }
        else
            currentmovement.y = 0;

        if (Input.GetKeyDown(KeyCode.Space)) 	//jump
        {
            if (controller.isGrounded)
            {
                audio.PlayOneShot(jumpSound);
               // healthBarSlider.value -= .011f;
                currentmovement.y = jumpSpeed;

                doublejump = true;

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    currentmovement.y = jumpSpeed;
                    audio.PlayOneShot(jumpSound);
                }
            }
        }
        controller.Move(currentmovement * Time.deltaTime);
        
            if (controller.isGrounded)
            {
                soundTimer++;
                if (soundTimer == 10)
                {
                    audio.PlayOneShot(walkingSound);
                    soundTimer = 0;
                }
            }
    }

    public void ResetPosition()
    {
        
        if (respawnPoint != null)
        {
            Debug.Log("position of current spawnpoint" + respawnPoint.transform.position);
            this.gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}

