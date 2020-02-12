using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSelect : MonoBehaviour
{
    public GameObject SelectNum;
    public GameObject CharNum;
    [SerializeField] private Player.ID _tempPlayerID;
    public Player Select { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Select = Players.GetPlayer(_tempPlayerID);
        SelectNum.SetActive(false);
        CharNum.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Select.GetAction(Action.Dash))
        {
            CharNum.SetActive(true);
            SelectNum.SetActive(true);
        }
    }
}
