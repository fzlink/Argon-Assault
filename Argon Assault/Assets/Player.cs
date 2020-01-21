using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] private float xPlayerSpeed = 15;
    [Tooltip("In ms^-1")][SerializeField] private float yPlayerSpeed = 15;
    [Tooltip("In meters")][SerializeField] private float xRange = 5;
    [Tooltip("In meters")][SerializeField] private float yRange = 3;

    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float positionYawFactor = 5f;
    [SerializeField] private float controlRollFactor = -10f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xPlayerSpeed * Time.deltaTime;
        float yOffset = yThrow * yPlayerSpeed * Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;

        newXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        newYPos = Mathf.Clamp(newYPos, -yRange, yRange);
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
