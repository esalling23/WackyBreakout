using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns block levels
///
/// TODO: Spawn based on a difficulty
/// TODO: Modify block sizes for screen, level, etc
/// </summary>
public class LevelBuilder : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject[] blocks;

    [SerializeField]
    int levelHeight = 4;

    [SerializeField]
    float topUiOffset = 0.75;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D firstBlockCollider = blocks[0].GetComponent<BoxCollider2D>();
        float blockHeight = firstBlockCollider.size.y;
        float blockWidth = firstBlockCollider.size.x;
        float leftoverSpace = 0;
        
        // Currently just spawn a level based on block width
        // and set `levelHeight` field
        float levelWidth = Mathf.Floor(ScreenUtils.ScreenWidth / blockWidth);
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                // x position should be starting at the left
                // add space for current blocks already placed in the loop
                // plus half width of a block
                float x = ScreenUtils.ScreenLeft + (blockWidth * i) + (blockWidth / 2);
                // y position should be starting at the top
                float y = ScreenUtils.ScreenTop - topUiOffset - (blockHeight / 2) - (blockHeight * j);
                Vector3 position = new Vector3(x, y, 0);

                GameObject block = Instantiate(
                    blocks[Random.Range(0, blocks.Length)],
                    position,
                    Quaternion.identity,
                    gameObject.transform
                );

                // Centers the level on the last loop
                // Uses the position of the last instantiated block
                if (j == levelHeight - 1 && i == levelWidth - 1)
                {
                    leftoverSpace = ScreenUtils.ScreenRight - (block.transform.position.x + blockWidth / 2);
                    Vector3 newPos = transform.position;
                    newPos.x += leftoverSpace / 2;
                    transform.position = newPos;
                }
            }
        }
    }

    #endregion
}
