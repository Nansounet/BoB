using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionSceneController : MonoBehaviour
{
    // List of filtered RES.
    List<Resolution> filteredRes;

    bool fullscreen;

    public Dropdown quality;

    public Dropdown resolution;

    public Toggle fullscreentoggle;

    public void FullScreen_Clicked(bool newValue)
    {
        fullscreen = newValue;
    }

    public void Apply_Clicked()
    {
        Resolution res = filteredRes[resolution.value];
        int qual = quality.value;


        GameSettings.Instance.SaveSettings(qual, res.width, res.height, fullscreen);

        SceneManager.LoadScene("MM");
    }

    public void Cancel_Clicked()
    {
        SceneManager.LoadScene("MM");
    }

	// Use this for initialization
	IEnumerator Start ()
    {
        // Wait for the game settings to become available
        while (!GameSettings.Instance.IsReady)
        {
            yield return null;
        }

        var user = GameSettings.Instance.UserOptions;


        // Apply the contents of quality ...
        quality.ClearOptions();
        quality.AddOptions(GameSettings.Instance.QualityNames);
        quality.value = user.quality;

        // ...and Screen to the drop downs
        List<string> resos = new List<string>();
        filteredRes = new List<Resolution>();

        int lw = -1;
        int lh = -1;

        int index = 0;
        int currentResIndex = -1;

        foreach(var res in GameSettings.Instance.Resolutions)
        {
            if (lw != res.width || lh != res.height)
            {
                // Create a neatly formatted string to add to the dropdown
                string fmt = string.Format("{0} x {1} @ {2}", res.width, res.height , res.refreshRate);
                resos.Add(fmt);

                lw = res.width;
                lh = res.height;

                if (lw == user.width && lh == user.height)
                {
                    currentResIndex = index;
                }

                // add the filtered res there.
                filteredRes.Add(res);

                index++;
            }
            
        }

        resolution.ClearOptions();
        resolution.AddOptions(resos);
        resolution.value = currentResIndex;

        fullscreentoggle.isOn = user.fullScreen;

        // Apply the current settings to the user's preferences

    }


}
