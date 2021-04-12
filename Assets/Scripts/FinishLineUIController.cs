using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineUIController : MonoBehaviour
{
    private GameObject m_finishLineUI;

    private void Awake()
    {
        Transform _child = transform.GetChild(0);
        if (_child)
        {
            m_finishLineUI = _child.gameObject;
            OnEdit();
        }
    }

    public void OnEdit()
    {
        if (m_finishLineUI)
        {
            m_finishLineUI.SetActive(false);
        }
    }

    public void Finish()
    {
        if (m_finishLineUI)
        {
            m_finishLineUI.SetActive(true);
        }
    }
}
