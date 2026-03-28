using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject magoAtiradorAtual;
    public GameObject magoEscudeiroAtual;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Destroy(gameObject);
    }

    public void RoundDone(GameObject magoMorto)
    {
        Health healthMagoMorto = magoMorto.GetComponent<Health>();


        // Mago que foi morto é revivido e entra em invencibilidade
        if(healthMagoMorto)
            healthMagoMorto.ReviveInvincible();

        
        InvertRoleMage();
    }


    public void InvertRoleMage()
    {
        // 
    }
}
