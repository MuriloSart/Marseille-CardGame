using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Save;

public class LoadScene : MonoBehaviour
{
    public string nomePrimeiraFase = "ReacockPhase";

    public FilePathBuilder filePath;
    public FileHandler fileHandler;

    private void Start()
    {
        if (filePath == null) filePath = FindObjectOfType<FilePathBuilder>();
        if (fileHandler == null) fileHandler = FindObjectOfType<FileHandler>();
    }

    public void LoadByIndex(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(GetSceneIndexByName(sceneName));
    }

    public void LoadCurrentLevel()
    {
        if (!File.Exists(filePath.GetPath())) SaveManager.Instance.Save(GetSceneIndexByName(nomePrimeiraFase));

        SaveSetup setup = fileHandler.GetSetup();

        SceneManager.LoadScene(setup.lastLevel);
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
