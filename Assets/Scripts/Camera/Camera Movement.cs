using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  [SerializeField] private float followSpeed = 2f;
  [SerializeField] private float xOffset = 1f;
  [SerializeField] private float yOffset = 1f;
  [SerializeField] private Transform target;
    private Transform _myTransform;

	// Start is called before the first frame update
	void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 newpos = new Vector2(target.position.x + xOffset,target.position.y + yOffset);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed*Time.deltaTime);
    }
}
