using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Sprite[] backgrounds;
    public Transform canvas;
    public Image background;
    public Enemy enemy;

    public static EnemyManager Instance;

    public int enemyLeft = 2;

    public int currentEnemy;
    public int currentBg;

    public void Awake(){
        Instance = this;
    }

    public void SpawnEnemy() {
        int _randomEnemy = currentEnemy;

        while (_randomEnemy == currentEnemy)
        {
            _randomEnemy = Random.Range(0, enemyPrefabs.Length);
        }
        Debug.Log("spawn");
        currentEnemy = _randomEnemy;

        GameObject _enemy = Instantiate(enemyPrefabs[currentEnemy], canvas);
        enemy = _enemy.GetComponent<Enemy>();
    }

    public void DestroyEnemy(GameObject _enemy){
        Destroy(_enemy);
        SpawnEnemy();
        CheckBackground();
    }


    void CheckBackground(){
       enemyLeft--;
       if (enemyLeft == 0){
            enemyLeft = 2;
            currentBg++;
            if (currentBg >= backgrounds.Length) currentBg = 0;

            background.sprite = backgrounds[currentBg];
       }
    }
}
