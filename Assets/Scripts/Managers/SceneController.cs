using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : Singleton<SceneController>
{
    private float Progress;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void LoadScreenAsync(string nameScene)
    {
        StartCoroutine(LoadLevelWithBar(nameScene));
    }

    IEnumerator LoadLevelWithBar(string nameScene)
    {
        SceneManager.LoadScene("Loading");

        yield return new WaitForSecondsRealtime(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);

        Progress = 0;

        while (!async.isDone)
        {
            Progress = Mathf.Clamp01(async.progress / .9f);
            yield return null;
        }

    }

    public float GetProgress()
    {
        return Progress;
    }
}