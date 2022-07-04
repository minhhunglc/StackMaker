using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private void Update()
    //{

    //    //Vector3 dir = new Vector3(); //(0,0,0)


    //    //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    //    //    dir.z += 1.0f;
    //    //else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    //    //    dir.x -= 1.0f;
    //    //else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    //    //    dir.z -= 1.0f;
    //    //else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    //    //    dir.x += 1.0f;

    //    //dir.Normalize();
    //    //transform.Translate(dir * CharacterSpeed * Time.deltaTime);

    //    //var up = transform.TransformDirection(Vector3.right);
    //    //RaycastHit hit;
    //    //Debug.DrawRay(transform.position, up, Color.green);

    //    //if (Physics.Raycast(transform.position, up, out hit, 10))
    //    //{
    //    //    Debug.Log("HIT");
    //    //    if (hit.collider.gameObject.name == "Wall")
    //    //    {

    //    //    }
    //    //}


    //}


    private Rigidbody _rb;

    public GameObject StackParent;
    public GameObject MainStack;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    public Vector2 _currentPos;

    public float _moveSpeed;

    public List<GameObject> tail = new List<GameObject>();
    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        SwipePlayer();
        Debug.Log(tail.Count);
    }

    private void SwipePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log(_firstPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(
                _secondPos.x - _firstPos.x,
                _secondPos.y - _firstPos.y
            );

            _currentPos.Normalize();
        }

        if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            // Forward
            _rb.velocity = Vector3.forward * _moveSpeed;
        }
        else if (_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            // Back
            _rb.velocity = Vector3.back * _moveSpeed;
        }
        else if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Right
            _rb.velocity = Vector3.right * _moveSpeed;
        }
        else if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Left
            _rb.velocity = Vector3.left * _moveSpeed;
        }
    }
    public void PickStack(GameObject stackob)
    {
        stackob.transform.SetParent(StackParent.transform);
        Vector3 pos = MainStack.transform.localPosition;
        pos.y -= 0.25f;
        stackob.transform.localPosition = pos;
        Vector3 Characterpos = transform.localPosition;
        Characterpos.y += 0.25f;
        transform.localPosition = Characterpos;
        MainStack = stackob;
        MainStack.GetComponent<BoxCollider>().isTrigger = false;
        tail.Add(stackob);
    }
    public void DropStack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        MainStack.transform.position = new Vector3(MainStack.transform.position.x, MainStack.transform.position.y + 0.25f, MainStack.transform.position.z);
        tail.RemoveAt(tail.Count - 1);
        Destroy(tail[tail.Count - 1]);
    }
    public void DropAllStack()
    {
        foreach (GameObject go in tail)
        {
            tail.Remove(go);
            GameObject.Destroy(go);
        }
    }
}
