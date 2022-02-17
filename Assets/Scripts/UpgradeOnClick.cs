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
    float upgradeCost;
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

        upgradeCost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        actualDust = GenerateDust.actualDust;
    }

    public void DustUpgrade()
    {
        if (GenerateDust.actualDust< upgradeCost)
        {
            return;
        }
        dustPerSecondUpgradeValue = float.Parse(dustPerSecondUpgradeText.text.Replace("+ ", "").Replace(" / sec",""));
        dustPerSecondUpgradeValue = dustPerSecondUpgradeValue * 60;
        dustPerSecondText.text = (float.Parse(dustPerSecondText.text) + dustPerSecondUpgradeValue).ToString();
        dustPerSecondGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(dustPerSecondText.text.Length * 15, dustPerSecondGameObject.GetComponent<RectTransform>().sizeDelta.y);

        GenerateDust.actualDust = GenerateDust.actualDust - 10 ;
        dustNumberText.text = Mathf.Floor(actualDust).ToString();
        print(GenerateDust.actualDust);
    }

    public void SpawnRateUpgrade()
    {
        if (GenerateDust.actualDust < upgradeCost)
        {
            return;
        }
    }
}
