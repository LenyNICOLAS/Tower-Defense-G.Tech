using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // bouton de changement de scene
    public void btn_change_scene(string scene_name)
    { 
        GameManager.Instance.ResetLevel();
        SceneManager.LoadScene(scene_name);
    }
}
