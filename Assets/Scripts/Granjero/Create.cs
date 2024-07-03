//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Create : MonoBehaviour
{
    [SerializeField] private GameObject trampoline;
    [SerializeField] private GameObject decoy;
    private Transform _transform;
    private PlayerAnimationController _animationController;
    private GranjeroMovement _playerMovement;
    private LanzaObjeto _lanzaObjeto;
    private Player_Raycast _myRC;

    private bool _canUseTrampoline = false;
    private bool _canUseDecoy = false;
    private float _horizontalOffset;

    private void Start()
    {
        _transform = transform;
        _playerMovement = GetComponent<GranjeroMovement>();
        _animationController = GetComponent<PlayerAnimationController>();
        _lanzaObjeto = GetComponent<LanzaObjeto>();
        _myRC = GetComponent<Player_Raycast>();
    }

    private void OnAction2()
    {
        if (_canUseTrampoline && GameManager.Instance.ObtenerCuerdas() > 0 && _myRC.ChoqueAbajo)
        {
            _animationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_myRC.ChoqueIzq)
            {
                spawnPos = new Vector2(_transform.position.x - _horizontalOffset, _transform.position.y);
                GameObject trampolin = Instantiate(trampoline, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
            else if (_playerMovement.Movement().x >= 0 && !_myRC.ChoqueDer)
            {
                spawnPos = new Vector2(_transform.position.x + _horizontalOffset, _transform.position.y);
                GameObject trampolin = Instantiate(trampoline, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
        }
    }

    private void OnAction3()
    {
        if (_canUseDecoy && GameManager.Instance.ObtenerCuerdas() > 0 && _myRC.ChoqueAbajo)
        {
            _animationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_myRC.ChoqueIzq)
            {
                spawnPos = new Vector2(_transform.position.x - _horizontalOffset, _transform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(decoy, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
            else if (_playerMovement.Movement().x >= 0 && !_myRC.ChoqueDer)
            {
                spawnPos = new Vector2(_transform.position.x + _horizontalOffset, _transform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(decoy, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
        }
    }

    public void ActivateTrampoline()
    {
        _canUseTrampoline = true;
    }

    public void ActivateDecoy()
    {
        _canUseDecoy = true;
    }
}
