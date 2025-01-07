using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOPanelController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(this);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(this);
    }
}
