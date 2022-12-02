using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerScript : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text replayText;
    private int ammo = 0;
    public Text superText;

    public GameObject enemy;
    public GameObject restart;

    public bool isGameOver=false;


    IEnumerator SpawnEnemy()
    {
        while (!isGameOver)
        {
            // 待完善
            // 该代码的功能为每隔0.5秒在2.0f, 2.0f, 0.0f位置生成敌机enemy，请修改
            //x -10~10  y 4-0\
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(0f, 4f);
            Instantiate(enemy,new Vector3(x, y, 0.0f),transform.rotation);
            float sec = Random.Range(0.05f, 2f);
            yield return new WaitForSeconds(sec);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        score = 0;
        UpdateScoreText();
        replayText.text = "";
        superText.text = "SuperAmmo: "+"0";
        isGameOver = false;
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount==1 && isGameOver)
        {
            // 待完善，提示：可重新载入场景

            //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            restart.SetActive(true);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        // 待完善
        score++;
        Debug.Log(score);
        UpdateScoreText();

    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    private void UpdateSuperText()
    {
        superText.text = "SuperAmmo: " + ammo;
    }
    public void setAmmo(int num)
    {
        ammo = num;
        UpdateSuperText();
    }
    public void GameOver()
    {
        replayText.text = "You are dead!";
        isGameOver = true;
    }
}
