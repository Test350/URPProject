using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraController : MonoBehaviour
{
    private CinemachineFreeLook cl;
    void Start()
    {
        cl = GetComponent<CinemachineFreeLook>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();

        cl.m_XAxis.Value += delta.x;
        cl.m_YAxis.Value += delta.y;
    }
}
