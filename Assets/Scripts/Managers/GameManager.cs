using SOScript;
using UnityEngine;
using Save;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private DataLevels dataLevels;
    private FileHandler file;

    private void Start()
    {
        file = FindObjectOfType<FileHandler>();
        dataLevels.currentLevel = file.GetSetup().lastLevel;
    }

    public void Win()
    {
        ++dataLevels.currentLevel;
        SaveManager.Instance.Save(dataLevels.currentLevel);
    }
}
