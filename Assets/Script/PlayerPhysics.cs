using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPhysics : MonoBehaviour
{

    private Vector2 m_Move;
    private bool is_parachute;
    private Rigidbody rb;
    
    
    public float force=5f;
    public float rotate_force = 30f;
    public GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        is_parachute = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        m_Move = value.Get<Vector2>();

    }

    public void OnEscape() {

        EventSystem.GetComponent<EventSystem>().Over();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * force * m_Move.y);

        if (is_parachute)
        {
            rb.AddForce(0, -rb.velocity.y, 0);
        }
        else {
            rb.AddForce(0, -rb.velocity.y*0.1f, 0);
        }


        if (m_Move.x < 0)
        {
            transform.Rotate(0, -rotate_force*Time.deltaTime, 0);
        }
        if(m_Move.x>0) {

            transform.Rotate(0, rotate_force * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Clear")) {

            EventSystem.GetComponent<EventSystem>().Clear();
        }
        if (collision.gameObject.CompareTag("Parachute")) {

            is_parachute = true;
            collision.gameObject.active = false;
        }
    }

}
