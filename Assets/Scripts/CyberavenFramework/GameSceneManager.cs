using UnityEngine;
using System.Collections;
//using UnityEditorInternal;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        GameStateMashine.GameStateChangedEve += GameStateChanged;
    }

    private void GameStateChanged(EStateMashine state)
    {
        if(state == EStateMashine.StarMapScene)
        {
            Debug.Log("Scene StarMapScene load.");
            SceneManager.LoadScene("StarMapScene");
        }
        if (state == EStateMashine.StarSystemMapScene)
        {
            Debug.Log("Scene StarSystemMapScene load.");
            SceneManager.LoadScene("StarSystemMapScene");
        }
        if(state == EStateMashine.PlanetMapScene)
        {
            Debug.Log("Scene PlanetMapScene load.");
            SceneManager.LoadScene("PlanetMapScene");
        }
    }
}
