using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] AudioSource soundEffect1;
    [SerializeField] AudioSource soundEffect2;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Cookies Eaten: " + score;
        //Increase player speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
        if (score % 10 == 0)
        {
            int randomIndex = Random.Range(0, 2); // Randomly choose between 0 and 1
            if (randomIndex == 0)
            {
                soundEffect1.Play();
            }
            else
            {
                soundEffect2.Play();
            }
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
