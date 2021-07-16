using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string bestScorePlayerName;
    public int bestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public string bestScorePlayerName;
        public int bestScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        
        data.bestScorePlayerName = bestScorePlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePlayerName = data.bestScorePlayerName;
            bestScore = data.bestScore;

        }
    }

    public string getBestScoreText()
    {
        return $"Best Score : {GameManager.Instance.bestScorePlayerName} : {GameManager.Instance.bestScore}";
    }

}
