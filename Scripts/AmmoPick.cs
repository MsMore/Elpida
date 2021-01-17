﻿using UnityEngine;
//using UnityEngine.UI;

public class PickUpObj : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    [SerializeField]
    float pickupDistance = 5f;
    public Camera mainCam;
    public Shooting shootscript;
    public LayerMask layer;
    //public Text pickupText;
    //string pickupInfo;

    public void Start()
    {
        //mainCam = Camera.main;
        //shootscript = GetComponentInChildren<Child>();
    }

    public void Update()
    {
        ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray, out hit, pickupDistance, layer))
        {
            //pickupText.enabled = true;
            //pickupText.text = hit.transform.name.ToString();

            if(hit.transform.tag == "AmmoPick")
            {
                if (shootscript.availableAmmo != shootscript.maxavailableAmmo)
                {
                    PickupAmmo();
                }
                else
                {
                    //pickupInfo = "Ammunation is Full";
                    //pickupText.text = pickupInfo;
                }
            }
        }
        else
        {
            //pickupText.enabled = false;
        }
    }

    void PickupAmmo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(hit.transform.gameObject);
            shootscript.availableAmmo = shootscript.maxavailableAmmo;
            //pickupText.enabled = false;

        }
    }
}

