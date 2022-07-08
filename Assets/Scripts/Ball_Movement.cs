using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_Movement : MonoBehaviour
{
    //creating instance of ball_movement 
    public static Ball_Movement instance;

     private MeshRenderer ball_mesh;
     private Rigidbody _rb;
    private Gameplay_UI_Manager _gameplayUIManager;
    public GameObject gameplayUiManager_GO;

    [Header("ball_movement")]
    public int score;
    [SerializeField] private int _speed;

    [Header("timer")]
    public float timeLeft;
    private bool _timerOn = false;
    [SerializeField] private Text _timerText;

    //PowerUp
    private bool spawned = false;
    private bool spawnOnce = true;
    private float powerUpTimeLeft = 30f;

    //Health
    [HideInInspector]public  int healthLeft = 100;
    public Text showHealth;
    public HealthBar healthbarRef;


    private void Awake()
    {
        if(instance == null && instance != this)
        {
            instance = this;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        ball_mesh = GetComponent<MeshRenderer>();
        _gameplayUIManager = gameplayUiManager_GO.GetComponent<Gameplay_UI_Manager>();
        healthbarRef.setMaxHealth(healthLeft);
      
    }
    private void Update()
    {
        //ball movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        _rb.AddForce(move, ForceMode.Impulse);

        if (_timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                _timerOn = false;
            }
        }

        //starts timer only when ball moves for first time
        if (horizontal > 0 || vertical > 0) {
            _timerOn = true;
        }

        //for gameover scene
        if (timeLeft == 0)
        {
            endGame();
        }

        //spawns a powerUp when score is between 60 and 80  
        if (score>= Random.Range(60, 80) && spawnOnce)
        {
            PowerUp.instancePowerUp.spawnPowerUp();
            spawnOnce = false;
            spawned = true;
        }
        if (spawned)
        {
            powerUpTimeLeft -= Time.deltaTime;
            if (powerUpTimeLeft <= 0)
            {
                PowerUp.instancePowerUp.powerUpfab.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_speed< 20)
            _speed += 1;

        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(_speed>0)
            _speed -= 1;
        }
        //updates health
        updateHealth();
   
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            other.gameObject.SetActive(false);
            ball_mesh.material.color = Random.ColorHSV();
            addScore(10);
            _gameplayUIManager.scoreText.text = "Score:" + score;
          
        }
        else if(other.gameObject.tag == "PowerUp")
        {
            other.gameObject.SetActive(false);
            ball_mesh.material.color = Random.ColorHSV();
            addScore(50);
            _gameplayUIManager.scoreText.text = "Score:" + score;
        }
        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "damageWalls")
        {

            if (healthLeft > 0)
            {
                healthLeft -= 20;
                healthbarRef.setheatlh(healthLeft);
            }


            else if (healthLeft <= 0)
                endGame();

            
        }
    }
    private int addScore(int points)
    {
        score += points;
        if (score >= 200 && _timerOn)
        {
            endGame();
        }
        return score;
    }

    private void endGame()
    {
        SceneManager.LoadScene(2);
    }

    private void updateTimer(float current_time)
    {
        current_time += 1;
        float minutes = Mathf.FloorToInt( current_time / 60);
        float seconds = Mathf.FloorToInt(current_time % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void updateHealth()
    {
        showHealth.text = string.Format("{000}", healthLeft);
    }

}
