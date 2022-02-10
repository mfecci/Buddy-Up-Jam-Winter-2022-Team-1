using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public GameObject dust;
    public int stardust;
    public Text text;
    public int augment = 1;
    public float spawnrate = 1;
    private Vector2 screenBounds;
    public float Timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseStardust()
    {
        stardust += augment;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        text.text = stardust.ToString();
        if (Timer <= 0f)
        {
            spawn();
            Timer = spawnrate;
        }
    }

    private void spawn()
    {
        GameObject a = Instantiate(dust) as GameObject;



        float posy = Random.Range(-3, 3);
        float posx = Random.Range(-5, 5);
        a.transform.position = new Vector2(posx, posy);
    }
}
