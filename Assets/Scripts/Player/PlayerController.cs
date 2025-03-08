using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // 움직이는 속도
    private Vector2 curMoveInput; // 현재 입력받은 방향
    public float jumpForce; // 점프하는 힘
    public LayerMask groundCheck; // 공중에서 점프를 방지하기 위한 그라운드 레이어 감지

    public Transform cameraContainer; // 부착된 카메라 컨테이너에 따라 transform 값 할당
    public float minLook; // 최소시야
    public float maxLook; // 최대시야 
    private float camCurLook; // 현재 보는 값
    public float lookSensertivity; // 시야회전 속도

    private Vector2 mouseDelta;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMoveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMoveInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMoveInput.y + transform.right * curMoveInput.x;
        dir *= moveSpeed;
        dir.y = rigid.velocity.y;

        rigid.velocity = dir;
    }

    private void CameraLook()
    {
        camCurLook += mouseDelta.y * lookSensertivity;
        camCurLook = Mathf.Clamp(camCurLook, minLook, maxLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurLook, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensertivity, 0);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1.6f, groundCheck)) // 트랜스폼 위치에 따른 레이값 변경
            {
                Debug.Log("그라운드 쳌");
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * 2f, Color.magenta);
    }

    
}
