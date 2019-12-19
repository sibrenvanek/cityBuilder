using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public bool startLocationSet = false;
    public bool endLocationSet = false;
    public Vector3 startLocation;
    public Vector3 endLocation;
    public LineRenderer renderer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked();
        }
    }

    void Clicked()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Ground")
            {
                SetStartLocation(hit.point);
            }
        }
    }

    void HandleHit(Vector3 location)
    {
        if (startLocationSet)
        {
            SetEndLocation(location);
        }
        else
        {
            SetStartLocation(location);
        }
    }

    void SetStartLocation(Vector3 location)
    {
        startLocationSet = true;
        startLocation = location;
    }

    void SetEndLocation(Vector3 location)
    {
        endLocationSet = true;
        endLocation = location;
    }

    public void BuildRoad()
    {
        Vector3[] test = new Vector3[2];
        test[0] = startLocation;
        test[1] = endLocation;
        renderer.SetPositions(test);
    }
}
