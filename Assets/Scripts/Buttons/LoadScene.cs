using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nomePrimeiraFase = "ReacockPhase";

    private string jsonString;

    private void Awake()
    {
        jsonString = Application.dataPath + "/save.txt";    
    }

    public void Load(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadCurrentLevel()
    {
        if (File.Exists(jsonString))
        {
            string json = File.ReadAllText(jsonString);
            SaveSetup setup = JsonUtility.FromJson<SaveSetup>(json);

            SceneManager.LoadScene(setup.lastLevel);
        }
        else
        {
            SaveManager.Instance.CreateFile(GetSceneIndexByName(nomePrimeiraFase));
        }
    }

    private static int GetSceneIndexByName(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameFromPath = Path.GetFileNameWithoutExtension(scenePath);

            if (sceneNameFromPath == sceneName)
            {
                return i;
            }
        }
        return 0; 
    }

}
