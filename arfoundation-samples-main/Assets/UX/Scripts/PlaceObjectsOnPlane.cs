﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectsOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;
    public GameObject m_text;
    AudioSource source;
    AudioSource otherSource;

    public GameObject btnGo;
    public GameObject popSource;
    Animator goAnimator;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    [SerializeField]
    int m_MaxNumberOfObjectsToPlace = 1;

    int m_NumberOfPlacedObjects = 0;

    [SerializeField]
    bool m_CanReposition = true;

    public bool canReposition
    {
        get => m_CanReposition;
        set => m_CanReposition = value;
    }

    void Awake()
    {
        m_text.SetActive(false);
        m_RaycastManager = GetComponent<ARRaycastManager>();
        source = GetComponent<AudioSource>();
        goAnimator = btnGo.GetComponent<Animator>();
        otherSource = popSource.GetComponent<AudioSource>();
        goAnimator.SetBool("go", false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                var touchPosition = touch.position;

                bool isOverUI = touchPosition.IsPointOverUIObject();

                if (!isOverUI && m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    if (m_NumberOfPlacedObjects < m_MaxNumberOfObjectsToPlace)
                    {
                        spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                        
                        m_NumberOfPlacedObjects++;
                   
                        btnGo.SetActive(true);
                        showFinish();
                        if (SoundEffectsToggle.isOn == true)
                        {
                            source.Play(0);
                        }
                        goAnimator.SetBool("go", true);
                    }
                    else
                    {
                        if (m_CanReposition)
                        {
                            spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                            if (SoundEffectsToggle.isOn == true)
                            {
                                otherSource.Play(0);
                            }
                        }
                    }
                    
                    if (onPlacedObject != null)
                    {
                        onPlacedObject();
                    }
                }
            }
        }
    }

    public void showFinish()
    {
        m_text.SetActive(true);
    }
}
