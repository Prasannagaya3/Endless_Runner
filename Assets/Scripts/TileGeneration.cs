using UnityEngine;
using System.Collections.Generic;

public class TileGeneration : MonoBehaviour
{
	public List<Transform> tGen;
	public Transform tGroup, tSwap;

	void Start ()
	{
		tGroup = GetComponent<Transform> ();
		for (int i = 0; i < tGroup.childCount; i++) {
			tGen.Add (tGroup.GetChild (i));
		}
	}

	public void TileSwap ()
	{
		tSwap = tGen [0];
		tGen.Remove (tSwap);
		tGen.Add (tSwap);
		tGen [7].transform.position = new Vector3 (tGen [7].transform.position.x + 24.0f, tGen [7].transform.position.y, tGen [7].transform.position.z);
	}
}

//		Array Test
//		public Transform[] tTiles;
//		tTiles = new Transform[tGroup.childCount];
//		for (int i = 0; i < tGroup.childCount; i++) {
//			tTiles [i] = tGroup.GetChild (i);
//		}