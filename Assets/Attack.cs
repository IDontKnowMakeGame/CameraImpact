using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _playableDiretor;
    [SerializeField]
    private GameObject _impact;
    [SerializeField]
    private Transform _pos;

    private Animator _ani;

    private readonly int _AttackHash = Animator.StringToHash("Attack");
    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            _ani.SetTrigger(_AttackHash);
        }
    }

    public void ActionStart()
    {
        _playableDiretor.Play();
        Instantiate(_impact, _pos);
    }
}
