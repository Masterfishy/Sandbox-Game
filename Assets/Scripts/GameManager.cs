﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnEdit;
    public UnityEvent OnPlay;

    public GameObject m_groundPrefab;
    public GameObject m_finishLinePrefab;

    [SerializeField]
    private bool m_editMode;

    private GameObject m_selectedObject;

    private void Awake()
    {
        m_editMode = true;
        OnEdit.Invoke();
    }

    public void ToggleEditMode()
    {
        m_editMode = !m_editMode;
        SetSelected(null);

        if (m_editMode)
        { 
            OnEdit.Invoke();
            return;
        }

        OnPlay.Invoke();
    }

    public void MakeBlock()
    {
        // TODO Spawn a grouudn
        Transform _camera = Camera.main.transform;
        if (_camera && m_groundPrefab)
        {
            Vector3 _pos = new Vector3(_camera.position.x, _camera.position.y);
            Instantiate(m_groundPrefab, _pos, Quaternion.identity, transform);
        }
    }

    public void MakeFinishLine()
    {
        Transform _camera = Camera.main.transform;
        if (_camera && m_finishLinePrefab)
        {
            Vector3 _pos = new Vector3(_camera.position.x, _camera.position.y);
            Instantiate(m_finishLinePrefab, _pos, Quaternion.identity, transform);
        }
    }

    public void SetSelected(GameObject go)
    {
        m_selectedObject = go;
    }

    public void RemoveSelected()
    {
        if (m_selectedObject && !m_selectedObject.CompareTag("Start"))
        {
            Destroy(m_selectedObject);
            SetSelected(null);
        }
    }
}