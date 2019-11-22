using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoving : MonoBehaviour
{
    public float speed = Random.Range(1f, 5f);
    public float rotateSpeed = Random.Range(1f, 5f);
    public float X1position = Random.Range(-15f, 45f);
    public float X2position = Random.Range(-15f, 45f);
    public float Y1position = Random.Range(-15f, 45f);
    public float Y2position = Random.Range(-15f, 45f);

    Vector3 newPosition;


    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(X1position, X2position), Random.Range(Y1position, Y2position));
    }
    void Update()
    {
        X1position = Random.Range(-5f, 50f);
        X2position = Random.Range(-5f, 50f);
        Y1position = Random.Range(-15f, 20f);
        Y2position = Random.Range(-15f, 20f);

        if (Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

        LookAt2D(newPosition);
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
}
