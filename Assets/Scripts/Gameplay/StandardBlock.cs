using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite[] standardBlockSprites;
    [SerializeField]
    Sprite[] standardBlockBrokenSprites;

    void Start()
    {
        base.Start();
        points = (int)ConfigurationUtils.StandardBlockPoints;

        int ran = Random.Range(0, standardBlockSprites.Length);
        GetComponent<SpriteRenderer>().sprite = standardBlockSprites[ran];
        brokenBlock = standardBlockBrokenSprites[ran];
    }

    
}
