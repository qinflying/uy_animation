using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_Animator;
    private int m_SpeedZID;
    private int m_SpeedRotateID;
    private int m_IsVaultID;
    private Vector3 m_MaskTarget = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_SpeedZID = Animator.StringToHash("SpeedZ");
        m_SpeedRotateID = Animator.StringToHash("SpeedRotate");
        m_IsVaultID = Animator.StringToHash("IsVault");
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        m_Animator.SetFloat(m_SpeedZID, v * 4.5f);
        float h = Input.GetAxis("Horizontal");
        m_Animator.SetFloat(m_SpeedRotateID, h * 126.0f);
        bool isVault = false;
        if (m_Animator.GetFloat(m_SpeedZID) > 3)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(transform.position + Vector3.up * 0.3f , transform.forward, out hitinfo, 4.5f))
            {
                if (hitinfo.collider.tag == "Obstacle" && hitinfo.distance >3)
                {
                    m_MaskTarget = hitinfo.point;
                    m_MaskTarget.y = hitinfo.collider.transform.position.y + hitinfo.collider.bounds.size.y;
                    m_Animator.SetBool(m_IsVaultID, true);
                    isVault = true;
                }
            }
        }
        else
        {
            m_Animator.SetBool(m_IsVaultID, false);
        }

        if (isVault) {
            m_Animator.MatchTarget(m_MaskTarget, Quaternion.identity, AvatarTarget.LeftHand, new MatchTargetWeightMask(Vector3.one, 0), 0.3f, 0.5f);
        }

    }
}
