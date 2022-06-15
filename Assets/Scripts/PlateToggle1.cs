using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateToggle1 : MonoBehaviour
{
    public GameObject obstacle;

    public GameObject checkCuboid;
    public GameObject checkCuboid2;

    public float distance;
    public float moveDistance;

    public LayerMask playerCuboid;

    public bool isPressed;

    public bool isOpened = false;

    public AudioSource Marble;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = Physics.CheckSphere(checkCuboid.transform.position, distance, playerCuboid) && Physics.CheckSphere(checkCuboid2.transform.position, distance, playerCuboid);

        if (!isOpened && isPressed)
        {
            Debug.Log("Opened2");
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
        Gizmos.DrawSphere(checkCuboid.transform.position,distance);
        Gizmos.DrawSphere(checkCuboid2.transform.position, distance);
    }

    public void PlaySFX()
    {
        Marble.Play();
    }
}
