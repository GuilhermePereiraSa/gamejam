using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ShieldRole : MonoBehaviour
{

    public GameObject eixoEscudos;
    public float velocidadeGiro = 250f;
    public float duracaoEscudo = 3f;
    public float coolDownTempo = 4f;

    private bool escudoAtivo = false;
    private float proximoUso = 0f;


    void Start()
    {
        if (eixoEscudos)
            eixoEscudos.SetActive(false);
    }


    void Update()
    {
        if(escudoAtivo && eixoEscudos)
        {
            eixoEscudos.transform.Rotate(0, 0, velocidadeGiro * Time.deltaTime);
        }
    }

    public void TryActivateShield(Vector3 mousePos)
    {
        if(!escudoAtivo && Time.time >= proximoUso)
        {
            StartCoroutine(ShieldRoutine());
        }
    }



    public void DeactivateShield()
    {
        escudoAtivo = false;
    }

    private IEnumerator ShieldRoutine()
    {
        escudoAtivo = true;
        eixoEscudos.SetActive(true);


        yield return new WaitForSeconds(duracaoEscudo);

        DeactivateShield();
        eixoEscudos.SetActive(false);


        proximoUso = Time.time + coolDownTempo;
    }


    public void AimShield(Vector3 mousePos)
    {
    }

}
