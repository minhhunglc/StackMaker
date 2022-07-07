using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Ins.lockRight = true;
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerController.Ins.lockRight = true;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.Ins.lockRight = false;
    }
}
