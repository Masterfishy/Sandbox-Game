using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxController : Dragable
{
    [SerializeField]
    private float m_width;

    private BoxCollider2D m_box;

    private void Start()
    {
        m_box = GetComponent<BoxCollider2D>();
        if (m_box)
        {
            m_box.size = new Vector2(m_width, m_box.size.y);
        }
    }

    private void Update()
    {
        Vector2 _pos = transform.position;
        _pos.x = Camera.main.transform.position.x;
        transform.position = _pos;

        if (m_editMode)
        {
            // FIXME Draw a line https://arongranberg.com/aline/docs/getstarted.html
            Debug.DrawLine(new Vector3(transform.position.x - m_width / 2, transform.position.y), new Vector3(transform.position.x + m_width / 2, transform.position.y), Color.red);
        }
    }
}
