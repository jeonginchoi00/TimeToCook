using UnityEngine;
using UnityEngine.UI;
using Globals;
using DG.Tweening;

public class Page_Title : PageTemplate
{
    [SerializeField] private Button m_startBtn;
    [SerializeField] private Button m_quitBtn;
    [SerializeField] private Image m_titleImg;

    public override void Initialize()
    {
        base.Initialize();

        m_startBtn.onClick.AddListener(OnClickStartBtn);
        m_quitBtn.onClick.AddListener(OnClickQuitBtn);

        TitleAnim();
    }

    public override void ActivePage()
    {
        base.ActivePage();
    }

    public override void InActivePage()
    {
        base.InActivePage();
    }

    private void OnClickStartBtn()
    {
        LoadSceneManager.GetInstance().LoadScene(SceneName.GAME);
    }

    private void OnClickQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void TitleAnim()
    {
        m_titleImg.DOKill();

        m_titleImg.transform.localScale = Vector3.one;

        m_titleImg.transform
            .DOScale(1.3f, 0.8f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
