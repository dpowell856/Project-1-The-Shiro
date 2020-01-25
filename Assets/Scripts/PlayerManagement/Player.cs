﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Dash,
    Interact,
    Shoot
};

public enum Axis {
    Horizontal,
    Vertical
};

public class Player {

    private Rewired.Player _player;

    public Character _character { private set; get; }

    public ID _playerID { private set; get; }

    public enum ID {
        player0 = 0,
        player1 = 1,
        player2 = 2,
        player3 = 3
    };

    public Player(ID playerID)
    {
        _player = Rewired.ReInput.players.GetPlayer((int)playerID);
    }

    public bool GetAction(Action action)
    {
        return _player.GetButtonDown(action.ToString());
    }

    public float GetAxis(Axis axis)
    {
        return _player.GetAxis(axis.ToString());
    }

    private void SetCharacter(Character character)
    {
        _character = character;
    }
}