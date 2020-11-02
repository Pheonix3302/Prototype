using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtVolume : MonoBehaviour
{
    public int damage = 10;
    public float invulnerableTime = 0.5f;
    float timer = 0;
    bool canHurt = true;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvulnerableTimer();
    }
    public void OnTriggerStay(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
    }

    void InvulnerableTimer()
    {
        if (canHurt == false)
        {
            timer += Time.deltaTime;
            if (timer >= invulnerableTime)
            {
                timer = 0;
                canHurt = true;
            }
        }
    }
}
