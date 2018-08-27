using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_AutoRotate : MonoBehaviour
{
    public float m_RotateSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * m_RotateSpeed * Time.deltaTime, Space.World);
    }
}
