using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
	public Image cFade;
	public Transform cEye;
	public Transform[] cProfile;
	NavMeshAgent cAI;
	float pSide, pUp, cSpeed, cSideView, cUpView;
	// mFront, mSide;

	void Start ()
	{
		//Testing purpose (2D to 3D)
		GLOBAL.IsCharWalk = true;
		//Character controller
		cAI = GetComponent<NavMeshAgent> ();
		//Rotate speed
		pSide = 0.8f;
		pUp = 0.8f;
		//Movement speed
		cSpeed = 3f;
	}

	public void RemoteWalk (int no)
	{
		//Start the remote control walk
		StartCoroutine (Fadeout (no));
	}

	IEnumerator Fadeout (int no)
	{
		//Off the character movement
		GLOBAL.IsCharWalk = false;
		//Start the fadeout color for character
		for (int iColor = 0; iColor < 64; iColor++) {
			//Color reach 255
			cFade.color = new Color32 (0, 0, 0, (byte)(iColor * 4));
			yield return new WaitForSeconds (0.01f);
		}
		//Start the player remote area
		for (int i = 0; i < cProfile.Length; i++) {
			if (i == no) {
				//Update character position to remote location
				cAI.nextPosition = cProfile [i].position;
				//Always player look at the remote area
				cAI.transform.LookAt (cProfile [i]);
			}
		}
		//Start the fadein color for character
		for (int iColor = 63; iColor >= 0; iColor--) {
			//Color reach 0
			cFade.color = new Color32 (0, 0, 0, (byte)(iColor * 4));
			yield return new WaitForSeconds (0.01f);
			//On the character movement
			GLOBAL.IsCharWalk = true;
		}
	}

	void Update ()
	{
		//Start control only character control is on
		if (GLOBAL.IsCharWalk) {
			//For character movement
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				cAI.Move (transform.forward * Time.deltaTime * cSpeed);
			} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				cAI.Move (-transform.forward * Time.deltaTime * cSpeed);
			} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				cAI.Move (-transform.right * Time.deltaTime * cSpeed);
			} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				cAI.Move (transform.right * Time.deltaTime * cSpeed);
			}
			//Character rotate access with mouse side
			cSideView = pSide * Input.GetAxis ("Mouse X");
			//Character eye(camera) rotate access with mouse up
			cUpView = pUp * Input.GetAxis ("Mouse Y");
			Debug.Log (Input.GetAxis ("Mouse Y"));

			//Character rotate side view
			transform.Rotate (0, cSideView, 0);

			//Character eye(camera) rotate up view
			cEye.Rotate (-cUpView, 0, 0);
		}
	}
}

//			mFront = Input.GetAxis ("Vertical");
//			mSide = Input.GetAxis ("Horizontal");
//			Vector3 cMove = new Vector3 (mSide, 0, mFront);
//			cAI.Move (cMove * cSpeed);