using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ConrollerAction : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grip;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetGrip()) {

            player.GetComponent<PlayerController>().OnFire();
        }
        if (handType == SteamVR_Input_Sources.LeftHand)
        {

            player.GetComponent<PlayerController>().left_con_pos = this.gameObject.transform.localPosition+this.transform.parent.localPosition;
        }
        else if (handType == SteamVR_Input_Sources.RightHand) {

            player.GetComponent<PlayerController>().right_con_pos = this.gameObject.transform.localPosition + this.transform.parent.localPosition;
        }
    }

    public bool GetGrip() {

        return grip.GetState(handType);
    }
}
