using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForText : MonoBehaviour
{

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
        rt.localPosition = new Vector3(-Screen.width / 20, -Screen.height / 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
