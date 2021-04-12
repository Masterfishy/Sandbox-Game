using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Dragable : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool m_removeable;

    protected bool m_editMode;
    
    private GameManager m_gm;
    private bool m_drag;

    private void Awake()
    {
        m_drag = false;
        m_editMode = true;

        m_gm = FindObjectOfType<GameManager>();
        if (m_gm)
        {
            m_gm.OnEdit.AddListener(() => m_editMode = true);
            m_gm.OnPlay.AddListener(() => m_editMode = false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_editMode)
        {
            m_gm.SetSelected(this);
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

    public void Remove()
    {
        if (m_removeable)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
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
