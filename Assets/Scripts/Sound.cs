using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource npcAudioSource;  // Composant AudioSource de l'NPC
    public AudioClip soundToPlay;       // Clip sonore à jouer
    public float detectionRadius = 5f;  // Rayon de détection pour jouer le son
    private Transform player;           // Référence au joueur
    private bool hasPlayedSound = false; // Indicateur pour vérifier si le son a été joué

    private void Start()
    {
        // Trouver le joueur dans la scène (assurez-vous que le joueur a le tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // S'assurer que AudioSource est défini
        if (npcAudioSource == null)
            npcAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Calculer la distance entre l'NPC et le joueur
        float distance = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans le rayon de détection et que le son n'a pas encore été joué
        if (distance <= detectionRadius && !hasPlayedSound)
        {
            npcAudioSource.PlayOneShot(soundToPlay); // Jouer le son
            hasPlayedSound = true; // Marquer le son comme joué
        }
        else if (distance > detectionRadius)
        {
            // Réinitialiser l'indicateur si le joueur quitte la zone
            hasPlayedSound = false;
        }
    }
}
