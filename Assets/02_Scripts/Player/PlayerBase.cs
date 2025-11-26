using UnityEngine;
using Globals;

public class PlayerBase : MonoBehaviour
{
    private Animator m_animator;
    private float m_speed = 5f;
    private float m_dashSpeed = 10f;

    public virtual void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        Move();
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
}
