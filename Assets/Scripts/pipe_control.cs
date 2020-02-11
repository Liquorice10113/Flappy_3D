using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_control : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform trans;
    private bool score_counted = false;

    private AudioClip sfx_point;

    void Start()
    {
        float min_h = -1.7f;
        float max_h = 2.7f;
        trans = GetComponent<Transform>();
        trans.position += new Vector3(0, Random.Range(min_h, max_h), 0);

        sfx_point = Resources.Load<AudioClip>("Sounds/sfx_point");
    }

    // Update is called once per frame
    void Update()
    {
        if(game_util.game_over) return;
        trans.position += new Vector3(-2*Time.deltaTime,0,0);
        if(trans.position[0]<-2.5)
        {
            if(score_counted==false)
            {
                score_counted = true;
                game_util.score += 1;
                GetComponent<AudioSource>().clip = sfx_point;
                GetComponent<AudioSource>().Play();
            }
        }
        if(trans.position[0] <= -7)
        {
            game_util.CreateNewPipe(8);
            game_util.pipeInScene.Dequeue();
            GameObject.Destroy(gameObject);
        };
    }
}
