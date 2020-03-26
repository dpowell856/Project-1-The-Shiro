using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Dash,
    Interact,
    Shoot,
    Abillity
};

public enum Axis {
    Horizontal,
    Vertical,
    LookHorizontal,
    LookVertical
};

public class Player {

    private Rewired.Player _player;

    public Character _character { private set; get; }

    public ID playerID { private set; get; }

    public enum ID {
        player0 = 0,
        player1 = 1,
        player2 = 2,
        player3 = 3
    };

    public Player(ID playerIDSet)
    {
        _player = Rewired.ReInput.players.GetPlayer((int)playerIDSet);
        playerID = playerIDSet; 
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