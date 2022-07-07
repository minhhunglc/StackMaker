using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Direction _currentState;
    public Rigidbody _rb;

    //private Vector2 _firstPos;
    //private Vector2 _secondPos;
    //public Vector2 _currentPos;

    public float _moveSpeed;
    public bool isMoving = true;

    public bool lockUp;
    public bool lockDown;
    public bool lockLeft;
    public bool lockRight;

    public Transform Body;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isMoving = true;
    }
    private void Update() => PlayerMovement();
    public void AssignDirectionFromState()
    {
        switch (_currentState)
        {
            case Direction.Up:
                _rb.velocity = Vector3.forward * _moveSpeed;
                Body.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Down:
                _rb.velocity = Vector3.back * _moveSpeed;
                Body.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case Direction.Left:
                _rb.velocity = Vector3.left * _moveSpeed;
                Body.transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
            case Direction.Right:
                _rb.velocity = Vector3.right * _moveSpeed;
                Body.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }
    private void PlayerMovement()
    {
        #region Test mouse swipe
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    Debug.Log(_firstPos);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //    _currentPos = new Vector2(
        //        _secondPos.x - _firstPos.x,
        //        _secondPos.y - _firstPos.y
        //    );

        //    _currentPos.Normalize();
        //}

        //if (isMoving)
        //{
        //    if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f && !lockUp)
        //    {
        //        // Up
        //        _currentState = Direction.Up;
        //        AssignDirectionFromState();
        //    }
        //    if (_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f && !lockDown)
        //    {
        //        // Down
        //        _currentState = Direction.Down;
        //        AssignDirectionFromState();
        //    }
        //    if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f && !lockRight)
        //    {
        //        // Right
        //        _currentState = Direction.Right;
        //        AssignDirectionFromState();
        //    }
        //    if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f && !!lockLeft)
        //    {
        //        // Left
        //        _currentState = Direction.Left;
        //        AssignDirectionFromState();
        //    }
        //}
        #endregion

        if (isMoving)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)) && lockLeft == false)
            {
                _currentState = Direction.Left;
                AssignDirectionFromState();
            }
            if ((Input.GetKey(KeyCode.RightArrow)) && lockRight == false)
            {
                _currentState = Direction.Right;
                AssignDirectionFromState();
            }
            if ((Input.GetKey(KeyCode.UpArrow)) && lockUp == false)
            {
                _currentState = Direction.Up;
                AssignDirectionFromState();
            }
            if ((Input.GetKey(KeyCode.DownArrow)) && lockDown == false)
            {
                _currentState = Direction.Down;
                AssignDirectionFromState();
            }
        }

    }
    public void ChangeDirection(Direction directionStart1, Direction directionEnd1, Direction directionStart2, Direction directionEnd2)
    {
        if (_currentState == directionStart1)
        {
            _currentState = directionEnd1;
            AssignDirectionFromState();
        }
        else if (_currentState == directionStart2)
        {
            _currentState = directionEnd2;
            AssignDirectionFromState();
        }
    }

}
