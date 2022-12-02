using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void onStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void onQuit()
    {
        Application.Quit();
    }
    public void onBack()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
