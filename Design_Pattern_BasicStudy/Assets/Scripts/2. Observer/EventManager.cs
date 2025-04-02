using System;
using System.Collections.Generic;
using UnityEngine;

//�̺�Ʈ ������(Subject)
public class EventManager : MonoBehaviour
{
    //������ ������ ��ü �� �ϴ�� �������� �����ϸ�, �� ��ü�� ���°� ����Ǹ�
    //�����ϴ� ��� ��ü�� �뺸�Ͽ� �ڵ����� ������Ʈ�Ǵ� ����̴�.


    //�̱��� ����
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                _instance = go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    //�̺�Ʈ�� �������� �����ϴ� ��ųʸ�
    private Dictionary<string, Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    //�̺�Ʈ�� ������ �߰�
    public void AddListener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = thisEvent;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    //�̺�Ʈ���� ������ ����
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;

        }
    }

    //�̺�Ʈ �߻� (��� ���������� �˸�)
    public void TriggerEvent(string eventName, object data = null)
    {
        if(_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
