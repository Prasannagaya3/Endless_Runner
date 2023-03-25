using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
	public Camera cEye;
	public InputField userName;
	public Text uName, uInsText, uHint, uInsPopup;
	public GameObject mPop;
	public RectTransform[] mSelection;
	public Image[] mSelect;
	public GameObject[] mSlider;
	Vector3 sZoomIn, sDef;
	bool gColorCheck;

	void Start ()
	{
		//Camera clearflag for 2d(default) - Color
		cEye.clearFlags = CameraClearFlags.SolidColor;
		//Default size
		sDef = new Vector3 (1, 1, 1);
		//Zoomin size
		sZoomIn = new Vector3 (1.05f, 1.05f, 1);
		//Popup
		mPop.SetActive (false);
		//Selected land/building image color to null
		for (int i = 0; i < mSelect.Length; i++) {
			mSelect [i].color = new Color32 (255, 255, 255, 255);
		}
		//Selection color condition
		gColorCheck = false;
	}

	public void MenuFlow (int no)
	{
		switch (no) {
		case 0:
			//Reset the inputfield
			userName.text = string.Empty;
			uHint.enabled = true;
			//Proceed with name page
			mSlider [0].SetActive (true);
			mSlider [1].SetActive (false);
			break;
		case 1:
			//Instruction to player
			uInsText.text = "Hi " + uName.text + ", Congratulations! You've received INR.10,00,000 loan from DICV." + "\n" + "You can buy land, building and Intial Stock Recommendation(ISR)." + "\n" + "Click okay to proceed.";
			//Check the input field is either null/space nor filled
			if (userName.text.Trim () != string.Empty) {
				//Proceed with money page
				mSlider [no].SetActive (true);
				mSlider [no - 1].SetActive (false);
			} else {
				//Instruction to player
				uInsPopup.text = "Please enter a valid name";
				//Popup for the string error
				StartCoroutine (MenuPopUp (no));
				//Reset the inputfield
				userName.text = string.Empty;
				uHint.enabled = true;
				//mSlider [no].SetActive (true);
			}
			break;
		case 2:
			//Proceed with landing page
			mSlider [no].SetActive (true);
			mSlider [no - 1].SetActive (false);
			break;
		case 3:
			if (gColorCheck == true) {
				//Proceed with landing page
				mSlider [no].SetActive (true);
				mSlider [no - 1].SetActive (false);
				for (int i = 0; i < mSelect.Length; i++) {
					mSelect [i].color = new Color32 (255, 255, 255, 255);
					gColorCheck = false;
				}
			} else {
				//Instruction to player
				uInsPopup.text = "Please select a land";
				//Popup for the land
				StartCoroutine (MenuPopUp (1));
			}
			break;
		case 4:
			if (gColorCheck == true) {
				//On character walk
				GLOBAL.IsCharWalk = true;
				//Added skybox to camera
				cEye.clearFlags = CameraClearFlags.Skybox;
				//Proceed with building page
				mSlider [no].SetActive (true);
				//Tablet on
				mSlider [no + 1].SetActive (true);
				mSlider [no - 1].SetActive (false);
				for (int i = 0; i < mSelect.Length; i++) {
					mSelect [i].color = new Color32 (255, 255, 255, 255);
					gColorCheck = false;
				}
			} else {
				//Instruction to player
				uInsPopup.text = "Please select a building";
				//Popup for the building
				StartCoroutine (MenuPopUp (1));
			}
			break;
		}
	}

	//Coming soon popup effect
	IEnumerator MenuPopUp (int no)
	{
		//On popup
		mPop.SetActive (true);
		//Set the new scale to popup
		mPop.transform.localScale = sZoomIn;
		//Waiting for some seconds
		yield return new WaitForSeconds (0.1f);
		//Set the popup scale to default
		mPop.transform.localScale = sDef;
		//Waiting for some seconds
		yield return new WaitForSeconds (1.25f);
		//Off popup
		mPop.SetActive (false);
	}

	//Coming soon tab
	public void ComingSoonOff (int no)
	{
		//Instruction to player
		uInsPopup.text = "Coming soon...";
		//Start the coming soon popup effect
		StartCoroutine (MenuPopUp (no));
	}

	//Select the land/building
	public void Selection (int no)
	{
		//Color selection on
		gColorCheck = true;
		switch (no) {
		case 0:
			//Selection color for land
			mSelect [0].color = new Color32 (50, 255, 50, 255);
			break;
		case 1:
			//Selection color for building
			mSelect [1].color = new Color32 (50, 255, 50, 255);
			break;
		}
	}

	//Proceed button zoom effect
	IEnumerator ZoomUp (int sNo)
	{
		//Set new scale valve to selection button
		mSelection [sNo].localScale = sZoomIn;
		//Wating for some seconds
		yield return new WaitForSeconds (0.05f);
		//Set default scale to selection button
		mSelection [sNo].localScale = sDef;
	}

	//Proceed button function with zoom in
	public void ZoomEffect (int sNo)
	{
		//Start the selection button zoom effect
		StartCoroutine (ZoomUp (sNo));
	}
}