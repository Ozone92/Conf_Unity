using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemieSpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ennemie;
    public TMP_Text scoreText;

    private List<GameObject> ennemies = new List<GameObject>();
    private int score;
    private float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();

        if (timer >= 3)
        {
            for (int i = 0; i < (score / 3) + 1; i++)
            {
                EnnemieGestion ennemieSpawn = (Instantiate(ennemie, new Vector3(Random.Range(-55, 55), 0, 12), ennemie.transform.rotation)).GetComponent<EnnemieGestion>();
                ennemieSpawn.spawnManager = this;
                ennemies.Add(ennemieSpawn.gameObject);
                timer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void End()
    {
        scoreText.gameObject.SetActive(false);
        int res = score;
        score = 0;
        timer = 0;

        foreach (GameObject e in ennemies)
        {
            if (e != null)
                Destroy(e);
        }

        gameManager.EndGame(res);   
    }

    public void AddScore()
    {
        score += 1;
    }
}
