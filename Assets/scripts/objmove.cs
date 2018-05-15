using UnityEngine;
using System.Collections;
public class objmove : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            Debug.Log("hitting");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("destroy");
                Debug.Log(this.name);
                Destroy(gameObject);
            }
        }
    }
    //GameObject mainCamera;
    //bool carrying = false;
    //GameObject carriedObject;
    //public float distance;
    //public float smooth;
    //private void Start()
    //{
    //    mainCamera = GameObject.FindWithTag("MainCamera");
    //}

    //private void Update()
    //{
    //    if(carrying)
    //    {
    //        carry(carriedObject);
    //        checkDrop();
    //    }
    //    else
    //    {
    //        pickup();
    //    }
    //}

    //void carry(GameObject carrys)
    //{
    //    carrys.transform.position = Vector3.Lerp(carrys.transform.position,
    //        mainCamera.transform.position + mainCamera.transform.forward * distance, 
    //        Time.deltaTime * smooth);
    //}

    //void pickup()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //    {
    //        int x = Screen.width / 2;
    //        int y = Screen.height / 2;
    //        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            objmove p = hit.collider.GetComponent<objmove>();
    //            if (p != null)
    //            {
    //                carrying = true;
    //                carriedObject = p.gameObject;
    //                p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //            }
    //        }
    //    }
    //}
    //void checkDrop()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //    {
    //        dropObject();
    //    }
    //}

    //void dropObject()
    //{
    //    carrying = false;
    //    carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //    carriedObject = null;
    //}
}

