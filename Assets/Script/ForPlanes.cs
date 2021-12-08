using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlanes : MonoBehaviour

{
    public float speed = 3;
    public float radius = 0.1f;
    private float runningTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime * speed;
        Vector3 moveDir = new Vector3(radius * Mathf.Cos(runningTime), 0.0f, radius * Mathf.Sin(runningTime));
        transform.Translate(moveDir);
    }
}
