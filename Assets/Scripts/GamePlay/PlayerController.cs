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

    public static PlayerController Instance;
    private Rigidbody _rb;

    public GameObject DashParent;
    public GameObject PrevDash;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    public Vector2 _currentPos;

    public float _moveSpeed;

    public List<GameObject> tail = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
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
    public void PickDash(GameObject dashob)
    {
        dashob.transform.SetParent(DashParent.transform);
        Vector3 pos = PrevDash.transform.localPosition;
        pos.y -= 0.25f;
        dashob.transform.localPosition = pos;
        Vector3 Characterpos = transform.localPosition;
        Characterpos.y += 0.25f;
        transform.localPosition = Characterpos;
        PrevDash = dashob;
        PrevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
    public void DropDash()
    {
        //Vector3 Characterpos = transform.localPosition;
        //Characterpos.y -= 0.25f;
        //transform.localPosition = Characterpos;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        PrevDash.transform.position = new Vector3(PrevDash.transform.position.x, PrevDash.transform.position.y + 0.25f, PrevDash.transform.position.z);
        tail.RemoveAt(tail.Count - 1);
        Destroy(tail[tail.Count - 1]);
    }
}
