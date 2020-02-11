using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texture_move : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_offset = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_util.game_over) return;
        m_offset += Time.deltaTime * 0.5f;
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-m_offset, 0);
    }
}
