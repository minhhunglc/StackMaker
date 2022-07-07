using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : Singleton<Stack>
{

    public GameObject StackParent;
    public GameObject MainStack;

    public Stack<GameObject> Tail = new Stack<GameObject>();

    public void PickStack(GameObject stackob)
    {
        stackob.transform.SetParent(StackParent.transform);
        Vector3 mainStack = MainStack.transform.localPosition;
        mainStack.y -= 0.3f;
        stackob.transform.localPosition = mainStack;

        Vector3 PlayerPosition = transform.localPosition;
        PlayerPosition.y += 0.3f;
        transform.localPosition = PlayerPosition;

        MainStack = stackob;
        MainStack.GetComponent<BoxCollider>().isTrigger = false;
        Tail.Push(stackob);
    }
    public void DropStack()
    {
        Vector3 PlayerPosition = transform.localPosition;
        PlayerPosition.y -= 0.3f;
        transform.localPosition = PlayerPosition;

        MainStack.transform.position = new Vector3(MainStack.transform.position.x, MainStack.transform.position.y + 0.3f, MainStack.transform.position.z);

        Tail.Pop();
        Destroy(Tail.Peek());
    }
    public void StopPlayer()
    {
        transform.position = new Vector3(MainStack.transform.position.x, MainStack.transform.position.y + 0.25f, MainStack.transform.position.z);
        PlayerController.Ins._rb.Sleep();
        PlayerController.Ins._rb.velocity = Vector3.zero;
        PlayerController.Ins.isMoving = false;
    }

}
