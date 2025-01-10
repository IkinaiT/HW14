using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{
    public void OnClickMenu() => SceneManager.LoadScene(0);
}
