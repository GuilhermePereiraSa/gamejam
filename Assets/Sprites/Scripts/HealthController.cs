using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 3;
    private int currentHealth;

    public bool isInvincible = false;

    public float invincibilityTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }


    public void TakeDamage(int damageAmount)
    {
        if (isInvincible)
        {
            Debug.Log(gameObject.name + " bloqueou o dano! INVENCÍVEL!");
            return;
        }

        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        if(GameManager.Instance)
            GameManager.Instance.RoundDone(gameObject);

        ReviveInvincible();
    }


    public void ReviveInvincible()
    {
        currentHealth = maxHealth;
        StartCoroutine("GetInvencible");

    }

    IEnumerator GetInvencible()
    {
        isInvincible = true;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        int blinks = 5;

        float blinkSpeed = (invincibilityTime / blinks) / 2f;

        for (int i = 0; i < blinks; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, 0.5f);

            yield return new WaitForSeconds(blinkSpeed);

            sprite.color = Color.white;

            yield return new WaitForSeconds(blinkSpeed);
        }
        

        isInvincible = false;
    }
}
