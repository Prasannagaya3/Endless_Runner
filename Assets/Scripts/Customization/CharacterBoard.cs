using UnityEngine;

public class CharacterBoard : MonoBehaviour
{
	public Transform cEye;

	void Update ()
	{
		transform.LookAt (cEye);
	}
}