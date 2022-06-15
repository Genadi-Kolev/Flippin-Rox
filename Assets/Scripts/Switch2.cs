using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    GameObject player1;
    public bool switched = true;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !switched )
        {
            this.GetComponent<Rolling2>().enabled = false;
            player1.GetComponent<Rolling>().enabled = true;
            switched = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            switched = false;
        }
    }
}
