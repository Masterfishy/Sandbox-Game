using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    
    private Transform player;
    private bool m_editMode;

    public void OnEdit()
    {
        // TODO Go to general view and allow player to move it
        m_editMode = true;

        GameObject _startPoint = GameObject.FindGameObjectWithTag("Start");
        if (_startPoint)
        {
            transform.position = new Vector3(_startPoint.transform.position.x, _startPoint.transform.position.y, transform.position.z);
        }

        StartCoroutine(KeyboardControls());
    }

    public void OnPlay()
    {
        // TODO follow player
        m_editMode = false;
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        if (_player)
        {
            player = _player.transform;
            // TODO start coroutine to follow player, maybe change to move like in mario
            StartCoroutine(FollowPlayer());
        }
    }

    private IEnumerator KeyboardControls()
    {
        while (m_editMode)
        {
            // TODO use keyboard controls to move
            float _horizontal = Input.GetAxis("Horizontal");
            float _vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(_horizontal * m_speed, _vertical * m_speed, 0);

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator FollowPlayer()
    {
        while (!m_editMode)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

            yield return new WaitForFixedUpdate();
        }
    }
}
