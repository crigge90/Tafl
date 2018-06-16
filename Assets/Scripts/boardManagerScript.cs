using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boardManagerScript : MonoBehaviour
{
    bool defendersTurn = false;
    public GameObject TurnTextObject;
    private Text turn;
    [SerializeField, Range(1,5)]
    int numberOfPlayers = 2;
    List<Player> playerList = new List<Player>();

    public class Player
    {
       public PlayerRole role = PlayerRole.Attacker;
       public enum PlayerRole
        {
            Attacker,
            Defender
        }
        public string PlayerName = "Player";
    }

    private static boardManagerScript instance;
    public bool DefendersTurn
    {
        get { return defendersTurn; }
        set { defendersTurn = value; }
    }
    public bool PieceSelected
    {
        get; set;
    }

    public static boardManagerScript Instance
    {
        get {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<boardManagerScript>();
                if (instance == null)
                {
                    GameObject container = new GameObject();
                    instance = container.AddComponent<boardManagerScript>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        Player player = new Player();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerList.Add(new Player());
            playerList[i].PlayerName = "player " + (i + 1);
            if (i == numberOfPlayers - 1)
            {
                playerList[i].role = Player.PlayerRole.Defender;
            }
        }

        turn = TurnTextObject.GetComponent<Text>();

        SetTurnText();

        PieceSelected = false;
    }

    public bool getTurn()
    {
        return defendersTurn;
    }

    public void ChangeTurn()
    {
        defendersTurn = !defendersTurn;
    }

    private void SetTurnText()
    {
        if (defendersTurn)
        {
            turn.text = "Defenders Turn";
        }
        else
        {
            turn.text = "Attackers Turn";
        }
    }
}
