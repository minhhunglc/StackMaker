using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLeft : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Ins.lockLeft = true;
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerController.Ins.lockLeft = true;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.Ins.lockLeft = false;
    }
}
