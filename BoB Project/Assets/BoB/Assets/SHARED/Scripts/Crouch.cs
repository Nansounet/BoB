using UnityEngine;
using System.Collections;

public class Crouch : MonoBehaviour
{

    public CharacterController characterController;

    void Start ()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            characterController.height = 0.95f;
        }
        else
        {
            characterController.height = 1.9f;
        }
   
    }
}
