using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling2 : MonoBehaviour
{
    public GameObject player;

    public GameObject playerHolder;

    public GameObject center;

    public int step = 9;

    public float speed = 0.01f;
    public float distance = 0.4f;
    public float fallingSpeed = 25;

    //public byte frameCounter = 0;
    //public double yPlaceholder;

    public bool input = true;

    public bool isOnBase1;
    public bool isOnBase2;

    public bool isOnBase;

    public bool isOnZ;
    public bool isOnX;

    public Transform base1;
    public Transform base2;

    public LayerMask groundMask;
    public LayerMask playerMask;
    public LayerMask player2Mask;

    public bool obsticleOnUp;
    public bool obsticleOnDown;
    public bool obsticleOnLeft;
    public bool obsticleOnRight;
    public bool obsticleOnUp2;
    public bool obsticleOnDown2;
    public bool obsticleOnLeft2;
    public bool obsticleOnRight2;
    public bool obsticleOnUp3;
    public bool obsticleOnDown3;
    public bool obsticleOnLeft3;
    public bool obsticleOnRight3;

    public bool canStepOnUp;
    public bool canStepOnDown;
    public bool canStepOnLeft;
    public bool canStepOnRight;

    public bool canSlipOnUp;
    public bool canSlipOnDown;
    public bool canSlipOnLeft;
    public bool canSlipOnRight;

    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        center.transform.position = playerHolder.transform.position;
    }

    //private void LateUpdate()
    //{
    //    if (transform.position.y == yPlaceholder)
    //    {
    //        frameCounter++;
    //        if (frameCounter == 2)
    //        {
    //            center.transform.position = playerHolder.transform.position;
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
        obsticleOnUp = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 2), distance, player2Mask);
        obsticleOnDown = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -2), distance, player2Mask);
        obsticleOnLeft = Physics.CheckSphere(center.transform.position + new Vector3(-2, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-2, 0, 0), distance, player2Mask);
        obsticleOnRight = Physics.CheckSphere(center.transform.position + new Vector3(2, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(2, 0, 0), distance, player2Mask);
        obsticleOnUp2 = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 4), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 4), distance, player2Mask);
        obsticleOnDown2 = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -4), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -4), distance, player2Mask);
        obsticleOnLeft2 = Physics.CheckSphere(center.transform.position + new Vector3(-4, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-4, 0, 0), distance, player2Mask);
        obsticleOnRight2 = Physics.CheckSphere(center.transform.position + new Vector3(4, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(4, 0, 0), distance, player2Mask);
        obsticleOnUp3 = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 6), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 6), distance, player2Mask);
        obsticleOnDown3 = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -6), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 0, -6), distance, player2Mask);
        obsticleOnLeft3 = Physics.CheckSphere(center.transform.position + new Vector3(-6, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-6, 0, 0), distance, player2Mask);
        obsticleOnRight3 = Physics.CheckSphere(center.transform.position + new Vector3(6, 0, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(6, 0, 0), distance, player2Mask);

        if(isOnBase)
        {
            canStepOnUp = (Physics.CheckSphere(center.transform.position + new Vector3(0, -1, 2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -1, 2), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(0, 1, 2), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(0, 1, 2), distance, player2Mask));
            canStepOnDown = (Physics.CheckSphere(center.transform.position + new Vector3(0, -1, -2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -1, -2), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(0, 1, -2), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(0, 1, -2), distance, player2Mask));
            canStepOnLeft = (Physics.CheckSphere(center.transform.position + new Vector3(-2, -1, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-2, -1, 0), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(-2, 1, 0), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(-2, 1, 0), distance, player2Mask));
            canStepOnRight = (Physics.CheckSphere(center.transform.position + new Vector3(2, -1, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(2, -1, 0), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(2, 1, 0), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(2, 1, 0), distance, player2Mask));
            canSlipOnUp = false;
            canSlipOnDown = false;
            canSlipOnLeft = false;
            canSlipOnRight = false;
        }
        else if(isOnZ)
        {
            canSlipOnUp = (Physics.CheckSphere(center.transform.position + new Vector3(0, -2, -2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -2, -2), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 2), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 2), distance, player2Mask));
            canSlipOnDown = (Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 2), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -2, 2), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(0, -2, -2), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(0, -2, -2), distance, player2Mask));
            canStepOnUp = false;
            canStepOnDown = false;
            canStepOnLeft = false;
            canStepOnRight = false;
        }
        else if(isOnX)
        {
            canSlipOnLeft = (Physics.CheckSphere(center.transform.position + new Vector3(2, -2, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(2, -2, 0), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(-2, -2, 0), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(-2, -2, 0), distance, player2Mask));
            canSlipOnRight = (Physics.CheckSphere(center.transform.position + new Vector3(-2, -2, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(-2, -2, 0), distance, player2Mask)) && (!Physics.CheckSphere(center.transform.position + new Vector3(2, -2, 0), distance, groundMask) && !Physics.CheckSphere(center.transform.position + new Vector3(2, -2, 0), distance, player2Mask));
            canStepOnUp = false;
            canStepOnDown = false;
            canStepOnLeft = false;
            canStepOnRight = false;
        }
        

        isOnX = Physics.CheckSphere(center.transform.position + new Vector3(4, 0, 0), distance, playerMask);
        isOnZ = Physics.CheckSphere(center.transform.position + new Vector3(0, 0, 4), distance, playerMask);

        isGrounded = Physics.CheckSphere(center.transform.position + new Vector3(0, -4, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, -4, 0), distance, player2Mask);

        if (!isGrounded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
            center.transform.position = playerHolder.transform.position;
        }

        if (isOnX || isOnZ)
            isOnBase = false;
        else
            isOnBase = true;   

        if (isOnBase || !input)
        {
            isOnX = false;
            isOnZ = false;
        }

        if(isOnBase && Physics.CheckSphere(center.transform.position + new Vector3(0, 4, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 4, 0), distance, player2Mask))
        {
            input = false;
        }
        if((isOnX || isOnZ) && Physics.CheckSphere(center.transform.position + new Vector3(0, 2, 0), distance, groundMask) || Physics.CheckSphere(center.transform.position + new Vector3(0, 2, 0), distance, player2Mask))
        {
            input = false;
        }

        if (input)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && ((((isOnBase && !obsticleOnUp && !obsticleOnUp3) || (isOnX && !obsticleOnUp) || (isOnZ && !obsticleOnUp2))) || (canStepOnUp && isOnBase) || (canSlipOnUp && isOnZ)))
            {
                StartCoroutine("moveUp");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && ((((isOnBase && !obsticleOnDown && !obsticleOnDown3) || (isOnX && !obsticleOnDown) || (isOnZ && !obsticleOnDown2))) || (canStepOnDown && isOnBase)))
            {
                StartCoroutine("moveDown");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && ((((isOnBase && !obsticleOnLeft && !obsticleOnLeft3) || (isOnZ && !obsticleOnLeft) || (isOnX && !obsticleOnLeft2))) || (canStepOnLeft && isOnBase)))
            {
                StartCoroutine("moveLeft");
                input = false;
            }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && ((((isOnBase && !obsticleOnRight && !obsticleOnRight3) || (isOnZ && !obsticleOnRight) || (isOnX && !obsticleOnRight2))) || (canStepOnRight && isOnBase)))
            {
                StartCoroutine("moveRight");
                input = false;
            }
        }
    }
    IEnumerator moveUp()
    {
        if (isOnBase && !canStepOnUp && !canSlipOnUp)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -4, 2), Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnX && !canStepOnUp && !canSlipOnUp)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 2), Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnZ && !canStepOnUp && !canSlipOnUp)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 4), Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canStepOnUp)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, 0, 2), Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if(canSlipOnUp)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 0), Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        center.transform.position = playerHolder.transform.position;
        input = true;
    }

    IEnumerator moveDown()
    {
        if (isOnBase && !canStepOnDown && !canSlipOnDown)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -4, -2), Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnX && !canStepOnDown && !canSlipOnDown)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, -2) , Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnZ && !canStepOnDown && !canSlipOnDown)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, -4), Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canStepOnDown)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, 0, -2), Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canSlipOnDown)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 0), Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        center.transform.position = playerHolder.transform.position;
        input = true;
    }

    IEnumerator moveLeft()
    {
        if (isOnBase && !canStepOnLeft && !canSlipOnLeft)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(-2, -4, 0), Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnZ && !canStepOnLeft && !canSlipOnLeft)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(-2, -2, 0), Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnX && !canStepOnLeft && !canSlipOnLeft)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                isOnX = false;
                player.transform.RotateAround(center.transform.position + new Vector3(-4, -2, 0), Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canStepOnLeft)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(-2, 0, 0), Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canSlipOnLeft)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 0), Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        center.transform.position = playerHolder.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        if (isOnBase && !canStepOnRight && !canSlipOnRight)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(2, -4, 0), Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnZ && !canStepOnRight && !canSlipOnRight)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(2, -2, 0), Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (isOnX && !canStepOnRight && !canSlipOnRight)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(4, -2, 0), Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canStepOnRight)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(2, 0, 0), Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        if (canSlipOnRight)
        {
            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(center.transform.position + new Vector3(0, -2, 0), Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        center.transform.position = playerHolder.transform.position;
        input = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, 2), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, -2), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(-2, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(2, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, 4), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, -4), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(-4, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(4, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, 6), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, 0, -6), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(-6, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(6, 0, 0), distance);
        Gizmos.DrawSphere(center.transform.position + new Vector3(0, -4, 0), distance);
    }

}
