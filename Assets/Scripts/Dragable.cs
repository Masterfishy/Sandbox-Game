using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameManager m_gm;
    private bool m_drag;
    private bool m_editMode;

    private void Awake()
    {
        m_drag = false;
        m_editMode = true;

        m_gm = FindObjectOfType<GameManager>();
        m_gm.OnEdit.AddListener(() => m_editMode = true);
        m_gm.OnPlay.AddListener(() => m_editMode = false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_editMode)
        {
            m_gm.SetSelected(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_drag = true;

        if (m_editMode)
        {
            StartCoroutine(MoveToMouse());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_drag = false;
    }

    private IEnumerator MoveToMouse()
    {
        while (m_drag)
        {
            Vector3 _mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Round(_mouse.x), 
                                             Mathf.Round(_mouse.y), 
                                             transform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
}
