 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawnObject;
    public float spawnTime = 1f;

    public GameObject Hp;
    public GameObject canvas ;
    
    
    private float timer = 0;
    void Start()
    {
        
    }

    public void Spawnhp ()
    {
        GameObject hp = GameObject.Instantiate(Hp, Vector3.zero, Quaternion.identity) as GameObject;
            hp.transform.SetParent(canvas.transform);
        

    }

    // Update is called once per frame
    void Update()
    {
       
        timer -= Time.deltaTime;
        
        if (timer <=0)
        {
            
            Instantiate(spawnObject, transform.position, transform.rotation);
            
            //   Spawnhp();
            //Instantiate(HP, Vector3.zero, Quaternion.identity) ;
            //HP.transform.SetParent(canvas.transform)
            
            timer = spawnTime;
        }
        
    }
}
