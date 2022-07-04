using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    #region test
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }
    public Transform GetNextWayPoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
    public Transform GetPreviousWayPoint(Transform previousWaypoint)
    {
        if (previousWaypoint == null)
        {
            return transform.GetChild(0);
        }
        if (previousWaypoint.GetSiblingIndex() < transform.childCount + 1)
        {
            return transform.GetChild(previousWaypoint.GetSiblingIndex() - 1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }

    #endregion


}
