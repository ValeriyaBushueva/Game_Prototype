using System;
using System.Collections;
using System.Collections.Generic;
using RollBall;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    private Player _player;
    private SaveDataRepository _saveDataRepository;
    private KeyCode _savePlayer = KeyCode.C;
    private KeyCode _loadPlayer = KeyCode.V;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _saveDataRepository = new SaveDataRepository();
    }

    public void Update()
    {
        if (Input.GetKeyDown(_savePlayer))
        {
            BonusMark[] bonusMarks = FindObjectsOfType<BonusMark>();
            _saveDataRepository.Save(_player, bonusMarks);
        }
        if (Input.GetKeyDown(_loadPlayer))
        {
            _saveDataRepository.Load(_player);
        }
    }

}
