using UnityEngine;

public class Move : MonoBehaviour
{
    private IFollowTarget _move;
    [SerializeField] private Transform target;

    private void Awake()
    {
        _move = GetComponent<IFollowTarget>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _move.Follow(target);
    }

}
