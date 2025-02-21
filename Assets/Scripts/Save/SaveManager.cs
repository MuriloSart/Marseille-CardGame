using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    private string saveFilePath;
    private void Start()
    {
        saveFilePath = Application.dataPath + "/save.txt";

    }   

    public void CreateFile(int sceneIndex)
    {
        SaveSetup setup = new SaveSetup
        {
            lastLevel = sceneIndex
        };

        string setupToJson = JsonUtility.ToJson(setup, true);

        File.WriteAllText(saveFilePath, setupToJson);

        Debug.Log("Salvando o índice da cena: " + sceneIndex);
    }
}
