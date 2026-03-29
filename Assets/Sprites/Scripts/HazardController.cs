using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public int damage = 1;
    public float timeToDamage = 1f;


    // fazer um map de <quem pisa, quanto tempo pisa>
    private Dictionary<Collider2D, float> timers = new Dictionary<Collider2D, float>();
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health healthTarget = collision.gameObject.GetComponent<Health>();

        if (healthTarget)
        {

            // Adicionar no cronometro 
            timers[collision] = 0f;
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {

        // objeto que esta aqui dentro, ja esta na lista de contagem, entao...
        if (timers.ContainsKey(collision))
        {
            timers[collision] += Time.fixedDeltaTime;
        }


        if(timers[collision] >= timeToDamage)
        {
            collision.GetComponent<Health>().TakeDamage(damage);


            timers[collision] = 0f;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if(timers.ContainsKey(collision))
            timers.Remove(collision);
    }
}
