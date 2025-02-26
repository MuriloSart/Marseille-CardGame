using SOScript;
using UnityEngine;
using Save;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private DataLevels dataLevels;

    private void Start()
    {
        dataLevels.currentLevel = new FileHandler().GetSetup().lastLevel;
    }

    [NaughtyAttributes.Button]
    public void Win()
    {
        ++dataLevels.currentLevel;
        SaveManager.Instance.Save(dataLevels.currentLevel);
    }
}
