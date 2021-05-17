using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController CharacterController;
    private float speed = 10f;
    private float rx = 0, ry;
    private float angelerSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;
        rx -= Input.GetAxis("Mouse Y")*angelerSpeed*Time.deltaTime;
        ry = transform.localEulerAngles.y+Input.GetAxis("Mouse X") * angelerSpeed * Time.deltaTime;
        if(rx<90 && rx > -90)
        {
            playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        }
        transform.localEulerAngles = new Vector3(0, ry, 0);
        dx = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 motion = new Vector3(dx, 0, dz);
        motion = transform.TransformDirection(motion);
        CharacterController.Move(motion);
    }
}
