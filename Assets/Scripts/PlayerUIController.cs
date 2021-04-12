using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Text m_speedText;
    public Text m_jumpText;

    private PlayerController m_player;

    private void Awake()
    {
        m_player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (m_player)
        {
            float _speed = m_player.Speed;
            float _jump = m_player.Jump;

            UpdateText(m_speedText, _speed.ToString());
            UpdateText(m_jumpText, _jump.ToString());
        }
    }

    private void UpdateText(Text text, string val)
    {
        if (text)
        {
            text.text = val;
        }
    }
}
