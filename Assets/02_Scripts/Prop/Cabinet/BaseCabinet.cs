using UnityEngine;
using Globals;

public abstract class BaseCabinet : MonoBehaviour, IInteractable
{
    public abstract void Interact(PlayerBase _player);

    private Renderer[] m_renderers;
    private Color[] m_originColors;
    private Color m_whiteColor = Color.gray;

    [SerializeField] protected Transform m_dropPoint;
    protected GameObject m_placedItem;

    protected virtual void Start()
    {
        m_renderers = GetComponentsInChildren<Renderer>();
        m_originColors = new Color[m_renderers.Length];

        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_originColors[i] = m_renderers[i].material.GetColor("_EmissionColor");
        }
    }
    
    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Tag.PLAYER))
        {
            HighlightOn();
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tag.PLAYER))
        {
            HighlightOff();
        }
    }

    public void HighlightOn()
    {
        for (int i = 0; i < m_renderers.Length; i++)
        {
            Color c = m_whiteColor * 1f;
            m_renderers[i].material.SetColor("_EmissionColor", c);
            DynamicGI.SetEmissive(m_renderers[i], c);
        }
    }

    public void HighlightOff()
    {
        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_renderers[i].material.SetColor("_EmissionColor", m_originColors[i]);
            DynamicGI.SetEmissive(m_renderers[i], m_originColors[i]);
        }
    }

    public Transform GetDropPoint()
    {
        return m_dropPoint;
    }

    public GameObject GetPlacedItem()
    {
        return m_placedItem;
    }

    public void SetPlacedItem(GameObject item)
    {
        m_placedItem = item;
    }
}
