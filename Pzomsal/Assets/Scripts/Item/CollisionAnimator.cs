using UnityEngine;

public class CollisionAnimator : MonoBehaviour
{
    public Animator animator;  // 애니메이터 컴포넌트를 참조
    public string boolName = "isTriggered"; // 불리언 파라미터 이름
    public int playerLayer; // 플레이어 레이어 번호

    void Start()
    {
        // 플레이어 레이어 설정 (이름을 통해 가져오기)
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer) // 충돌한 오브젝트가 플레이어 레이어일 때
        {
            animator.SetBool(boolName, true); // 불리언 값을 true로 설정하여 애니메이션 실행
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer) // 충돌한 오브젝트가 플레이어 레이어일 때
        {
            animator.SetBool(boolName, false); // 불리언 값을 false로 설정하여 애니메이션 종료
        }
    }
}
