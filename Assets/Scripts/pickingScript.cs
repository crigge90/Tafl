using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingScript : MonoBehaviour
{
    public GameObject selectedObject = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit cameraHit;
        if (Physics.Raycast(cameraRay, out cameraHit))
        {
            if (Input.GetMouseButtonUp(0))
            {
                selectedObject = cameraHit.collider.gameObject;
            }
        }
        if(selectedObject != null && Input.GetMouseButtonUp(0))
        {
            selectedObject.transform.Translate(new Vector3(0f,0.1f,0f));
        }
    }
}
