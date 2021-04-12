using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishPointController : Dragable
{
    private FinishLineUIController m_finishLineUI;

    private void Start()
    {
        m_finishLineUI = FindObjectOfType<FinishLineUIController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && m_finishLineUI)
        {
            m_finishLineUI.Finish();
        }
    }
}
