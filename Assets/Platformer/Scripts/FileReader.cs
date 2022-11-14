using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{

    const string FILE_NAME = "tuning.txt";

    string tuningContent;
    string[] variables;
    char lineDelimiter = ';';

    float newSpeed;
    float newRaycastDist;
    float newJumpForce;

    PlayerMove playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();

        StreamReader reader = new StreamReader(FILE_NAME, false);
        tuningContent = reader.ReadToEnd();

        variables = tuningContent.Split(lineDelimiter);

        playerScript.speed = float.Parse(variables[0]);
        playerScript.raycastDist = float.Parse(variables[1]);
        playerScript.jumpForce = float.Parse(variables[2]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
