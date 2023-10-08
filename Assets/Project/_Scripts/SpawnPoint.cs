using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        if(MenuManager.Instance.Animals[0].TryGetComponent(out Cat cat))
            MenuManager.Instance.SpawnCat();
        if(MenuManager.Instance.Animals[1].TryGetComponent(out Dog dog))
            MenuManager.Instance.SpawnDog();
    }
}
