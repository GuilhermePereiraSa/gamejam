using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    
    [SerializeField] private string nomeDaCena1;
    [SerializeField] private string nomeDaCena2;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
   public void JogarVerde()
    {
        SceneManager.LoadScene("MagoVerde");
    }

    public void JogarRoxo()
    {
        SceneManager.LoadScene("MagoRoxo");
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }


}
