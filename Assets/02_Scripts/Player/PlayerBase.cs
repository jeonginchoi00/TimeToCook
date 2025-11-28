using UnityEngine;
using Globals;

public class PlayerBase : MonoBehaviour
{
    private Animator m_animator;
    private float m_speed = 5f;
    private float m_dashSpeed = 10f;

    private IInteractable m_currentTarget;

    [SerializeField] private Transform m_hand;
    private GameObject m_heldItem;

    public virtual void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        Move();
        HandleInteraction();
    }

    public virtual void Move()
    {
        float h = Input.GetAxisRaw(InputKey.HORIZONTAL);
        float v = Input.GetAxisRaw(InputKey.VERTICAL);

        Vector3 movement = new Vector3(h, 0, v).normalized;
        bool isMoving = movement.magnitude > 0f;
        bool isDash = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
        {
            // 회전
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * 10f);

            // 이동
            float currentSpeed = isDash ? m_dashSpeed : m_speed;
            transform.position += movement * Time.deltaTime * currentSpeed;

            m_animator.SetBool(AnimKey.ISRUN, isDash);
            m_animator.SetBool(AnimKey.ISWALK, !isDash);
        }
        else
        {
            m_animator.SetBool(AnimKey.ISRUN, false);
            m_animator.SetBool(AnimKey.ISWALK, false);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            m_currentTarget = interactable;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null && interactable == m_currentTarget)
        {
            m_currentTarget = null;
        }
    }

    public virtual void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HasItem())
            {
                if (m_currentTarget is BaseCabinet cabinet)
                {
                    if (cabinet.GetPlacedItem() != null)
                    {
                        return;
                    }

                    Transform dropPoint = cabinet.GetDropPoint();

                    if (dropPoint != null)
                    {
                        m_heldItem.transform.SetParent(null);
                        m_heldItem.transform.position = dropPoint.position;
                        m_heldItem.transform.rotation = dropPoint.rotation;

                        cabinet.SetPlacedItem(m_heldItem);

                        m_heldItem = null;
                    }
                }

                return;
            }

            if (m_currentTarget is BaseCabinet cab)
            {
                GameObject placed = cab.GetPlacedItem();

                if (placed != null)
                {
                    placed.transform.SetParent(m_hand);
                    placed.transform.localPosition = Vector3.zero;

                    m_heldItem = placed;

                    cab.SetPlacedItem(null);

                    return;
                }
            }

            if (m_currentTarget != null)
            {
                m_currentTarget.Interact(this);
            }
        }
    }

    public Transform GetHandTransform()
    {
        return m_hand;
    }

    public void PickUp(GameObject _item)
    {
        m_heldItem = _item;
    }

    public void DropItem()
    {
        if (m_heldItem != null)
        {
            m_heldItem.transform.SetParent(null);
            m_heldItem = null;
        }
    }

    public bool HasItem()
    {
        return m_heldItem != null;
    }
}
