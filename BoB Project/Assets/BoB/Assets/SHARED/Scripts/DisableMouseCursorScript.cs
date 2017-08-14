using UnityEngine;
using System.Collections;

public class DisableMouseCursorScript : MonoBehaviour {

	
    CursorLockMode wantedMode;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = wantedMode;
            Cursor.visible = (CursorLockMode.Locked != wantedMode);
        }
    }
}

