using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform stopper;
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Move1()
    {
        //if (transform.position.y > stopper.position.y)
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 3 * Time.deltaTime);
        //else
        //    boxCollider.enabled = false;
        if (this.transform.position != stopper.position)
            transform.position = Vector3.Lerp(transform.position, new Vector3(stopper.position.x, stopper.position.y, stopper.position.z), 1 * Time.deltaTime);
        else
            boxCollider.enabled = false;
    }
}
