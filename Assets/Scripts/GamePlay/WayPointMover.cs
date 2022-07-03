using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Moving
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
}
public class WayPointMover : MonoBehaviour
{
    #region test
    [SerializeField] private WayPoints wayPoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;
    private Transform currentWayPoint;
    private Transform currentPreviousPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWayPoint = wayPoints.GetNextWayPoint(currentWayPoint);
        transform.position = currentWayPoint.position;
        //currentPreviousPoint = wayPoints.GetPreviousWayPoint(currentPreviousPoint);
        transform.LookAt(currentWayPoint);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, currentPreviousPoint.position, moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
            {
                currentWayPoint = wayPoints.GetNextWayPoint(currentWayPoint);
                transform.LookAt(currentWayPoint);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
            {
                currentPreviousPoint = wayPoints.GetPreviousWayPoint(currentPreviousPoint);
                transform.LookAt(currentPreviousPoint);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stack"))
            Debug.Log("Hit");
    }
    #endregion

    //public GameObject lastHit;
    //private Vector3 collision = Vector3.zero;
    //public LayerMask layer;

    //private void Update()
    //{
    //    var ray = new Ray(transform.position, this.transform.forward);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, 100))
    //    {
    //        Debug.Log(this.transform.gameObject);
    //        lastHit = hit.transform.gameObject;
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(collision, 0.2f);
    //}
    //float CharacterSpeed = 2.0f;
    //private Transform wallDetection;
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

    //    //transform.Translate(Vector3.forward * CharacterSpeed * Time.deltaTime);
    //    //var up = transform.TransformDirection(new Vector3(0f, 1f, 1f));
    //    //RaycastHit hit;
    //    //Debug.DrawRay(transform.position, up, Color.green);

    //    //if (Physics.Raycast(transform.position, up, out hit, 2f))
    //    //{

    //    //    if (hit.collider.name == "Wall")
    //    //    {
    //    //        Debug.Log("HIT");
    //    //    }
    //    //}

    //}


}
