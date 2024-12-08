using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public void ResultScreen(int screen)
    {
        SceneManager.LoadScene(screen);
    }
}
