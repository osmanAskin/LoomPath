using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioClip[] musicTracks; // Müziğin sıralı tutulduğu bir dizi
    public int[] changeScenes = {2,6,10,14}; // Müziğin değişmesi gereken sahne indeksleri
    private AudioSource audioSource;

    private int currentTrackIndex = -1; // Şu anda çalmakta olan müziğin indeksini tutar

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Eğer başka bir MusicManager varsa bu objeyi yok et
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        HandleMusic(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HandleMusic(scene.buildIndex);
    }

    private void HandleMusic(int sceneIndex)
    {
        // Sahne indeksinin değişmesi gereken sahne listesinde olup olmadığını kontrol edin
        for (int i = 0; i < changeScenes.Length; i++)
        {
            if (sceneIndex == changeScenes[i] && currentTrackIndex != i)
            {
                ChangeMusic(i);
                return;
            }
        }
    }

    private void ChangeMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= musicTracks.Length) return;

        currentTrackIndex = trackIndex; // Şu anki müzik indeksini güncelle
        audioSource.Stop();
        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();
    }
}