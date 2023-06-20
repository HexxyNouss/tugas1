using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  public int hp;
  public int hpMax;
  public int goldToGive;

  public Image hpImage;
  public Animation anim;

  public void Damage(){
      hp--;
      SetHPBar();


      anim.Stop();
      anim.Play();

      if (hp <= 0) Dead();
      
  }

  public void SetHPBar(){
      hpImage.fillAmount = (float)hp / (float)hpMax;
  }

  public void Dead(){
    GameManager.Instance.AddGold(goldToGive);
    EnemyManager.Instance.DestroyEnemy(gameObject);
  }
}
