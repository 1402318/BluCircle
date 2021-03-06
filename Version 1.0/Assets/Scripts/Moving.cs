using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Moving : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public float rotateSpeed;
	CharacterController controller; 
	public float gravity = 9.8f;
	protected bool jump;
	protected bool doublejump;
	Vector3 currentmovement;

	float MaxHealth;
	float currHealth;
	public Slider healthBarSlider;  //reference for slider

	// Use this for initialization

	void Start () {
		moveSpeed = 8.0f;
		jumpSpeed = 10.0f;
		rotateSpeed = 160;
		controller = GetComponent<CharacterController> ();
		jump = false;
		doublejump = false;

	}
	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "insulin") {
			healthBarSlider.value +=0.8f;
			Destroy(other.gameObject);
		}

		else if (other.gameObject.tag == "Food") {
			healthBarSlider.value -=0.3f;
			Destroy(other.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Input.GetAxis ("Horizontal") *rotateSpeed * Time.deltaTime, 0);

		currentmovement = new Vector3 (0, currentmovement.y, Input.GetAxis ("Vertical") * moveSpeed);
		currentmovement = transform.rotation * currentmovement;
		healthBarSlider.value -=.00011f;

		if (!controller.isGrounded) {
			currentmovement -= new Vector3 (0, gravity * Time.deltaTime*2, 0); 
		} else
			currentmovement.y = 0;

		if (Input.GetKeyDown (KeyCode.Space)) 	//jump
		{
			if (controller.isGrounded) 
			{
				healthBarSlider.value -=.011f;
				currentmovement.y = jumpSpeed;
				doublejump = true;
			} 
			else
			{
				if(doublejump)
				{
					doublejump = false;
					currentmovement.y = jumpSpeed;
				}
			}
		}
		controller.Move (currentmovement * Time.deltaTime);

		//}
		if (Input.GetKey(KeyCode.D)) {
			GetComponent<Rigidbody>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody>().velocity.y);
		}

		if (Input.GetKey(KeyCode.A)) {
			GetComponent<Rigidbody>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody>().velocity.y);
		}
	}
	


}

