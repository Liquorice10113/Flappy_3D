using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_util : MonoBehaviour
{
    public static AudioManager Am = new AudioManager();
    public static bool game_over = false;
    public static bool game_started = false;
    public static int score = 0;
    public static Queue<GameObject> pipeInScene = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GameOver()
    {
        game_util.game_over = true;
        GameObject.FindGameObjectWithTag("gameover").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.FindGameObjectWithTag("gameover").GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public static void CreateNewPipe(float x)
    {
        Debug.Log("Creating new pipe...");
        GameObject prefab = Instantiate(Resources.Load("Prefabs/pipes") ) as GameObject;
        prefab.GetComponent<Transform>().position = new Vector3(x,2,0);
        pipeInScene.Enqueue(prefab);
        Debug.Log(pipeInScene);
    }

    public static void ResetAll()
    {
        while(pipeInScene.Count>0)
        {
            GameObject.Destroy(pipeInScene.Dequeue());
        }
        ResetBird();
        CreatePipesAtFirst();
        score = 0;
        game_over = false;
        
    }

    public static void ResetBird()
    {
        GameObject.FindGameObjectWithTag("bird").GetComponent<Transform>().position = new Vector3(-2, 3, 0);
        GameObject.FindGameObjectWithTag("bird").GetComponent<Transform>().localEulerAngles = new Vector3(-90, 180, 0);
        GameObject.FindGameObjectWithTag("bird").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("bird").GetComponent<Rigidbody>().isKinematic = false;
    }

    public static void CreatePipesAtFirst()
    {
        for (int i = 5; i <= 17; i += 3)
        {
            CreateNewPipe(i);
        }
    }

}
