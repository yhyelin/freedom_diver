using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector2 m_Move;
    private bool is_parachute;
    private Rigidbody rb;
    private AudioSource ParaAudio;
    private AudioSource WindAudio;
    private AudioSource RipAudio;
    private AudioSource ItemAudio;
    private int para_num = 0;
    private bool is_invincible; // 절대무적
    private float hori_resist = 0.3f;
    private EventSystem es;
    private float bug_fail_timer;

    public Vector2 left_con_pos;
    public Vector2 right_con_pos;

    public float force=1f;
    public float rotate_force = 1f;
    public GameObject ev;
    public GameObject ParaEffect;
    public GameObject WindEffect;
    public GameObject RipEffect;
    public GameObject ItemEffect;
    // Start is called before the first frame update
    void Start()
    {
        is_parachute = false;
        is_invincible = false;
        rb = gameObject.GetComponent<Rigidbody>();
        ParaAudio = ParaEffect.GetComponent<AudioSource>();
        WindAudio = WindEffect.GetComponent<AudioSource>();
        RipAudio = RipEffect.GetComponent<AudioSource>();
        ItemAudio = ItemEffect.GetComponent<AudioSource>();
        es = ev.GetComponent<EventSystem>();
        WindAudio.Play();
        bug_fail_timer = 0;
    }

    public void OnMove(InputValue value)
    {

        m_Move = value.Get<Vector2>();

    }

    public void OnFire()
    {
        Debug.Log("fire");
        if (para_num > 0 && !(is_parachute))
        {

            para_num--;
            is_parachute = true;
            ParaAudio.Play();
            Debug.Log("para open");
        }
        else if (is_parachute) {

            is_parachute = false;
            RipAudio.Play();
        }
    }

    public void OnEscape()
    {
        es.Over();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        WindAudio.volume = (Mathf.Abs(rb.velocity.y)+10) / 70;
        if (left_con_pos != new Vector2(0, 0) || right_con_pos != new Vector2(0, 0)) {

            m_Move = left_con_pos + right_con_pos;

        }


        rb.AddForce(transform.forward * force * m_Move.y-new Vector3(rb.velocity.x, 0,rb.velocity.z)* hori_resist);

        



        if (is_parachute)
        {
            rb.AddForce(0, -rb.velocity.y, 0);
        }
        else {
            rb.AddForce(0, -rb.velocity.y*0.1f, 0);
        }



        transform.Rotate(new Vector3(0, 1f* m_Move.x, 0));
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, m_Move.x * rotate_force * Time.deltaTime, 0) );


        //버그방지
        if (transform.position.y < 4f) {
            bug_fail_timer += Time.deltaTime;
            if (transform.position.y < 2f)
            {
                es.Fail();
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            }

            if (bug_fail_timer > 3f) {

                es.Fail();
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Parachute"))
        {
            para_num++;
            es.Point(100);
            ItemAudio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Point"))
        {
            es.Point(200);
            ItemAudio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Invincible"))
        {
            es.Point(100);
            is_invincible = true;
            ItemAudio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            if (!is_invincible)
            {
                es.Fail(); // not clear not over but fail
            }
            else
            {
                is_invincible = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Clear")&& is_parachute)
        {

            es.Clear();

        }
        else
        {

            es.Fail();
        }
    }

}
