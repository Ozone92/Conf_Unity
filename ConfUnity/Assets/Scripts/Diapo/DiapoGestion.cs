using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;


public class DiapoGestion : MonoBehaviour
{
    private GameObject canvas;
    private int cur_diapo = 0;
    [SerializeField] int max_diapo;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("GameController").Length != 1)
            Destroy(gameObject);
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (cur_diapo < max_diapo - 1)
            {
                cur_diapo += 1;
                SceneManager.LoadScene(cur_diapo);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (cur_diapo != 0)
            {
                cur_diapo -= 1;
                SceneManager.LoadScene(cur_diapo);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
        else if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene(cur_diapo);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
}
