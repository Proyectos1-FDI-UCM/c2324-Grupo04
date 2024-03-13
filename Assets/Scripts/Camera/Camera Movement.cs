using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  [SerializeField] private float followSpeed = 2f;
  [SerializeField] private float xOffset = 4f;
  [SerializeField] private float yOffset = 1f;
  [SerializeField] private Transform target;
  private float yOffsetStartx1 = 73f;
	private float yOffsetStarty1 = -3.5f;
	private float yOffsetEnd1 = 93f;
	private float zPos = -10f;
  private float Camerax1=83.4f;
	private float Cameray1 = -9f;


	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.x>yOffsetStartx1 && target.position.y<yOffsetStarty1 && target.position.x<yOffsetEnd1)
        {
			    Vector3 newpos = new Vector3(Camerax1,Cameray1, zPos);
			    transform.position = Vector3.Slerp(transform.position, newpos, followSpeed * Time.deltaTime);
		    }
        else
        {
			    Vector3 newpos = new Vector3(target.position.x + xOffset, yOffset, zPos);
			    transform.position = Vector3.Slerp(transform.position, newpos, followSpeed * Time.deltaTime);
		    }
        
    
    }
}
