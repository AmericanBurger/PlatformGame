using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkryptMENU : MonoBehaviour {

	public void Exit()
    {
        Application.Quit();
    }

    public void newGame()
    {
        SceneManager.LoadScene("Glowna");
    }
}
