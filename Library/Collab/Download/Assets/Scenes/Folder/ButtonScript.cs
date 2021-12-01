using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    // タイトル画面→モード選択
    public void NewGame()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    // タイトルに戻る
    public void TitleBack()
    {
        SceneManager.LoadScene("Title");
    }

    // モード選択(Practice)→マップ選択
    public void Mode_Pra()
    {
        SceneManager.LoadScene("MapSelect_Pra");
    }

    // モード選択(Practice)→マップ選択(11-201)→選択確定
    public void Map_Pra_11()
    {
        SceneManager.LoadScene("Start_Pra_11");
    }

    // モード選択(Practice)→マップ選択(11-201)→選択確定→ゲーム画面
    public void GameStart_Pra_11()
    {
        SceneManager.LoadScene("DroneDemo");
    }



}
