using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosFix : MonoBehaviour
{
    private GameObject camera;
    // Start is called before the first frame update
    void Awake()
    {
        for (int k = 0; k < this.gameObject.transform.childCount; k++) {

            GameObject go = this.gameObject.transform.GetChild(k).gameObject;

            if (go.name == "Camera") {

                camera = go;
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.localPosition = -camera.transform.localPosition;
    }
}
