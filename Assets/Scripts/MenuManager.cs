using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public int highscore = 0;
    public string username { get; private set; } = "Username";

    // Start is called before the first frame update
    void Awake()
    {
        LoadDataFunction();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void InputFunction()
    {
        username = FindObjectOfType<TMP_InputField>().text;
        UpdateReferences();
        SaveDataFunction();
    }

    public void StartFunction()
    {
        SaveDataFunction();
        SceneManager.LoadScene(1);
    }
    public void QuitFunction()
    {
        SaveDataFunction();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    class SaveData
    {
        public int highscore;
        public string username;
    }

    public void SaveDataFunction()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.username = username;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savaData.json", json);

    }
    public void LoadDataFunction()
    {
        string path = Application.persistentDataPath + "/savaData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
            username = data.username;
            UpdateReferences();
        }

    }
    public void UpdateReferences()
    {
        GameObject.Find("HighscoreText").GetComponent<TextMeshProUGUI>().text = "Highscore : " + username + " : " + highscore;
    }


}
