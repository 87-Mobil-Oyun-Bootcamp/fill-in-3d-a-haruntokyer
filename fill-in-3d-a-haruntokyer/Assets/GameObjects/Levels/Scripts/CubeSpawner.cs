using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject cube;

    float a;
    float z;
    Vector3 cubePos = Vector3.zero;

    public List<GameObject> CreatBaseCube(BlockSpawner block,Transform transform)
    {
        List<GameObject> Cubes = new List<GameObject>();

        for (int x = 0; x < block.blockCount; x++)
        {

            a = Random.Range(-3f, 3f);
            
            z = Random.Range(-1f, -4f);
            cubePos = new Vector3(
                   a,
                   .3f * .5f,
                   z);

            GameObject cubeObje = Instantiate(cube, transform);
            cubeObje.transform.localPosition = cubePos;

            cubeObje.GetComponent<Renderer>().material.color = Color.black;
            cubeObje.transform.localScale = Vector3.one * .3f;

            Cubes.Add(cubeObje);
        }
        Debug.Log("küp sayısı " +Cubes.Count);
        return Cubes;
    }

}

