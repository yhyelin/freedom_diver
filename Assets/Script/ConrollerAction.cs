using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ConrollerAction : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean trigger;
    public GameObject player;

    private static bool is_pull=false;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetGrip())
        {
            if (!is_pull)
            {
                is_pull = true;
                player.GetComponent<PlayerController>().OnFire();
            }
        }
        else {

            is_pull = false;
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

        return trigger.GetState(handType);
    }
}
