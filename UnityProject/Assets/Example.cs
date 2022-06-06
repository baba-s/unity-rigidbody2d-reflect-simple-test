using UnityEngine;

public sealed class Example : MonoBehaviour
{
    [SerializeField] private float   m_speed     = 15;
    [SerializeField] private Vector2 m_direction = new(1, 1);

    private Rigidbody2D m_rigidbody2D;
    private Vector2     m_velocity;

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        m_direction.Normalize();

        m_velocity             = m_direction * m_speed;
        m_rigidbody2D.velocity = m_velocity;
    }

    private void OnCollisionEnter2D( Collision2D other )
    {
        var normal = other.contacts[ 0 ].normal;

        if ( normal == Vector2.down || normal == Vector2.up )
        {
            m_velocity.y = -m_velocity.y;
        }
        else if ( normal == Vector2.left || normal == Vector2.right )
        {
            m_velocity.x = -m_velocity.x;
        }

        m_rigidbody2D.velocity = m_velocity;
    }
}