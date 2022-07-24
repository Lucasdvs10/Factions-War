using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderTransition : MonoBehaviour
    //Tentativa de um script de transicao para o sniper defensor (nao ta funcionando)
{
    private Animator _animator;
    void Start() {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown("space")){
            _animator.SetBool("Shooting", true);
            System.Threading.Thread.Sleep(700);
            _animator.SetBool("Shooting",false);
        }
    }
}
