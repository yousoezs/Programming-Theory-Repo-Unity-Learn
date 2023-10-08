using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Animal : MonoBehaviour
{
    //Encapsulation
    #region Fields
    private string _name = "Animal";
    
    private int _age = 2;

    private float _walkSpeed = 5f;
    #endregion
    
    #region Properties
    // ENCAPSULATION
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public float WalkSpeed
    {
        get => _walkSpeed;
        set => _walkSpeed = value;
    }
    #endregion

    #region Virtual Methods
    // ABSTRACTION
    public virtual string GetName(string name) => name;
    public virtual int GetAge(int age) => age;

    #endregion

    #region Abstract Methods
    // POLYMORPHISM
    public abstract void Move();
    public abstract void Jump();
    public abstract void Talk();

    #endregion
}
