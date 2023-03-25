using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static bool canRun, canJump;
    GameObject characterMovement;
    float movementSpeed, jumpSpeed;

    private void Start()
    {
        characterMovement = this.gameObject;
        movementSpeed = 5f;
        jumpSpeed = 10f;
        canJump = true;
        canRun = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Out");
            canRun = false;
        }
    }

    private void Update()
    {
        if(canRun)
        {
            characterMovement.transform.Translate(0, 0, movementSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
            {
                characterMovement.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                canJump = false;
            }
            else
            {
//                characterMovement.GetComponent<Rigidbody>().velocity = Vector3.zero;
                characterMovement.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                canJump = true;
            }
        }
        else
        {
            characterMovement.transform.Translate(0, 0, 0);
        }
    }
}