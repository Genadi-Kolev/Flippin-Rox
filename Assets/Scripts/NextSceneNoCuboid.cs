using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneNoCuboid : MonoBehaviour
{
    public GameObject trigger;

    public bool isTriggeredCube;
    public LayerMask playerCube;
    public GameObject transitionVideo;

    private void Update()
    {
        
        isTriggeredCube = Physics.CheckSphere(trigger.transform.position, 0.4f, playerCube);
        if (isTriggeredCube)
        {
            Invoke("LoadNextScene", 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trigger.transform.position, 0.4f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
