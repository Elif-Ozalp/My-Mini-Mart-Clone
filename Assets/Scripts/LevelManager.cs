using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> Customers = new List<GameObject>();
    [SerializeField] public  List<GameObject> Positions = new List<GameObject>();
    [SerializeField] private TMP_Text coinText;
    public int coin = 0;
    public static LevelManager Instance { get; private set; }
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        Application.targetFrameRate = 60;
        UpdateMoney(0);
    }

    public void UpdateMoney(int amt)
    {
        coin += amt;
        coinText.text = coin.ToString();
    }

    public void RestartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
    
    
    public void NextLevel()
    {
        int idx = SceneManager.GetActiveScene().buildIndex + 1;
        if (idx <= 10)
            SceneManager.LoadScene(idx);
        else
        {
            idx = 1;
            SceneManager.LoadScene(idx);
        }
            
        PlayerPrefs.SetInt("levelIndex",idx);
    }
    public void RemoveFromCashierQueue(GameObject gameObject)
    {
        Customers.Remove(gameObject);

    }

    public void AddOnCashierQueue(GameObject gameObject)
    {
        Customers.Add(gameObject);
    }
}
