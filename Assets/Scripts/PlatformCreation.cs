using UnityEngine;
using System.Collections.Generic;

public class PlatformCreation : MonoBehaviour
{
    public List<Transform> PlatformGeneration;
    public Transform PlatformGroup, PlatformSwap;
    private void Awake()
    {
        PlatformGroup = GetComponent<Transform>();
    }

    private void Start() {
        for(int i = 0; i < PlatformGroup.childCount; i++)
        {
            PlatformGeneration.Add(PlatformGroup.GetChild(i));
        }
    }

    public void PlatformSwapping()
    {
        PlatformSwap = PlatformGeneration[0];
        PlatformGeneration.Remove(PlatformSwap);
        PlatformGeneration.Add(PlatformSwap);
        PlatformSwap.GetComponent<ObstacleCreation>().ObstaclePositionInitiation();
        PlatformGeneration[10].transform.position = new Vector3(PlatformGeneration[10].transform.position.x, PlatformGeneration[10].transform.position.y, PlatformGeneration[10].transform.position.z + 110f);
    }
}