using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    bool open = false;

    void OnActivate()
    {
        open = !open;
        GetComponent<Animator>().SetBool("Open", open);
    }
}
