using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private static TitleManager m_instance;
    public static TitleManager GetInstance() => m_instance;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
    }

    private void OnDestroy()
    {
        if (m_instance == this)
        {
            m_instance = null;
        }
    }
}
