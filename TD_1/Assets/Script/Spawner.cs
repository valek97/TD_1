 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawnObject;
    public float spawnTime = 20f; 
    public float EnemyInterval; //Промежуток между мобами
    public int WaveSize;// Размер волны
    public int enemyUnits;  
    public float startTime; //Начало атаки

    public GameObject Hp;
    public GameObject canvas ;
    
    
   // private float timer = 0;

    int enemyCount = 0;
    
    void Start()
    {
        InvokeRepeating("SpawnEnmy", startTime, EnemyInterval);
    }

    public void Spawnhp ()
    {
        GameObject hp = GameObject.Instantiate(Hp, Vector3.zero, Quaternion.identity) as GameObject;
            hp.transform.SetParent(canvas.transform);
        

    }

    // Update is called once per frame
    void Update()
    {
       
        if (enemyCount == WaveSize)
        {
            enemyCount = 0;
            CancelInvoke("SpawnEnmy");
            spawnTime = 60f;
            
        }
        
        if (spawnTime <= 0 & enemyCount == 0)
        {
            InvokeRepeating("SpawnEnmy", startTime, EnemyInterval);
        }
        Timer();
       
        
    }
    void Timer ()
    {
        spawnTime -= Time.deltaTime;
        
    }

    void SpawnEnmy()
    {
       // timer -= Time.deltaTime;


        
        
            enemyCount++;
            Instantiate(spawnObject, transform.position, transform.rotation);

            //   Spawnhp();
            //Instantiate(HP, Vector3.zero, Quaternion.identity) ;
            //HP.transform.SetParent(canvas.transform)

            //timer = spawnTime;
        
    }
}
