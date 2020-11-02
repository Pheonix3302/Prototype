using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    private int currentHealth;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        isDead = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDeath()
    {
        Debug.Log("You is dies");
        isDead = true;
        gameObject.SetActive(false);
    }

    public void Damage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;

        if (currentHealth <=0)
        {
            OnDeath();
        }
    }

    public void AutoKill()
    {
        if (!isDead)
            OnDeath();
    }
}
