using UnityEngine;

public class npcReaction : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float waveDistance = 2f;  // Distance at which the NPC will wave
    public Animator npcAnimator;  // Reference to the NPC's Animator

    void Update()
    {
        // Check the distance between the NPC and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the waving distance, trigger the wave animation
        if (distanceToPlayer <= waveDistance)
        {
            // Trigger the wave animation
            npcAnimator.SetTrigger("waveTrigger");
        }
    }
}
