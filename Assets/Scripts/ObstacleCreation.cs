using UnityEngine;

public class ObstacleCreation : MonoBehaviour
{
    public PlatformCreation PlatformSwap;
    public GameObject CurrentPlatform, ObstaclePrefab;
    Vector3 closePosition, farPosition;
    int randomObstacle;

    private void Start()
    {
        ObstaclePositionInitiation();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Character")
        {
            PlatformSwap.PlatformSwapping();
        }
    }

    public void ObstaclePositionInitiation()
    {
        randomObstacle = Random.Range(1, 10);

        closePosition = new Vector3(CurrentPlatform.transform.position.x, CurrentPlatform.transform.position.y + 0.5f, CurrentPlatform.transform.position.z - 1.5f);
        farPosition = new Vector3(CurrentPlatform.transform.position.x, CurrentPlatform.transform.position.y + 0.5f, CurrentPlatform.transform.position.z + 2.5f);

        if (randomObstacle % 2 == 0)
        {
            ObstaclePrefab.transform.position = closePosition;
        }
        else
        {
            ObstaclePrefab.transform.position = farPosition;
        }
    }
}


/*
randomObstaclePosition = Random.Range(1, 10);
if (randomObstaclePosition % 2 == 0)
        {
            
        }
        else
        {
            closePosition = new Vector3(CurrentPlatform.transform.position.x, CurrentPlatform.transform.position.y + 2f, CurrentPlatform.transform.position.z - 1.5f);
            farPosition = new Vector3(CurrentPlatform.transform.position.x, CurrentPlatform.transform.position.y + 2f, CurrentPlatform.transform.position.z + 2.5f);
        }
*/        