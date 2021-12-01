using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mode_PraScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MapSelect_Pra");
    }

}
