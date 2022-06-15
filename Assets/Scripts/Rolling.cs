using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    public GameObject player;

    public GameObject center;

    public int step = 9;

    public float speed = 0.01f;
    public float distance = 0.4f;
    public float fallingSpeed = 25;

    //public byte frameCounter = 0;
    //public double yPlaceholder;

    public bool input = true;

    public bool obstacleOnUp;
    public bool obstacleOnDown;
    public bool obstacleOnLeft;
    public bool obstacleOnRight;

    public bool isGrounded = true;

    public LayerMask groundMask;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        center.transform.position = player.transform.position;
    }

    //private void FixedUpdate()
    //{
    //    if (transform.position.y == yPlaceholder)
    //    {
    //        frameCounter++;
    //        if (frameCounter == 2)
    //        {
    //            center.transform.position = player.transform.position;
    //            input = true;
    //            frameCounter = 0;
    //        }
    //    }
    //    else
    //    {
    //        yPlaceholder = transform.position.y;
    //        input = false;
    //        frameCounter = 0;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            transform.position = new Vector3(center.transform.position.x, center.transform.position.y - 4, center.transform.position.z);
            center.transform.position = player.transform.position;  
            input = true;
        }

        if(Physics.CheckSphere(center.transform.position + new Vector3(0, 2, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 2, 0), distance, playerMask))
        {
            input = false;
        }

        isGrounded = Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 0), distance, playerMask);

        obstacleOnUp = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 2), distance, playerMask);
        obstacleOnDown = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -2), distance, playerMask);
        obstacleOnLeft = Physics.CheckSphere(center.transform.position + new Vector3(-2, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-2, 0, 0), distance, playerMask);
        obstacleOnRight = Physics.CheckSphere(center.transform.position + new Vector3(2, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(2, 0, 0), distance, playerMask);

        if (input == true)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !obstacleOnUp)
            {
                StartCoroutine("moveUp");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !obstacleOnDown)
            {
                StartCoroutine("moveDown");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !obstacleOnLeft)
            {
                StartCoroutine("moveLeft");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !obstacleOnRight)
            {
                StartCoroutine("moveRight");
                input = false;
            }
        }
    }
    IEnumerator moveUp()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 2), Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }

        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(center.transform.position + new Vector3(0, -2, -2), Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(center.transform.position + new Vector3(-2, -2, 0), Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(center.transform.position + new Vector3(2, -2, 0), Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(center.transform.position, distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, 2), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, -2), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(-2, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(2, 0, 0), distance);
    }
}
