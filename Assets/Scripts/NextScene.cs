using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;

    public bool isTriggered1;
    public bool isTriggered2;
    public bool isTriggered3;

    public LayerMask playerCube;
    public LayerMask playerCuboid;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void Update()
    {   
        isTriggered1 = Physics.CheckSphere(trigger1.transform.position, 0.1f, playerCube);
        isTriggered2 = Physics.CheckSphere(trigger2.transform.position, 0.1f, playerCuboid);
        isTriggered3 = Physics.CheckSphere(trigger3.transform.position, 0.1f, playerCube);

        if (isTriggered1 || isTriggered3)
        {
            Invoke("DisableCube", 1f);
        }

        if (isTriggered2)
        {
            Invoke("DisableCuboid", 1f);
        }

        if ((isTriggered1 || isTriggered3) && isTriggered2)
        {
            Invoke("LoadNextScene", 1f);
        }
    }
    void DisableCube()
    {
        player1.GetComponent<Rolling>().enabled = false;
        player2.GetComponent<Rolling2>().enabled = true;
    }

    void DisableCuboid()
    {
        player1.GetComponent<Rolling>().enabled = true;
        player2.GetComponent<Rolling2>().enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trigger1.transform.position, 0.1f);
        Gizmos.DrawSphere(trigger2.transform.position, 0.1f);
        Gizmos.DrawSphere(trigger3.transform.position, 0.1f);
    }

    void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < 11) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }
}
