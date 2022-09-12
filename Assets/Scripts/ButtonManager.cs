using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] Light2D globalLight;
    [SerializeField] GameObject lightrenderer;

    [SerializeField] bool decreaseLight;

    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;

    [SerializeField] GameObject soundsOnButton, soundsOffButton;
    [SerializeField] GameObject vibrationsOnButton, vibrationsOffButton;

    void Update()
    {
        GlobalLightControl();
    }
    public void MainScene()
    {
        soundManager.SlideScreen();
        camera.GetComponent<Animator>().SetBool("MoveMain", true);
        camera.GetComponent<Animator>().SetBool("MoveMainToLevel", false);
        camera.GetComponent<Animator>().SetBool("MoveMainToOptions", false);
        camera.GetComponent<Animator>().SetBool("MoveMainToPlay", false);

        decreaseLight = false;
        lightrenderer.SetActive(false);
    }
    public void LevelScene()
    {
        soundManager.SlideScreen();
        camera.GetComponent<Animator>().SetBool("MoveMainToLevel", true);
        camera.GetComponent<Animator>().SetBool("MoveMain", false);
    }
    public void OptionsScene()
    {
        soundManager.SlideScreen();
        camera.GetComponent<Animator>().SetBool("MoveMainToOptions", true);
        camera.GetComponent<Animator>().SetBool("MoveMain", false);
    }
    public void GamePlayScene()
    {
        soundManager.SlideScreen();
        camera.GetComponent<Animator>().SetBool("MoveMainToPlay", true);
        camera.GetComponent<Animator>().SetBool("MoveMain", false);

        decreaseLight = true;
        lightrenderer.SetActive(true);
    }
    private void GlobalLightControl()
    {
        if (decreaseLight && globalLight.intensity >= 0.13f)
        {
            ManageGlobalLightIntesity(false, true);
            camera.GetComponent<UnityEngine.Rendering.Volume>().enabled = true;
        }
        else if (!decreaseLight && globalLight.intensity <= 1)
        {
            ManageGlobalLightIntesity(true, false);
            camera.GetComponent<UnityEngine.Rendering.Volume>().enabled = false;
        }
    }
    private void ManageGlobalLightIntesity(bool increaseIntesity = false, bool decreaseIntensity = false)
    {
        if (decreaseIntensity)
        {
            globalLight.intensity -= .05f;
        }
        else if (increaseIntesity)
        {
            globalLight.intensity += .1f;
        }
    }
    public void Level1()
    {
        soundManager.ButtonSound();
        gameManager.currentLevel = 1;
    }
    public void Level2()
    {
        soundManager.ButtonSound();
        gameManager.currentLevel = 2;
    }
    public void Level3()
    {
        soundManager.ButtonSound();
        gameManager.currentLevel = 3;
    }
    public void SoundOff()
    {
        soundManager.ButtonSound();
        soundsOnButton.SetActive(true);
        soundsOffButton.SetActive(false);
        soundManager.GetComponent<AudioSource>().Stop();
    }
    public void SoundOn()
    {
        soundManager.ButtonSound();
        soundsOnButton.SetActive(false);
        soundsOffButton.SetActive(true);
        soundManager.GetComponent<AudioSource>().Play();
    }
    public void VibrationdOff()
    {
        soundManager.ButtonSound();
        vibrationsOnButton.SetActive(true);
        vibrationsOffButton.SetActive(false);
        Handheld.Vibrate();
    }
    public void VibrationdOn()
    {
        soundManager.ButtonSound();
        vibrationsOnButton.SetActive(false);
        vibrationsOffButton.SetActive(true);
    }
}