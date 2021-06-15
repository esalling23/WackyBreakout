using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    new void Start()
    {
        points = (int)ConfigurationUtils.BonusBlockPoints;
        health = 50;

        base.Start();
    }
}
