using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask m_groundLayer;

    [SerializeField]
    private float m_speed;
    public float Speed { get { return m_speed; } }

    [SerializeField]
    private float m_jump;
    public float Jump { get { return m_jump; } }

    [SerializeField]
    private float m_groundDistance;

    private Rigidbody2D rb;

    private bool m_editMode;
    private bool m_grounded;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D _raycast = Physics2D.Raycast(transform.position, -Vector2.up, m_groundDistance, m_groundLayer);
        m_grounded = _raycast;
    }

    public void OnEdit()
    {
        // Go back to start and freeze
        m_editMode = true;
        rb.simulated = false;

        GoToStart();
    }

    public void OnPlay()
    {
        // Unfreeze player, allow them to move and play the game
        m_editMode = false;
        rb.simulated = true;
        
        GoToStart();

        // TODO Start coroutine to handle player movement
        StartCoroutine(PlayMode());
    }

    public void IncreaseSpeed()
    {
        m_speed++;
    }

    public void DecreaseSpeed()
    {
        m_speed--;
    }

    public void IncreaseJump()
    {
        m_jump++;
    }

    public void DecreaseJump()
    {
        m_jump--;
    }

    private IEnumerator PlayMode()
    {
        while (!m_editMode)
        {
            float _horizontal = Input.GetAxis("Horizontal");
            float _vertical = Input.GetAxisRaw("Jump");

            Vector2 _vel = rb.velocity;
            _vel.x = _horizontal * m_speed;

            if (m_grounded && _vertical > 0)
            {
                // TODO jump
                _vel.y = m_jump;
            }

            rb.velocity = _vel;

            yield return new WaitForFixedUpdate();
        }
    }

    private void GoToStart()
    {
        GameObject _startPoint = GameObject.FindGameObjectWithTag("Start");
        if (_startPoint)
        {
            transform.position = _startPoint.transform.position;
        }
    }
}
