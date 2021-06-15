using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupBlock : Block
{

    [SerializeField]
    Sprite[] pickupBlockSprites;
    [SerializeField]
    Sprite[] pickupBlockBrokenSprites;

    new void Start()
    {
        points = (int)ConfigurationUtils.PickupBlockPoints;

        int ran = Random.Range(0, pickupBlockSprites.Length);
        PickupType chosenType = (PickupType) ran;
        // print(chosenType);
        // print(ran);
        GetComponent<SpriteRenderer>().sprite = pickupBlockSprites[ran];
        brokenBlock = pickupBlockBrokenSprites[ran];

        base.Start();
    }
}
