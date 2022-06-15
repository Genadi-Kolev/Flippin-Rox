using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    GameObject player2;
    public bool switched = false;

    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.FindWithTag("Player2");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !switched)
        {
            this.GetComponent<Rolling>().enabled = false;
            player2.GetComponent<Rolling2>().enabled = true;
            switched = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            switched = false;
        }
    }
}
