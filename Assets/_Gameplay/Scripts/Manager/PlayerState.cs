using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Transform playObj;
    public enum PlayerFSM
    {
        MoveU,
        MoveD,
        MoveL,
        MoveR,
    }
    public virtual void UpdatePlayer(Transform playerObj)
    {

    }
    protected void DoAction(Transform playerObj, PlayerFSM playerMode)
    {
        float _moveSpeed = 20f;
        switch (playerMode)
        {
            case PlayerFSM.MoveU:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.forward * _moveSpeed;
                break;
            case PlayerFSM.MoveD:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.back * _moveSpeed;
                break;
            case PlayerFSM.MoveL:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.left * _moveSpeed;
                break;
            case PlayerFSM.MoveR:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.right * _moveSpeed;
                break;

        }
    }
}

