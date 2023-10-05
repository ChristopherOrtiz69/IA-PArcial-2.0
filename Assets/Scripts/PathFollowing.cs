using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : Steering
{
    public List<Vector3> nodes;
    public float pathRadius;
    public bool looping;
    public float arrivalRadius = 1.0f;
    private int _currentNode = 0;
    private int _pathDirection = 1;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public override Vector3 GetForce()
    {

        if (nodes.Count == 0)
        {
            return Vector3.zero;
        }

        Vector3 targetPosition = nodes[_currentNode];
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;


        if (Vector3.Distance(transform.position, nodes[_currentNode]) < pathRadius)
        {

            if (looping && _currentNode == nodes.Count - 1)
            {
                _currentNode = 0;
            }
            if (distance <= arrivalRadius)
            {
                _currentNode = (_currentNode + 1) % nodes.Count;
            }
            else
            {
                _currentNode += _pathDirection;
                if (!looping && (_currentNode == 0 || _currentNode == nodes.Count - 1))
                {
                    return Vector3.zero;
                }
            }
        }
        float desiredSpeed = speed;
        if (distance <= arrivalRadius)
        {
            desiredSpeed *= distance / arrivalRadius;
        }

        Vector3 desiredVelocity = direction.normalized * desiredSpeed;
        Vector3 acceleration = (desiredVelocity - GetComponent<Rigidbody>().velocity);

        GetComponent<Rigidbody>().AddForce(acceleration, ForceMode.Force);

        return desiredVelocity - rb.velocity;

    }
}