using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{

}
/*{
    public float circleDistance;
    public float circleRadius;
    public float targetChange;
    public float[] targetSpace;
    public float angleChange;
    public float[] angleRange;
    public bool showVectors;
    private bool _startRandom;
    private float _rotationAngle = 20;
    private Seek _seek;


    // Start is called before the first frame update
    void Start()
    {
        _seek = GetComponent<Seek>();
        StartCoroutine("RandomAngle");
        StartCoroutine("RandomTarget");
    }
    public override Vector3 GetForce()
    {
        Vector3 circleCenter = velocity.normalized * circleDistance;
        Vector3 displacement = velocity.normalized * circleRadius;
        Quaternion rotation = Quaternion.AngleAxis(_rotationAngle, Vector3.up);
        displacement = rotation * displacement;

        Vector3 wanderForce = circleCenter + displacement;



        if (showVectors) DrawVectors(circleCenter, displacement);
        _seek.target = target;
        return _seek.GetForce() + wanderForce;
    }

    IEnumerator RandomTarget()
    {
        while (true)
        {
            target = new Vector3(Random.Range(-targetSpace[0], targetSpace[0]), 0, Random.Range(-targetSpace[1], targetSpace[1]));
            yield return new WaitForSeconds(targetChange);
        }
    }

    IEnumerator RandomAngle()
    {
        while (true)
        {
            _rotationAngle = Random.Range(angleRange[0], angleRange[1]);
            yield return new WaitForSeconds(angleChange);
        }
    }

    private void DrawVectors(Vector3 center, Vector3 displacement)
    {
        Debug.DrawLine(transform.position, transform.position + center, Color.green);
        Debug.DrawLine(transform.position + center, transform.position + center + displacement, Color.red);
        Debug.DrawLine(transform.position, transform.position + center + displacement, Color.blue);
    }
}*/