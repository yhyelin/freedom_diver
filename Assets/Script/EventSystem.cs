using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public RawImage ri;
    private bool is_clear;

    public void Clear() {

        is_clear = true;
    }

    public void Over()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Start is called before the first frame update
    void Awake()
    {
        is_clear = false;
        ri.color = new Color(1f,1f,1f,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_clear) {

            if (ri.color.a < 1) {

                ri.color += new Color(0, 0, 0, 1 * Time.deltaTime);
            }
        }

    }
}
