using UnityEngine;
using System.Collections;

public class DisableMouseCursorScript : MonoBehaviour {

	void Start()
	{
		Cursor.visible = false;
		Screen.lockCursor = true;
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)){
			Cursor.visible= ! Cursor.visible;
			Screen.lockCursor= ! Screen.lockCursor;
					}
		}
}
