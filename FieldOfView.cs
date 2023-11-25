using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    #region Data
    public float radius = 5f;
    [Range(0.1f, 360)] public float angle = 100f;
    public Vector3 offset = Vector3.up;

    [Space]

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    #endregion

    private void OnValidate()
    {
        if (radius <= 0.01f) radius = 0.01f;
    }

    /// <summary>
    /// Check in object in range.
    /// </summary>
    /// <typeparam name="T">Wanted type</typeparam>
    /// <param name="tag">Condition tag in object</param>
    /// <returns>List of wanted type in rage</returns>
    public List<T> Field<T>(string tag = null)
    {
        List<T> value = new List<T>();

        //Find all objects in range.
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position + offset, radius, targetMask);

        for (int i = 0; i < rangeChecks.Length; i++)
        {
            Transform target = rangeChecks[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (tag != null && target.tag != tag) continue;//Check for condition tag.

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                //Object in view angle.

                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    //No obstruction in direction.

                    T t;
                    target.TryGetComponent<T>(out t);

                    if (t != null)
                    {
                        //Object have a Wanted type.

                        value.Add(t);//Add the Wanted type to the lest.
                        Debug.DrawLine(transform.position, target.position, Color.green);
                    }
                }
            }
        }

        return value;//Send back the result.
    }
}