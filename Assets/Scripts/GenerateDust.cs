using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateDust : MonoBehaviour
{
    GameObject dustNumberGameObject;
    Text dustNumberText;

    GameObject dustPerSecondGameObject;
    Text dustPerSecondText;
    GameObject generatedDustPerSecondGameObject;
    Text generatedDustPerSecondText;
    public GameObject dustParticle;
    float dustPerSecond;
    public static float actualDust;
    public static float Timer = 2;
    public static float absortionValue;


    // Start is called before the first frame update
    void Start()
    {
        dustNumberGameObject = this.gameObject;
        dustNumberText = dustNumberGameObject.GetComponent<Text>();

        dustPerSecondGameObject = GameObject.Find("DustPerSecond");
        dustPerSecondText = dustPerSecondGameObject.GetComponent<Text>();

        generatedDustPerSecondGameObject = GameObject.Find("generatedDustPerSecond");
        generatedDustPerSecondText = generatedDustPerSecondGameObject.GetComponent<Text>();
        absortionValue = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        actualDust = actualDust + (float.Parse(dustPerSecondText.text) * Time.fixedDeltaTime) / 3600;
        print(actualDust);
        dustNumberText.text = Mathf.Floor(actualDust).ToString();
        Timer -= Time.deltaTime;
        dustPerSecond = float.Parse(generatedDustPerSecondText.text);

        if (Timer <= 0f)
        {
            spawnDust();
            Timer = dustPerSecond;
        }
    }

    public void spawnDust()
    {
        float maxX = 5, maxY = 5;
        float posX = 0, posY = 0;
        while (posX > -2 && posX < 2 || posY > -2 && posY < 2)
        {
            posX = Random.Range(-maxX, maxX);
            posY = Random.Range(-maxY, maxY);
        }


        Vector2 pos;
        pos = new Vector2(posX, posY);
        Instantiate(dustParticle, pos, transform.rotation);
    }

    public void Absorb(float massAbsorbed)
    {
        actualDust += Mathf.Pow(massAbsorbed,massAbsorbed) * absortionValue;
    }
}
