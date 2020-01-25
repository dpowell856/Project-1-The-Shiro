using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Player _player;

    void Start()
    {
        _player = Players.GetPlayer(Player.ID.player0);
    }

    private void Update()
    {
        // GetAction is a boolean that returns true when the button is down
        if (_player.GetAction(Action.Shoot))
        {
            print("SHOOT BUTTON HAS BEEN PRESSED");
        }

        // GetAxis with joystick returns a float based on how hard the joystick is pushed with left/bottom being -1 and right/top being 1
        // GetAxis with keyboard is based on time held down so it takes about 0.6s to have magnitude 1
        if(_player.GetAxis(Axis.Horizontal) != 0)
        {
            print("HORIZONTAL AXIS BEING ACTIVATED WITH: " + _player.GetAxis(Axis.Horizontal));
        }
    }
}
