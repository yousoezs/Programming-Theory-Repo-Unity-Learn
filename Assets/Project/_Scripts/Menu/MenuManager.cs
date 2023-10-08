using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public List<GameObject> SpawnPoint;
    public List<GameObject> Animals;

    #region Fields

    public string PlayerName = string.Empty;
    public int PlayerAge;

    #endregion

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("ChooseAnimal", LoadSceneMode.Single);
    }

    public void StartGameAsCat()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void StartGameAsDog()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void SpawnDog()
    {
        Instantiate(Animals[0], SpawnPoint[0].transform.position, Quaternion.identity);
    }

    public void SpawnCat()
    {
        Instantiate(Animals[1], SpawnPoint[1].transform.position, Quaternion.identity);
    }
}