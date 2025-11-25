using Globals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private static LoadSceneManager m_instance;
    public static LoadSceneManager GetInstacne() => m_instance;

    private string m_currentScene;
    public string CurrentScene => m_currentScene;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string _scene)
    {
        SetCurrentScene(_scene);
        SceneManager.LoadScene(_scene);
    }

    public void SetCurrentScene(string _scene)
    {
        m_currentScene = _scene;

        switch (m_currentScene)
        {
            case SceneName.TITLE:
                break;
            case SceneName.GAME:
                break;
        }
    }
}
