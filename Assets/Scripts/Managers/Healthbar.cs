using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeartIcon;

public class Healthbar : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _prefabCorazon;

    private GameObject[] _corazones;

    private Transform _myTransform;
    #endregion

    #region properties

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _corazones = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            _corazones[i] = Instantiate(_corazones[i], _myTransform.position + Vector3.right * i, _myTransform.rotation);
        }
    }
}
