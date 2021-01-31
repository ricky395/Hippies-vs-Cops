using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

    TextMesh text;
    [SerializeField] int totalMoney = 20;
    float repeatTime = 1.5f;
    int moneyToSum = 1;
    float count = 0;
    
    void Start () {

        text = GameObject.Find("FlowerPoints").GetComponent<TextMesh>();
	}
	
    void Update()
    {
        count += Time.deltaTime;
        if (count >= repeatTime)
        {
            UpdateMoney();
            count = 0;
        }
    }

    void UpdateMoney()
    {
        totalMoney += moneyToSum;
        UpdateText();
    }

    public void OddMoney(int quantity)
    {
        totalMoney -= quantity;
        UpdateText();
    }

    public int GetTotalMoney()
    {
        return totalMoney;
    }

    void UpdateText()
    {
        text.text = totalMoney.ToString();
    }
}
