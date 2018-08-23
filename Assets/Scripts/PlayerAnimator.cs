using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_Animator;
    private int m_SpeedZID;
    private int m_SpeedRotateID;
    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_SpeedZID = Animator.StringToHash("SpeedZ");
        m_SpeedRotateID = Animator.StringToHash("SpeedRotate");
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        m_Animator.SetFloat(m_SpeedZID, v * 4.5f);
        float h = Input.GetAxis("Horizontal");
        m_Animator.SetFloat(m_SpeedRotateID, h * 126.0f);
    }
}
