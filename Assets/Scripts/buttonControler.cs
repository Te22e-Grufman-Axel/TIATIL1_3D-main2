using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonControler : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectToActivate;

    private void OnInteract()
    {
        ObjectToActivate?.SendMessage
        (
            "OnActivate",
            SendMessageOptions.DontRequireReceiver
        );
    }

    private void OnGazeEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnGazeExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
