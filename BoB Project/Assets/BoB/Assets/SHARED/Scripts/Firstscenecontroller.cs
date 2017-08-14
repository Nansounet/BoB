using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Firstscenecontroller : MonoBehaviour
{

    public string nextScene = "MM";
    // Use this for initialization
    private IEnumerator Start()
    {
         while(!GameSettings.Instance.IsReady)
        {
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
