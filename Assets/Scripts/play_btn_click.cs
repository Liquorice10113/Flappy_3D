using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_btn_click : MonoBehaviour
{

    private AudioClip sfx_swooshing;
    // Start is called before the first frame update
    void Start()
    {
        sfx_swooshing = Resources.Load<AudioClip>("Sounds/sfx_swooshing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        game_util.ResetAll();
        game_util.game_started = true;

        GetComponent<AudioSource>().clip = sfx_swooshing;
        GetComponent<AudioSource>().Play();

        GameObject.FindGameObjectWithTag("gameover").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindGameObjectWithTag("gameover").GetComponent<CanvasGroup>().blocksRaycasts = false;

        GameObject.FindGameObjectWithTag("score").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.FindGameObjectWithTag("score").GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject.FindGameObjectWithTag("mainmenu").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.FindGameObjectWithTag("mainmenu").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.FindGameObjectsWithTag("w3d")[0].GetComponent<MeshRenderer>().enabled = false;
        GameObject.FindGameObjectsWithTag("w3d")[1].GetComponent<MeshRenderer>().enabled = false;
    }
}
