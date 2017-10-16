using Assets;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    public Vector3 spinSpeed = Vector3.zero;
    Vector3 spinAxis = new Vector3(0, 1, 0);
    public Mesh sphereMesh;
    internal Mountain mountain;

    void Start()
    {
        
        SetSize(mountain.Size);

        gameObject.transform.position = mountain.position;

        transform.Find("New Text").GetComponent<TextMesh>().text = mountain.MountainName;//"Hullo Again";

    }


    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(spinSpeed);
        transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed);
    }
}
