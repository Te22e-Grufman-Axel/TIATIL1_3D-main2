using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntereActionController : MonoBehaviour
{
GameObject cameraObject;

GameObject gazeTarget;

    // Start is called before the first frame update
    void Awake()
    {
        cameraObject = GetComponentInChildren<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast
        (
         cameraObject.transform.position,
         cameraObject.transform.forward,
         out hit, 
         1.5f
        );

if(hit.collider != null)
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
        gazeTarget?.SendMessage("OnInteract");
    }
}
