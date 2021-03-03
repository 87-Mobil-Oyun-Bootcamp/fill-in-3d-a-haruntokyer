using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour

{
    [Space]
    [SerializeField]
    private MeshRenderer blockMeshRenderer;



    private void OnCollisionEnter(Collision collision)
    {   


        if (collision.collider.tag == "Cube")
        {
            Debug.Log("hit cube");
            blockMeshRenderer.enabled = true;
            Destroy(collision.gameObject);
            GetComponent<BoxCollider>().enabled = false;
            if (gameObject)
            {
                gameObject.layer = LayerMask.NameToLayer("FilledBlock");
            }

            var blockController = GetComponent<BlockController>();

            if (blockController) ;
            {
                blockController.BlockState = BlockState.Filled;
            }
            
        }
    }

}
