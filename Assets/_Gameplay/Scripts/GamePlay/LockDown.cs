using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Ins.lockDown = true;
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerController.Ins.lockDown = true;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.Ins.lockDown = false;
    }
}
