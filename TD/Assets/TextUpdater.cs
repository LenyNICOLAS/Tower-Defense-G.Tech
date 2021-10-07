using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;



[RequireComponent(typeof(TextMeshProUGUI))]
public class TextUpdater : MonoBehaviour
{

    private TextMeshProUGUI TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        TextComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        Debug.Log("UpdateText");
    }



    public void btn_change_scene(string Niveau1)
    { 
        SceneManager.LoadScene(Niveau1); 
    
    }






}
