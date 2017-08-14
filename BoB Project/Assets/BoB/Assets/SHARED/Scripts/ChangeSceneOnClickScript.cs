using UnityEngine;
using System.Collections;

public class ChangeSceneOnClickScript : MonoBehaviour {

	public string _nextScene = "";

	public void Update()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touches != null && Input.touches.Length > 0) || Input.GetKey(KeyCode.Joystick1Button0))
		{
			Application.LoadLevel(_nextScene);
		}
	}
}
