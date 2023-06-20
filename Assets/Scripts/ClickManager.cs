using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI autoClickerText;


   public List<float> lastTimeClicked = new List<float>(); 
   public int price;

    // Update is called once per frame
    void Update()
    {
        for (int _i =0; _i < lastTimeClicked.Count; _i++){
            if (Time.time - lastTimeClicked[_i] >= 1f){
                EnemyManager.Instance.enemy.Damage();

                lastTimeClicked[_i] = Time.time;
            }
        }
    }

    public void BuyAutoClicker(){
        if (GameManager.Instance.gold >= price){
            lastTimeClicked.Add(Time.time);
            autoClickerText.text = "x " + lastTimeClicked.Count;
            GameManager.Instance.TakeGold(price);
        }
    }
}
