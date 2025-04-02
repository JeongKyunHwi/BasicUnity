using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //이벤트 구독
        EventManager.Instance.AddListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }

    private void OnDestroy()
    {
        //객체가 삭제될 때 동작하는 함수
        EventManager.Instance.RemoveListener("PlyaerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.RemoveListener("PlyaerHealthDied", OnPlayerDied);
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI 업데이트 : 플레이어가 사망했습니다.");
        //게임 오버 화면 표시 동작 수행
    }

    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI 업데이트 : 플레이어의 체력이 {health}로 변경되었습니다.");
        //실제로는 여기서 UI요소를 업데이트 한다.

    }
}
