using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private List<GameObject> _spawnPoint;
    [SerializeField] private List<GameObject> _animals;
    
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SpawnCat;
        SceneManager.sceneLoaded += SpawnDog;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SpawnCat;
        SceneManager.sceneLoaded -= SpawnDog;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("ChooseAnimal", LoadSceneMode.Single);
    }

    public bool StartGameAsCat()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        return true;
    }

    public bool StartGameAsDog()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        return true;
    }

    private void SpawnDog(Scene arg0, LoadSceneMode loadSceneMode)
    {
        if (!StartGameAsDog()) return;
            Instantiate(_animals[0], _spawnPoint[0].transform.position, Quaternion.identity);
    }

    private void SpawnCat(Scene arg0, LoadSceneMode loadSceneMode)
    {
        if (!StartGameAsCat()) return;
            Instantiate(_animals[1], _spawnPoint[1].transform.position, Quaternion.identity);
    }
}
