using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.tag = "normal";
            PlayerController.Instance.PickDash(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackScript>();
            PlayerController.Instance.tail.Add(other.gameObject);

        }
        if (other.tag == "UnPickup")
        {
            Debug.Log("Hit");
            PlayerController.Instance.DropDash();
            Destroy(other.gameObject);
        }
    }
}
