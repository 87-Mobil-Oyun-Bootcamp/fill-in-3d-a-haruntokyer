using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    Vector3 groundPos = Vector3.zero;

    public List<GameObject> CreateGroundFromImage(LevelInfo levelInfo, Transform transform)
    {
      
        List<GameObject> createdGround = new List<GameObject>();

        for (int x = 0; x < levelInfo.sprite.texture.width; x++)
        {
            for (int y = 0; y < levelInfo.sprite.texture.height; y++)
            {
                Color color = levelInfo.sprite.texture.GetPixel(x, y);

                if (color.a == 0)
                {
                    continue;
                }

                groundPos = new Vector3(
                    levelInfo.size * (x - (levelInfo.sprite.texture.width * .5f)),
                    .0001f,
                    levelInfo.size * (y - (levelInfo.sprite.texture.height * .5f)));

                GameObject gorundObj = Instantiate(levelInfo.groundObj, transform);
                gorundObj.transform.localPosition = groundPos;

                gorundObj.transform.localScale = Vector3.one * levelInfo.size ;

                createdGround.Add(gorundObj);


            }
        }

        return createdGround;
    }
}
