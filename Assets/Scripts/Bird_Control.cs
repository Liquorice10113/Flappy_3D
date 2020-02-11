using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Control : MonoBehaviour
{
    private Transform trans;
    private int clickInterval = 0;
    private float bobForce = 0.001f;
    private int bobInterval = 270;

    public AudioClip sfx_wing ;
    public AudioClip sfx_hit;
    private AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        m_AudioSource = GetComponent<AudioSource>();

        sfx_wing = Resources.Load<AudioClip>("Sounds/sfx_wing");
        sfx_hit = Resources.Load<AudioClip>("Sounds/sfx_hit");
        //game_util.ResetAll();
        //jump();
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_util.game_started)
        {
            trans.position += new Vector3(0, bobForce, 0);
            bobInterval--;
            if(bobInterval==0)
            {
                bobInterval = 270;
                bobForce = -bobForce;
            }
            return;
        }
        float gravity = -600;
        gameObject.GetComponent<Rigidbody>().AddForce(0, gravity * Time.deltaTime, 0);
        if (Input.GetMouseButtonDown(0)&& clickInterval>10)
        {
            jump();
            Debug.Log(Input.mousePosition);
            clickInterval = 0;
        }
        clickInterval += 1;
    }

    public void ResetBird()
    {
        trans.position = new Vector3(-2,3,0);
        trans.localEulerAngles = new Vector3(-90,180,0);//rotation
    }

    private void OnCollisionEnter(Collision collision)
    {
        game_util.GameOver();
        m_AudioSource.clip = sfx_hit;
        m_AudioSource.Play();

        Debug.Log("You Dead!");
    }
    private void jump()
    {
        if (game_util.game_over) return;

        m_AudioSource.clip = sfx_wing;
        m_AudioSource.Play();

        float upforce = 200;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(0, upforce, 0);
    }

}
