using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tileStatus { defender, attacker, empty };
public enum tileType { throne, attackBase, corner, plain }
public class tileScript
{
    tileStatus status = tileStatus.empty;
  
    tileType type = tileType.plain;



    public void setType(tileType _type)
    {
        type = _type;
    }

	public void TileEnter (bool defender)
    {
        if (status == tileStatus.empty)
        {
            if (defender)
                status = tileStatus.defender;
            else
                status = tileStatus.attacker;
        }
	}
    public void TileLeave()
    {
        status = tileStatus.empty;
    }

    public tileStatus GetTakenStatus()
    {
      return  status;
    }

}
