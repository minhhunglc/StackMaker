using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Ins.lockUp = true;
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerController.Ins.lockUp = true;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.Ins.lockUp = false;
    }
}
