using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerCollider(Collider collider)
    { if (collider.gameObject.tag == "Player")
        {
            print("Item picked up");
                Destroy(gameObject); }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
