using UnityEngine;

public class U31AnimationEventProxy : MonoBehaviour
{
	public GameObject target;

    public void OnAnimationEvent(string eventname)
    {
		if (target == null)
			return;

		target.SendMessage("OnAnimationEvent", eventname);
    }
}
