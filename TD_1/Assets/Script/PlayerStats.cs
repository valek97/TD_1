using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Energy = 200;
   
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("EnReg"))
        {
            EnergyRegen regenEn = col.GetComponent<EnergyRegen>();
            Energy = regenEn.EnReg;
            
        }
    }

    
}
