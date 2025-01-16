using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMove : MonoBehaviour
{
    #region Input Actions
    [SerializeField]
    private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;
        set => _actions = value;
    }

    protected InputAction rightClickPressedInputAction { get; set; }

    protected InputAction mouseLookInputAction { get; set; }

    #endregion

    #region Variables

    private bool _rotateAllowed;

    private Camera _camera;

    [SerializeField] private float _speed;

    [SerializeField] private bool _inverted;

    [SerializeField] private bool _lock;

    #endregion

    private void Awake()
    {
        InitializeInputSystem();
    }

    private void Start()
    {
        if(_lock)
            Cursor.lockState = CursorLockMode.Locked;
        _camera = Camera.main;

    }

    private void InitializeInputSystem()
    {
        rightClickPressedInputAction = actions.FindAction("rightClick");
        if (rightClickPressedInputAction != null)
        {
            rightClickPressedInputAction.started += OnrightClickPressed;
            rightClickPressedInputAction.performed += OnrightClickPressed;
            rightClickPressedInputAction.canceled += OnrightClickPressed;
        }

        mouseLookInputAction = actions.FindAction("MouseLook");

        actions.Enable();
    }

    protected virtual void OnrightClickPressed(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _rotateAllowed = true;
        }
        else if (context.canceled)
        {
            _rotateAllowed = false;
        }
    }


    protected virtual Vector2 GetMouseLookInput()
    {
        Vector2 mouseInput = mouseLookInputAction != null ? mouseLookInputAction.ReadValue<Vector2>() : Vector2.zero;
        return mouseInput;
    }

    private void Update()
    {
        if (!_rotateAllowed)
            return;

        Vector2 MouseDelta = GetMouseLookInput();

        MouseDelta *= _speed * Time.deltaTime;

        transform.Rotate(Vector3.up * (_inverted ? 1 : -1), MouseDelta.x, Space.World);
        transform.Rotate(Vector3.right * (_inverted ? -1 : 1), MouseDelta.y, Space.World);
    }
}
