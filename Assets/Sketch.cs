using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using Assets;

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    public string _WebsiteURL = "http://infomgmt192.azurewebsites.net/tables/Mountain?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Mountain[] mountains = JsonReader.Deserialize<Mountain[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

        int i = 0;
        int totalCubes = mountains.Length;
        float totalDistance = 2.9f;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Mountain mt in mountains)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + mt.MountainName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            //float perc = i / (float)totalCubes;
            //float sin = Mathf.Sin(perc * Mathf.PI / 2);

            // 
            float x = mt.X;
            float y = mt.Y;
            float z = mt.Z;                         

            var newCube = Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            CubeScript cubeScript = newCube.GetComponent<CubeScript>();
            cubeScript.mountain = mt;
            // Use the mountains size to set the scale.
            cubeScript.SetSize(mt.Size);

            // 
            if (mt.Symbol == "Sphere")
            {
                newCube.GetComponent<MeshFilter>().mesh = cubeScript.sphereMesh; 
            }
              
            newCube.transform.Find("New Text").GetComponent<TextMesh>().text = mt.MountainName;//"Hullo Again";
            i++;

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
