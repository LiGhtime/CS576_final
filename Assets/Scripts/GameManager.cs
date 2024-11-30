// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int currentNumber = 0;
    public int score = 0;
    public int lives = 3;
    public float gameSpeed = 5f;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Initialize starting number (1-3)
        currentNumber = Random.Range(1, 4);
    }
    
    public void UpdateNumber(string operation, int value)
    {
        switch (operation)
        {
            case "add":
                currentNumber += value;
                break;
            case "multiply":
                currentNumber *= value;
                break;
            case "divide":
                currentNumber /= value;
                break;
        }
    }
    
    public bool CheckEven()
    {
        return currentNumber % 2 == 0;
    }
}