using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOnClick : MonoBehaviour
{
    GameObject dustPerSecondUpgradeGameObject;
    Text dustPerSecondUpgradeText;
    float actualDust;

    float dustPerSecondUpgradeValue;

    GameObject dustNumberGameObject;
    Text dustNumberText;

    GameObject dustPerSecondGameObject;
    Text dustPerSecondText;

    // Start is called before the first frame update
    void Start()
    {
        dustPerSecondUpgradeGameObject = GameObject.Find("PassiveDustUpgradeDescriptive");
        dustPerSecondUpgradeText = dustPerSecondUpgradeGameObject.GetComponent<Text>();

        dustNumberGameObject = GameObject.Find("DustNumber");
        dustNumberText = dustNumberGameObject.GetComponent<Text>();

        dustPerSecondGameObject = GameObject.Find("DustPerSecond");
        dustPerSecondText = dustPerSecondGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DustUpgrade()
    {
        dustPerSecondUpgradeValue = float.Parse(dustPerSecondUpgradeText.text.Replace("+ ", "").Replace(" / Min",""));

        dustPerSecondText.text = (float.Parse(dustPerSecondText.text) + dustPerSecondUpgradeValue).ToString();
        dustPerSecondGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(dustPerSecondText.text.Length * 15, dustPerSecondGameObject.GetComponent<RectTransform>().sizeDelta.y);

        actualDust = actualDust - (float.Parse(dustNumberText.text)) ;
        dustNumberText.text = Mathf.Floor(actualDust).ToString();
        print(dustNumberText.text);
    }
}
