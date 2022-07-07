using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class StackScript : Singleton<StackScript>
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Pickup":
                other.gameObject.tag = "normal";
                Stack.Ins.PickStack(other.gameObject);
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<StackScript>();
                Destroy(this);
                break;
            case "UnPickup":
                Debug.Log("Hit");
                Stack.Ins.DropStack();
                Destroy(other.gameObject);
                break;
            case "Finish":
                Debug.Log("Finish");
                Stack.Ins.StopPlayer();
                GameManager.Ins.ChangeState(GameState.Finish);
                break;
            case "Push0":
                PlayerController.Ins.isMoving = false;
                PlayerController.Ins.ChangeDirection(Direction.Right, Direction.Down, Direction.Up, Direction.Left);
                break;
            case "Push90":
                PlayerController.Ins.ChangeDirection(Direction.Right, Direction.Up, Direction.Down, Direction.Left);
                break;
            case "Push180":
                PlayerController.Ins.ChangeDirection(Direction.Down, Direction.Right, Direction.Left, Direction.Up);
                break;
            case "Push270":
                PlayerController.Ins.ChangeDirection(Direction.Up, Direction.Right, Direction.Left, Direction.Down);
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Push0":
            case "Push90":
            case "Push180":
            case "Push270":
                PlayerController.Ins.isMoving = true;
                break;
        }
    }
}
