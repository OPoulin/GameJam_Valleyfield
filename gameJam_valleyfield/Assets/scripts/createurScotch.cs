using FMODUnity;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class createurScotch : MonoBehaviour
{
    public Camera cam;
    public GameObject ogTape;
    public GameObject parentTableau;
    GameObject newTape;

    public Material matTape;
    //public Transform point;

    void Update()
    {
        if(toolManagerScript.selectedToolName == "tape")
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreerScotch();
            }
            if (Input.GetMouseButton(0))
            {
                PositionScotch();
            }
            if (Input.GetMouseButtonUp(0))
            {
                Mesh mesh = new Mesh();
                newTape.GetComponent<LineRenderer>().BakeMesh(mesh, true);
                MeshRenderer meshRenderer = newTape.AddComponent<MeshRenderer>();
                meshRenderer.material = matTape;
                MeshCollider meshCollider = newTape.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
                MeshFilter meshFilter = newTape.AddComponent<MeshFilter>();
                meshFilter.mesh = mesh;
                Destroy(newTape.GetComponent<LineRenderer>());
                newTape.GetComponent<MeshRenderer>().rendererPriority = 10;
            }

        }
    }

    void PositionScotch()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            newTape.GetComponent<LineRenderer>().SetPosition(1, hit.point);
        }
    }

    void CreerScotch()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            //point.transform.position = hit.point;
            newTape = Instantiate(ogTape);
            //print(newTape);
            newTape.SetActive(true);
            newTape.transform.parent = parentTableau.transform;
            newTape.GetComponent<LineRenderer>().SetPosition(0, hit.point);
            RuntimeManager.PlayOneShot(AllSFX.scotch);
        }
    }
}
