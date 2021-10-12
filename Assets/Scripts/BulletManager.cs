using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float BulletDmg = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        TankManager CheckTank = col.GetComponent<TankManager>();
        if (CheckTank != null) 
        {
            CheckTank.CurrentHP -= BulletDmg;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
