using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void BotaoJogar()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void BotaoSair()
    {
        Application.Quit();
    }
}
