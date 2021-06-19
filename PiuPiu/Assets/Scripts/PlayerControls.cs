using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitchF = -2f;
    [SerializeField] float ControlPitchF = -10f;
    [SerializeField] float positionYaw = 2f;
    [SerializeField] float positionRoll = -2f;


    [SerializeField] GameObject[] lasters;

   

    float horizontally;
    float vertically;
    float fire;
    void Start()
    {
        
    }
    
    
    void Update()
    {

        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchF;
        float pitchDueToControlThrow= vertically * ControlPitchF;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYaw;
        float roll = horizontally*positionRoll ;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void ProcessTranslation()
    {
        horizontally = Input.GetAxis("Horizontal");
        vertically = Input.GetAxis("Vertical");

        float yOffset = vertically * Time.deltaTime * controlSpeed;
        float xOffset = horizontally * Time.deltaTime * controlSpeed * 2;

        float newXPos = transform.localPosition.x + xOffset;


        float newYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
     
        if (Input.GetButton("Fire1"))
        {

            ActiveLasers();
        }
        else
        {
            DeactivateLasers();

        }

    }

    void ActiveLasers()
    {
        foreach(GameObject laser in lasters)
        {
            

            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
        }

    }
    void DeactivateLasers()
    {
        foreach (GameObject laser in lasters)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }

    }




}
