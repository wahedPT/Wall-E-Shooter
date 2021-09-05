using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{
    public PlayerInput playetinput;
    public int priorityBoostAmount=10;


    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;


    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playetinput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();

    }

    private void OnDisable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }



    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
    }
}
