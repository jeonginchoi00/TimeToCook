using Globals;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupTemplate : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PopupType m_popupType;
    [SerializeField] private Button m_closeBtn;
    [SerializeField] private Image m_background;

    public virtual void Initialize()
    {
        m_closeBtn.onClick.AddListener(OnClickCloseBtn);
    }

    public virtual void ActivePopup()
    {
        gameObject.SetActive(true);
    }

    public virtual void InActivePopup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnClickCloseBtn()
    {
        InActivePopup();
    }

    public virtual void OnPointerClick(PointerEventData _eventData)
    {
        if (_eventData.pointerCurrentRaycast.gameObject == m_background.gameObject)
        {
            InActivePopup();
        }
    }

}
