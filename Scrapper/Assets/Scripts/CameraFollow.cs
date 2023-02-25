using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public float yOffset = 0f;
    public float xOffset = 0f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPow = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPow, FollowSpeed * Time.deltaTime);
    }
}