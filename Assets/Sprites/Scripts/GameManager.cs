using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject magoAtiradorAtual;
    public GameObject magoEscudeiroAtual;


    void Start()
    {
        UpdateAbilities();
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void RoundDone(GameObject magoMorto)
    {
        Health healthMagoMorto = magoMorto.GetComponent<Health>();


        // Mago que foi morto é revivido e entra em invencibilidade
        if(healthMagoMorto)
            healthMagoMorto.ReviveInvincible();

        
        if(magoMorto == magoAtiradorAtual)
        {
            InvertRoleMage();
        }
        else
        {
            Debug.Log("FIM DE JOGO!");
        }
    }


    public void InvertRoleMage()
    {

        Debug.Log("TROCA DE ROLES!");
        // fazer uma apresentaçãozinha?

        GameObject temp = magoAtiradorAtual;
        magoAtiradorAtual = magoEscudeiroAtual;
        magoEscudeiroAtual = temp;

        UpdateAbilities();
    }


    void UpdateAbilities()
    {
        if (magoAtiradorAtual)
        {
            magoAtiradorAtual.GetComponent<ShooterRole>().enabled = true;

            magoAtiradorAtual.GetComponent<ShieldRole>().enabled = false;
            magoAtiradorAtual.GetComponent<ShieldRole>().DeactivateShield();
        }


        if (magoEscudeiroAtual)
        {
            magoEscudeiroAtual.GetComponent<ShooterRole>().enabled = false;
            magoEscudeiroAtual.GetComponent<ShieldRole>().enabled = true;
        }
        
    }
}
