using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _movement;
    private PlayerMovement _playerMovement;
    private bool _jump;



    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);

        _jump = Input.GetButton(GlobalStringVars.JUMP_BUTTON);

        _movement = new Vector3(0, 0, horizontal);
    }

    public void FixedUpdate()
    {
        _playerMovement.MoveCharacter(_movement);
        _playerMovement.Jump(_jump);
    }
}
