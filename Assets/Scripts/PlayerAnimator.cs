using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_Animator;
    private CharacterController m_CharacterController;
    private int m_SpeedZID = Animator.StringToHash("SpeedZ");
    private int m_SpeedRotateID = Animator.StringToHash("SpeedRotate");
    private int m_IsVaultID = Animator.StringToHash("IsVault");
    private int m_ColliderID = Animator.StringToHash("Collider");
    private int m_SliderID = Animator.StringToHash("IsSlider");
    private Vector3 m_MaskTarget = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        m_Animator.SetFloat(m_SpeedZID, v * 4.5f);
        float h = Input.GetAxis("Horizontal");
        m_Animator.SetFloat(m_SpeedRotateID, h * 126.0f);
        OnVaultCheck();
        OnSliderCheck();
        m_CharacterController.enabled = m_Animator.GetFloat(m_ColliderID) < 0.5;
    }

    void OnVaultCheck() {
        bool isVault = false;
        if (m_Animator.GetFloat(m_SpeedZID) > 3)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(transform.position + Vector3.up * 0.3f, transform.forward, out hitinfo, 4.5f))
            {
                if (hitinfo.collider.tag == "Obstacle" && hitinfo.distance > 3)
                {
                    m_MaskTarget = hitinfo.point;
                    m_MaskTarget.y = hitinfo.collider.transform.position.y + hitinfo.collider.bounds.size.y + 0.1f;
                    isVault = true;
                }
            }
        }

        m_Animator.SetBool(m_IsVaultID, isVault);
        AnimatorStateInfo stateinfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Vault") && m_Animator.IsInTransition(0) == false)
        {
            m_Animator.MatchTarget(m_MaskTarget, Quaternion.identity, AvatarTarget.LeftHand, new MatchTargetWeightMask(Vector3.one, 0), 0.31f, 0.41f);
        }
    }

    void OnSliderCheck() {
        bool isSlider = false;
        Vector3 maskTarget = Vector3.zero;
        if (m_Animator.GetFloat(m_SpeedZID) > 3)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.forward, out hitinfo, 3f))
            {
                if (hitinfo.collider.tag == "Obstacle" && hitinfo.distance > 2)
                {
                    maskTarget = hitinfo.point;
                    maskTarget.y = 0;
                    maskTarget += transform.forward * 2;
                    isSlider = true;
                }
            }
        }

        m_Animator.SetBool(m_SliderID, isSlider);
        AnimatorStateInfo stateinfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Slide") && m_Animator.IsInTransition(0) == false)
        {
            m_Animator.MatchTarget(maskTarget, Quaternion.identity, AvatarTarget.Body, new MatchTargetWeightMask(new Vector3(1, 0, 1), 0), 0.21f, 0.43f);
        }

    }
}
