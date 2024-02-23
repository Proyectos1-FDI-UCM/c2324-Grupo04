using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private float zPos = -10f;
    [SerializeField] private float xOffset = 1f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Transform target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newpos = new Vector3(target.position.x + xOffset + xOffset, target.position.y + yOffset, zPos);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed * Time.deltaTime);
    }
}
