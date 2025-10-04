using UnityEngine;

public class DamageRay : MonoBehaviour
{
    
    Camera cam;



    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        Vector3 point = cam.ScreenToWorldPoint(mousePos);

        RaycastHit hit;
        Physics.Raycast(cam.ScreenPointToRay(mousePos), out hit);

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
            
        
        
    }
}
