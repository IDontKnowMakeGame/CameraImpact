using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cvCam;
    private CinemachineImpulseSource source;

    [SerializeField]
    private float value;

    private void Awake()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("asd");
            Debug.Log(source);
            Shake();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            ZoomIn();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ZoomOut();
        }
    }
    public void Shake()
    {
        source.GenerateImpulse(value);
    }
    public void ZoomIn()
    {
        StartCoroutine(ZoomInOut(50, 0.002f));
    }
    public void ZoomOut()
    {
        StartCoroutine(ZoomInOut(60, 0.002f));
    }
    private IEnumerator ZoomInOut(float value, float smoothTime)
    {

        if (_cvCam.m_Lens.FieldOfView > value)
        {
            while (_cvCam.m_Lens.FieldOfView >= value)
            {
                _cvCam.m_Lens.FieldOfView -= 1;
                yield return new WaitForSeconds(smoothTime);
            }
        }
        else
        {
            while (_cvCam.m_Lens.FieldOfView <= value)
            {
                _cvCam.m_Lens.FieldOfView += 1;
                yield return new WaitForSeconds(smoothTime);
            }
        }

    }
    public void TimeSlow()
    {
        Time.timeScale = 0.1f;
    }
    public void TimeSet()
    {
        Time.timeScale = 1;
    }

}
