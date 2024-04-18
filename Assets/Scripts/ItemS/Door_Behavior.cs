using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Behavior : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Transform openTransform;
    [SerializeField] private Transform closedTransform;
    private Transform myTransform;
    private Transform targetTransform;

    public void Open()
    {
        targetTransform = openTransform;
    }

    public void Close()
    {
        targetTransform = closedTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        targetTransform = closedTransform.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTransform.position != targetTransform.position)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, targetTransform.position, speed * Time.deltaTime);
        }
    }
}
