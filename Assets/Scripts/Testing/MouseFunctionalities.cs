using UnityEngine;
using System.Collections.Generic;

public class MouseFunctionalities : MonoBehaviour
{
    public List<int> entry = new List<int>() { 1, 2, 3, 4, 2, 3, 1};

    private void Start()
    {
        
    }
}


/* Vector3 point, distance;

    private void OnMouseDown()
    {
        point = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        distance = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, point.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, point.z);
        Vector3 curDistance = Camera.main.ScreenToWorldPoint(curPoint) + distance;
        transform.position = curDistance;

        Debug.Log($"CPoint {curPoint} CDis {curDistance}");
    }
*/