using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameSettings : MonoBehaviour
{
    #region Unity Singleton pattern

    // Instance of the game settings class
    private static GameSettings _instance;

    /// <summary>
    ///  Instance of the game settings class. There should only be one of these!
    /// </summary>
    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameSettings>();
                if (_instance == null)
                {
                    // Create a game object that is a holder for our game settings script
                    GameObject go = new GameObject("_Singleton_GameSettings");

                    // ADD the game settings script to the holder object
                    _instance = go.AddComponent<GameSettings>();

                    // Teel Unity not to unload this object; there's one per game!
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;

        }
    }

    #endregion

    #region Static names

    /// <summary>
    /// The name of the settings file.
    /// </summary>
    static readonly string SETTINGS_FILE = "settings.json";

    #endregion

    #region Public properties

    /// <summary>
    /// Indicates that the game settings have been loaded and the object is ready.
    /// </summary>
    public bool IsReady { get; private set; }


    /// <summary>
    /// Unity quality settings.
    /// </summary>
    public List<string> QualityNames { get; private set; }

    /// <summary>
    /// Unity Resolutions settings.
    /// </summary>
    public List<Resolution> Resolutions { get; private set; }

    /// <summary>
    ///  The user current game options.
    /// </summary>
    public UserGameOptions UserOptions { get; private set; }

     #endregion

    #region Public methods

    public void SaveSettings(int quality, int width, int height, bool fullscreen)
    {
        var settings = new UserGameOptions()
        {
            quality = quality,
            fullScreen = fullscreen,
            height = height,
            width = width,
        };

        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FILE);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        File.WriteAllText(fullPath, JsonUtility.ToJson(settings));
        ApplySettings(settings);

        UserOptions = settings;

    }

    #endregion

    #region Unity messages

    /// <summary>
    /// Awaken the object!
    /// </summary>
    private void Awake()
    {
        QualityNames = new List<string>(QualitySettings.names);
        Resolutions = new List<Resolution>(Screen.resolutions);

        UserOptions = LoadOptions();

        IsReady = true;
    }

    #endregion

    #region Private Helper methods

    /// <summary>
    /// Loads the users current options.
    /// </summary>
    UserGameOptions LoadOptions()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FILE);

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            var settings = JsonUtility.FromJson<UserGameOptions>(json);
            ApplySettings(settings);
            return settings;
        }
        else
        {
            return new UserGameOptions()
            {
                quality = QualitySettings.GetQualityLevel(),
                fullScreen = Screen.fullScreen,
                height = Screen.height,
                width = Screen.width
            };
        }

    }

    void ApplySettings(UserGameOptions settings)
    {
        QualitySettings.SetQualityLevel(settings.quality);
        Screen.SetResolution(settings.width, settings.height, settings.fullScreen);
    }

    #endregion


}
