using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns block levels
///
/// TODO: Spawn based on a difficulty
/// TODO: Modify block sizes for screen, level, etc
/// </summary>
public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] blocks;

    [SerializeField]
    int size = 4;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D firstBlockCollider = blocks[0].GetComponent<BoxCollider2D>();
        float blockHeight = firstBlockCollider.size.y;
        float blockWidth = firstBlockCollider.size.x;
        float leftoverSpace = 0;
        print(blockHeight);
        print(blockWidth);
        print(ScreenUtils.ScreenRight);
        print(ScreenUtils.ScreenLeft);
        // Currently just spawn a level of 2 columns, 6 rows
        for (int i = 0; i < Mathf.Floor(ScreenUtils.ScreenWidth / blockWidth); i++)
        {
            for (int j = 0; j < size; j++)
            {
                float x = ScreenUtils.ScreenLeft + blockWidth*i + blockWidth/2;
                Vector3 position = new Vector3(
                    x,
                    ScreenUtils.ScreenTop - blockHeight/2 - (blockHeight * j),
                    0
                );
                GameObject block = Instantiate(
                    blocks[Random.Range(0, blocks.Length)],
                    position,
                    Quaternion.identity,
                    gameObject.transform
                );

                if (j == size - 1 && i == Mathf.Floor(ScreenUtils.ScreenWidth / blockWidth) - 1)
                {
                    leftoverSpace = ScreenUtils.ScreenRight - (block.transform.position.x + blockWidth / 2);
                    Vector3 newPos = transform.position;
                    newPos.x += leftoverSpace / 2;
                    transform.position = newPos;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
