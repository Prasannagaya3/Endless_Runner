using UnityEngine;

public class TileCollision : MonoBehaviour
{
	public CharacterAction cAction;
	public TileGeneration tGeneration;

	void OnCollisionEnter (Collision call)
	{
		if (call.gameObject.tag == "Player") {
			tGeneration.TileSwap ();
		}
	}
}
