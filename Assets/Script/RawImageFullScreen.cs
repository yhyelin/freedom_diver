using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawImageFullScreen : MonoBehaviour
{
    private RectTransform rt;

    private void Awake()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
