using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�̺�Ʈ ����
        EventManager.Instance.AddListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }

    private void OnDestroy()
    {
        //��ü�� ������ �� �����ϴ� �Լ�
        EventManager.Instance.RemoveListener("PlyaerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.RemoveListener("PlyaerHealthDied", OnPlayerDied);
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI ������Ʈ : �÷��̾ ����߽��ϴ�.");
        //���� ���� ȭ�� ǥ�� ���� ����
    }

    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI ������Ʈ : �÷��̾��� ü���� {health}�� ����Ǿ����ϴ�.");
        //�����δ� ���⼭ UI��Ҹ� ������Ʈ �Ѵ�.

    }
}
