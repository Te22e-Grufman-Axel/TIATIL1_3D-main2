using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntereActionController : MonoBehaviour
{
    GameObject cameraObject;

    GameObject gazeTarget;

    void Awake()
    {
        cameraObject = GetComponentInChildren<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject OldGazeTarget = gazeTarget;

        UptadeGaze();

        if (OldGazeTarget != gazeTarget)
        {
            OldGazeTarget?.SendMessage("OnGazeExit",SendMessageOptions.DontRequireReceiver);
            gazeTarget?.SendMessage("OnGazeEnter",SendMessageOptions.DontRequireReceiver);
        }
    }

    private void UptadeGaze()
    {
        RaycastHit hit;
        Physics.Raycast
        (
         cameraObject.transform.position,
         cameraObject.transform.forward,
         out hit,
         3f
        );

        if (hit.collider != null)
        {
            gazeTarget = hit.collider.gameObject;
        }
        else
        {
            gazeTarget = null;
        }
    }

    void OnFire()
    {
        gazeTarget?.SendMessage
        (
          "OnInteract",
           SendMessageOptions.DontRequireReceiver
        );
    }
}
