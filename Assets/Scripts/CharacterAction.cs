using UnityEngine;

public class CharacterAction : MonoBehaviour
{
	Transform cPlayer;
	float cSpeed, cJump;
	Vector3 cForward, cUp;
	bool cReach;

	void Awake ()
	{
		cPlayer = GetComponent<Transform> ();
	}

	void Start ()
	{
		cSpeed = 1.0f;
		cJump = 3.0f;
	}

	void FixedUpdate ()
	{
		cForward = transform.TransformDirection (Vector3.right);
		cUp = transform.TransformDirection (Vector3.up);
		if ((Input.GetKey (KeyCode.RightArrow)) && (cSpeed < 4.9f)) {
			cSpeed += 0.1f;
		} else if (Input.GetKey (KeyCode.LeftArrow) && (cSpeed > 0.1f)) {
			cSpeed -= 0.1f;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			cPlayer.Translate (cUp * cJump * Time.deltaTime);
		}
		cPlayer.Translate (cForward * cSpeed * Time.deltaTime);
	}
}


//Character Controller
//CharacterController cController;
//cController = GetComponent<CharacterController> ();
//cController.SimpleMove (cForward * cSpeed);  //Mathf.Clamp(cSpeed, 0, 4)