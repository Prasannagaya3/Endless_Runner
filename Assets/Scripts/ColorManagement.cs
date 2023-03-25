using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ColorSegment
{
	public Color32 cOne, cTwo, cThree, cFour;
}

public class ColorManagement : MonoBehaviour
{
	ColorSegment[] cSet;
	public RawImage[] colorDisplay;
	public Text dName;
	int ranTemp, ranSeg;
	public List<Color32> cTemp;

	void Awake ()
	{
		cSet = new ColorSegment[5];
	}

	void Start ()
	{
		cSet [0] = new ColorSegment ();
		cSet [0].cOne = new Color32 (255, 0, 0, 255);
		cSet [0].cTwo = new Color32 (128, 0, 0, 255);
		cSet [0].cThree = new Color32 (165, 42, 42, 255);
		cSet [0].cFour = new Color32 (220, 20, 60, 255);

		cSet [1] = new ColorSegment ();
		cSet [1].cOne = new Color32 (0, 128, 0, 255);
		cSet [1].cTwo = new Color32 (0, 255, 0, 255);
		cSet [1].cThree = new Color32 (124, 252, 0, 255);
		cSet [1].cFour = new Color32 (0, 100, 0, 255);

		cSet [2] = new ColorSegment ();
		cSet [2].cOne = new Color32 (255, 165, 0, 255);
		cSet [2].cTwo = new Color32 (255, 215, 0, 255);
		cSet [2].cThree = new Color32 (240, 230, 140, 255);
		cSet [2].cFour = new Color32 (218, 165, 32, 255);

		cSet [3] = new ColorSegment ();
		cSet [3].cOne = new Color32 (0, 255, 255, 255);
		cSet [3].cTwo = new Color32 (0, 139, 139, 255);
		cSet [3].cThree = new Color32 (127, 255, 212, 255);
		cSet [3].cFour = new Color32 (176, 224, 230, 255);

		cSet [4] = new ColorSegment ();
		cSet [4].cOne = new Color32 (0, 0, 255, 255);
		cSet [4].cTwo = new Color32 (135, 206, 235, 255);
		cSet [4].cThree = new Color32 (0, 0, 128, 255);
		cSet [4].cFour = new Color32 (65, 105, 225, 255);

		RandomizedColor ();
	}

	void RandomizedColor ()
	{
		ranTemp = ranSeg;
		ranSeg = Random.Range (0, 4);
		if (ranSeg == ranTemp) {
			RandomizedColor ();
		} else {
			colorDisplay [0].color = cSet [ranSeg].cOne;
			colorDisplay [1].color = cSet [ranSeg].cTwo;
			colorDisplay [2].color = cSet [ranSeg].cThree;
			colorDisplay [3].color = cSet [ranSeg].cFour;
		}
	}

	void ColorList ()
	{
		
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			RandomizedColor ();
		}
	}
}
