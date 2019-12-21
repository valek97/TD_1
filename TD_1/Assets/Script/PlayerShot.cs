using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float FindRadius = 2f;
    public float TimeShoot = 1f;
    public GameObject bullet2;

    Enemy enemy;
    Transform towerHead;
    float timerShoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        towerHead = transform.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            //Поиск противника 
            FindEnemy();
        }
        else
        {
            // Поворот пушки в сторону противника и стрельба
            towerHead.LookAt(enemy.transform);
            //Производим выстрел
            Shoot();
            float dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist > FindRadius)
                enemy = null;
        }


    }

    // Выстрел
    private void Shoot()
    {
        timerShoot -= Time.deltaTime;
        if (timerShoot <= 0)
        {
            timerShoot = TimeShoot;
            //Создание пули
            GameObject obj = (GameObject)Instantiate(bullet2, towerHead.transform.position, towerHead.transform.rotation);
            BulletPlayer b = obj.GetComponent<BulletPlayer>();
            b.Enemy = enemy;
        }
    }
    private void FindEnemy()
    {
        var enemies = GameObject.FindObjectsOfType<Enemy>();


        float min = FindRadius;
        Enemy minEnemy = null;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);

            if (dist <= min)
            {
                min = dist;
                minEnemy = e;
            }
        }
        enemy = minEnemy;
    }
}
