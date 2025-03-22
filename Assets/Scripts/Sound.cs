using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource npcAudioSource;  // Composant AudioSource de l'NPC
    public AudioClip soundToPlay;       // Clip sonore � jouer
    public float detectionRadius = 5f;  // Rayon de d�tection pour jouer le son
    private Transform player;           // R�f�rence au joueur
    private bool hasPlayedSound = false; // Indicateur pour v�rifier si le son a �t� jou�

    private void Start()
    {
        // Trouver le joueur dans la sc�ne (assurez-vous que le joueur a le tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // S'assurer que AudioSource est d�fini
        if (npcAudioSource == null)
            npcAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Calculer la distance entre l'NPC et le joueur
        float distance = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans le rayon de d�tection et que le son n'a pas encore �t� jou�
        if (distance <= detectionRadius && !hasPlayedSound)
        {
            npcAudioSource.PlayOneShot(soundToPlay); // Jouer le son
            hasPlayedSound = true; // Marquer le son comme jou�
        }
        else if (distance > detectionRadius)
        {
            // R�initialiser l'indicateur si le joueur quitte la zone
            hasPlayedSound = false;
        }
    }
}
