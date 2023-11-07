using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    private float _radiusPrefab;

    private void Awake()
    {
        _radiusPrefab = _sphere.transform.localScale.y / 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float r = 0.01f;
            for (int i = 10; i >= 0; i--)
            {
                float cosA = (2 * r * r - _radiusPrefab * _radiusPrefab) / (2 * r * r); 
                float alpha = (float)(Math.Acos(cosA) * 180 / Math.PI);
                float sinA = (float)Math.Sin(alpha);

                float X = r * cosA;
                float Z = r * sinA;

                var point = new Vector3(X, 0, Z);
                Initialize(point);
                r++;
            }
        }
    }

    private void Initialize(Vector3 point)
    {
        Debug.Log(point);
        Instantiate(_sphere, point, Quaternion.identity);
    }
}