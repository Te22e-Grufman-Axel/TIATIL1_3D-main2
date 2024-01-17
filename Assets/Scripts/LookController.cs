using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
  GameObject head;

  float xCameraRotation = 0;

  [SerializeField]
  Vector2 sensitivity = Vector2.one;

  [SerializeField]
  float viewAngeleLimit = 80;

  private void Awake()
  {
    head = GetComponentInChildren<Camera>().gameObject;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void OnLook(InputValue value)
  {
    Vector2 lookVector = value.Get<Vector2>();

    // Horizontal
    float degreesY = lookVector.x * sensitivity.x * Time.smoothDeltaTime;
    transform.Rotate(Vector3.up, degreesY);

    // Vertical
    float degreesX = -lookVector.y * sensitivity.y * Time.smoothDeltaTime;
    xCameraRotation += degreesX;
    xCameraRotation = Mathf.Clamp(xCameraRotation, -viewAngeleLimit, viewAngeleLimit);
    head.transform.localEulerAngles = new(xCameraRotation, 0, 0);
  }
  
}
