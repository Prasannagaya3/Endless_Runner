using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	public Transform bTruck;
	Camera pEye;
	float zoomIn, zoomOut, zoomDef, curVal, rotSpeed;

	void Start ()
	{
		pEye = GetComponent<Camera> ();
		zoomDef = 10.0f;
		zoomIn = 4.0f;
		zoomOut = 13.0f;
		rotSpeed = 8.0f;
		pEye.orthographicSize = zoomDef;
	}

	void Update ()
	{
		//Pick the Objects
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Picked");
		}

		// Rotate the Objects
		if (Input.GetMouseButton (1)) {
			bTruck.transform.Rotate (bTruck.up, -Input.GetAxis ("Mouse X") * rotSpeed, Space.World);
			Debug.Log ("Click 2");
		}

		// Zoom the Screen
		ZoomFunc ();
	}

	void ZoomFunc ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") != zoomDef) {
			pEye.orthographicSize -= Input.GetAxis ("Mouse ScrollWheel");
			curVal = pEye.orthographicSize;
			if (curVal <= zoomIn) {
				pEye.orthographicSize = zoomIn;
			} else if (curVal >= zoomOut) {
				pEye.orthographicSize = zoomOut;
			}
		}
	}
}
