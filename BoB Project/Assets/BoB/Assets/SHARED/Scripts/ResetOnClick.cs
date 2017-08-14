using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ResetOnClick : MonoBehaviour
{
    public Transform canvas;
    public Transform Player;


    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            AudioListener.volume = 0;
            Player.GetComponent<FirstPersonController>().enabled = false;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = 1;
            Player.GetComponent<FirstPersonController>().enabled = true;
        }
    }
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void LoadLevel(int sceneIndex)

    {
        StartCoroutine(LoadAsynchronously(sceneIndex));


    }

    IEnumerator LoadAsynchronously(int sceneIndex)

    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        loadingScreen.SetActive(true);

        while (!operation.isDone)

        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = "Loading";

            yield return null;
        }
    }
}