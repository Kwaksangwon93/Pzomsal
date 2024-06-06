using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;
    public float useStamina;

    public bool isZoomed = false;

    [Header("Arrow")]
    public GameObject arrowPrefab; // 화살
    public Transform arrowSpawnPoint; // 화살 생성 위치

    private Camera mainCamera;
    private float originalFOV = 60f;
    public float zoomedFOV = 30f;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        mainCamera = Camera.main;
        camera = mainCamera; // camera 변수를 mainCamera로 초기화합니다.
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public override void OnZoomInput(bool isZooming)
    {
        isZoomed = isZooming;

        animator.SetBool("Zoom", isZoomed);

        if (isZoomed) mainCamera.fieldOfView = zoomedFOV;
        else mainCamera.fieldOfView = originalFOV;
    }

    public float arrowSpeed = 10f;

    public void ShootArrow()
    {
        Vector3 cameraCenterDirection = mainCamera.transform.forward; // 카메라 정 중앙 방향 벡터

        GameObject arrowObject = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation); // 화살 생성

        arrowObject.transform.forward = cameraCenterDirection; // 화살 방향

        Rigidbody arrowRigidbody = arrowObject.GetComponent<Rigidbody>();

        arrowRigidbody.velocity = cameraCenterDirection.normalized * arrowSpeed; // 발사
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }

            if (doesDealDamage && hit.collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakePhysicalDamage(damage);
            }
        }
    }
}