using System.Collections;
using UnityEngine;

public class PlayerScriptMovement : MonoBehaviour
{
    public static float distanceCalc = 0;
    public static float movementSpeed = 15;
    public static bool canMove = false;
    public static bool speedBoost = false;
    public static bool end = false;
    public float horizontalSpeed = 3;
    public float rightLimit = 6;
    public float leftLimit = 6;
    public float speedBoostMultiplier;
    public bool isJumping = false;
    public bool falling = false;    
    public GameObject zombie;

    private void Start()
    {
        StartCoroutine(SpeedModifier());
    }

    void Update()
    {
        distanceCalc = this.gameObject.transform.position.z + 23.75f;

        speedBoostMultiplier = speedBoost ? 2 : 1;

        // Adjust forward speed for speed boost
        float currentSpeed = speedBoost ? movementSpeed * speedBoostMultiplier : movementSpeed;

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.World);

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * 6);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * 6);
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    zombie.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(Jump());
                }
            }
        }

        if (isJumping)
        {
            if (!falling)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            }
        }
    }

    IEnumerator SpeedModifier()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            movementSpeed *= 1.10f;
            Debug.Log("Speed increased: " + movementSpeed);
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.45f);
        falling = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        falling = false;
        if (end)
        {
            canMove = false;
        }
        else
        {
            zombie.GetComponent<Animator>().Play("Injured Run");
        }
    }
}
