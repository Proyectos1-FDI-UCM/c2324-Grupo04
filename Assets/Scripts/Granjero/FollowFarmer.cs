using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFarmer : MonoBehaviour
{
    [SerializeField] private Transform farmer;
    private Transform _mytransform;
    private float x;
    private float y = 10;
    private float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
    x = farmer.position.x;
    _mytransform.position = new Vector3 (x,y,z);
    }
}
