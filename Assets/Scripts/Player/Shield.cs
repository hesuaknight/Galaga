using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IPlayerObserver {

    private Player _player;

    private void Awake() {
        _player = GetComponentInParent<Player>();

    }


    public void notify() {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        Debug.Log(_player);
        _player._playerSubject.Add(this);
    }

    private void OnDisable() {
        _player._playerSubject.Remove(this);
    }

}
