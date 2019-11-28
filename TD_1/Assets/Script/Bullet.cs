using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0.5f;
    public float TimeLife = 1f;
    public Enemy Enemy;
    public float Damage = 25f;

    float timerLife = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timerLife = TimeLife;
    }

    // Update is called once per frame
    void Update()
    {
        timerLife -= Time.deltaTime;
       
        float _speed = Speed * Time.deltaTime;


        if (timerLife <= 0)
        {
            //Время жизни пули
            timerLife = TimeLife;
            Destroy(gameObject);
        }
        else if (Enemy != null && Vector3.Distance(transform.position, Enemy.transform.position) <= _speed)
        {
            //Попадание пули
            Enemy.SetDamage(Damage);
            Destroy(gameObject);
            return;

        }
        
        
        transform.Translate(new Vector3(0, 0, _speed));
    }
}
