using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFarmer : MonoBehaviour
{
    [SerializeField] private Transform farmer;
    private Transform _transform;
    private float y = 10;
    private float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
    float x = farmer.position.x;
    _transform.position = new Vector3 (x,y,z);
    }
}
