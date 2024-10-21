using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip draw_card;
    public AudioClip ingame_project_demo;
    public AudioClip menu_click_confirm;
    public AudioClip menu_click_return;
    public AudioClip playing_cards_on_the_table;
    public AudioClip victory_option_2;
    public AudioClip screen_transiction;
    public AudioClip game_over;

    private void Start()
    {
        musicSource.clip = ingame_project_demo;
        musicSource.Play();
    }
}
