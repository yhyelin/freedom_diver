using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlanes : MonoBehaviour

{
    public float speed;
    public float radius;
    public float start_rotation = 0;
    private float runningTime = 0;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.localPosition;
        runningTime = Mathf.Deg2Rad * start_rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        runningTime += Time.deltaTime * speed;
        Vector3 moveDir = new Vector3(radius * Mathf.Cos(runningTime), 0.0f, radius * Mathf.Sin(runningTime))+ origin;
        Vector3 rot = new Vector3(0, -Mathf.Rad2Deg * runningTime+90, 0);
        transform.localPosition=moveDir;
        //transform.Translate(moveDir);
        transform.rotation = Quaternion.Euler(rot);
    }
}
