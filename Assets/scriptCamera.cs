using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptCamera : MonoBehaviour
{
    public GameObject pc;
    public float offset_y = 2;
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicao = new Vector3(pc.transform.position.x, pc.transform.position.y + offset_y, -10);
        this.transform.position = posicao;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                pausado = false;
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {

                pausado = true;
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
                
        }
    }
}
