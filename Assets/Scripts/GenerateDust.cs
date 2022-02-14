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

    float actualDust;

    // Start is called before the first frame update
    void Start()
    {
        dustNumberGameObject = this.gameObject;
        dustNumberText = dustNumberGameObject.GetComponent<Text>();

        dustPerSecondGameObject = GameObject.Find("DustPerSecond");
        dustPerSecondText = dustPerSecondGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        actualDust = actualDust + (float.Parse(dustPerSecondText.text) * Time.fixedDeltaTime) / 3600;
        dustNumberText.text = Mathf.Floor(actualDust).ToString();
    }

    public void Absorb(float massAbsorbed)
    {
        actualDust += Mathf.Pow(massAbsorbed,massAbsorbed) * 100;
    }
}
