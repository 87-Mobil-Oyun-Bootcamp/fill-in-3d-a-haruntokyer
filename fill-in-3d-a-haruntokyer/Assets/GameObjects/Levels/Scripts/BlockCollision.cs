using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour

{
    


    private void OnCollisionEnter(Collision collision)
    {   


        if (collision.collider.tag == "Cube" && GetComponent<BoxCollider>().enabled)
        {
            GetComponent<BoxCollider>().enabled = false;
            Destroy(collision.gameObject);
            Debug.Log("hit cube");
            GetComponent<MeshRenderer>().enabled = true;
            
            
            if (gameObject)
            {
                gameObject.layer = LayerMask.NameToLayer("FilledBlock");
            }

            var blockController = GetComponent<BlockController>();

            if (blockController)
            {
                blockController.BlockState = BlockState.Filled;
            }
            
        }
    }

}
