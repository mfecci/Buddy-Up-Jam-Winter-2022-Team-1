using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{

    public int stardust;
    public Text text;
    private int augment = 1;

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
        text.text = stardust.ToString();
    }
}
