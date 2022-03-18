using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private SpecialCube _specialCubePrefab;

    [SerializeField]
    private float _cubeSpeed = 10;

    [SerializeField]
    private float _cubeDeathDistance = 10;

    [SerializeField]
    private float _spawnCubeDelay = 5;

    [SerializeField]
    private TMP_InputField _speedIF;

    [SerializeField]
    private TMP_InputField _distanceIF;

    [SerializeField]
    private TMP_InputField _spawnTimeIF;

    private IEnumerator Spawner() {

        while (true) {

            yield return new WaitForSeconds(_spawnCubeDelay);

            if (_specialCubePrefab != null)
            {
                SpecialCube specialCube = Instantiate(_specialCubePrefab, transform.position, Quaternion.identity);
                specialCube.SetData(_cubeSpeed, _cubeDeathDistance);
            }
        }
        

    }

    public void SetSpeed() {
        _cubeSpeed = float.Parse(_speedIF.text);
    }

    public void SetDistance() {
        _cubeDeathDistance = float.Parse(_distanceIF.text);
    }

    public void SetSpawnDelay() {
        _spawnCubeDelay = float.Parse(_spawnTimeIF.text);
    }

    private void Awake()
    {  
        StartCoroutine(Spawner());
    }

}
