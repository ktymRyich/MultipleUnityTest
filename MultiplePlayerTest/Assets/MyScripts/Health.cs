using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int MaxHealth = 100;
    public int currentHealth;
    public RectTransform healthBar;
    //Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damege) {
        currentHealth -= damege;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}
