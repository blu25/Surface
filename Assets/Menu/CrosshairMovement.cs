using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMovement : MonoBehaviour
{
    public Transform playerPos;
    public Transform cameraPos;

    Camera cam;
    Image crosshairImg;

    // Start is called before the first frame update
    void Start()
    {
        cam = cameraPos.GetComponent<Camera>();
        crosshairImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Quaternion difference = cameraPos.rotation * Quaternion.Inverse(playerPos.rotation);
        Vector3 diff = playerPos.rotation.eulerAngles - cameraPos.rotation.eulerAngles;

        if (Physics.Raycast(playerPos.position + playerPos.forward * 2, playerPos.forward, out hit, 300f)) {
            Vector3 point = cam.WorldToScreenPoint(hit.point);
            crosshairImg.color = new Color(0, 255, 0, 1f);
            transform.position = new Vector3(point.x, point.y, 0f);
        } else {
            transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            crosshairImg.color = new Color(255, 255, 255, 0.25f);
        }

        
    }
}
