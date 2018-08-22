using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_Animator;
    private int m_SpeedID;
    private int m_IsPlusSpeedID;
    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_SpeedID = Animator.StringToHash("Speed");
        m_IsPlusSpeedID = Animator.StringToHash("IsPlusSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        m_Animator.SetFloat(m_SpeedID, v);
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            m_Animator.SetBool(m_IsPlusSpeedID, true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            m_Animator.SetBool(m_IsPlusSpeedID, false);
        }
    }
}
