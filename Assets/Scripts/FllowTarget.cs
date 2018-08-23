using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowTarget : MonoBehaviour
{
    public float m_Smoothing = 3.0f;
    private Transform m_Player;
    private Vector3 m_Offset;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Offset = transform.position - m_Player.position;
    }

    void LateUpdate()
    {
        Vector3 position = m_Player.position + m_Player.TransformDirection(m_Offset);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * m_Smoothing);
        transform.LookAt(m_Player.position);
    }
}
