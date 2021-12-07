using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public RawImage[] Ri_clear, Ri_fail;
    public Text[] text;
    private bool is_clear;
    private bool is_fail;
    private int score;

    private AudioSource audio;

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

    public void Fail()
    {
        if(!is_clear)   is_fail = true;
    }

    public void Point(int point=100) {

        score += point;
    }

    // Start is called before the first frame update
    void Awake()
    {
        is_clear = false;
        is_fail = false;
        for (int t = 0; t < Ri_clear.Length; t++)   Ri_clear[t].color = new Color(1f,1f,1f,0);
        for (int t = 0; t < Ri_fail.Length; t++)    Ri_fail[t].color = new Color(1f, 1f, 1f, 0);
        audio = gameObject.GetComponent<AudioSource>();
        score = 0;
    }

    private void Update()
    {
        for (int t = 0; t < text.Length; t++)  text[t].text="Score:"+score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_clear) {

            for (int t = 0; t < Ri_clear.Length; t++) {
                if (Ri_clear[t].color.a < 1)
                {

                    Ri_clear[t].color += new Color(0, 0, 0, 1 * Time.deltaTime);
                }
            }
            
        }

        if (is_fail)
        {
            for (int t = 0; t < Ri_fail.Length; t++) {
                if (Ri_fail[t].color.a < 1)
                {

                    Ri_fail[t].color += new Color(0, 0, 0, 1 * Time.deltaTime);
                }

            }
                
        }

    }
}
