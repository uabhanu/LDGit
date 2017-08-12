using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("QuitButton Pressed");
    }

    public void LoadScene(string name)
    {
        Debug.Log("StartButton Pressed");
        SceneManager.LoadScene(name);
    }
}
