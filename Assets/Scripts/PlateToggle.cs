using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateToggle : MonoBehaviour
{
    public GameObject obstacle;

    public GameObject checkCuboid;

    public float distance;
    public float moveDistance;

    public LayerMask playerCube;

    public bool isPressed;

    public bool isOpened = false;

    public AudioSource Wood;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isPressed = Physics.CheckSphere(checkCuboid.transform.position, distance, playerCube);

        if (!isOpened && isPressed)
        {
            Debug.Log("Opened1");
            isOpened = true;
            PlaySFX();
        }

        if (isOpened)
        {
            obstacle.GetComponent<Move>().Move1();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(checkCuboid.transform.position, distance);
    }

    public void PlaySFX()
    {
        Wood.Play();
    }
}
