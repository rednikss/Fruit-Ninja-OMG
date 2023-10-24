﻿using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.Data.Load;
using App.Scripts.Commands.Data.Types;
using App.Scripts.Commands.ExitGame;
using App.Scripts.Commands.LoadScene;
using App.Scripts.Commands.LoadScene.Scriptable;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Installers.Menu
{
    public class MenuPanelInstaller : MonoInitializable
    {
        [SerializeField] private GameObject menuPanel;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private Button playButton;
        
        [SerializeField] private Button exitButton;
        
        [Header("On Enable Work")]
        [SerializeField] private AnimatedCanvasMoveView transitionCanvasMove;
        
        [Header("Button Work Components")]
        [SerializeField] private SceneLoaderScriptable sceneScriptable;
        
        public override void Init()
        {
            highscoreView.Init();
            transitionCanvasMove.Init();
            
            playButton.onClick.AddListener(() =>
            {
                transitionCanvasMove.Show(() => new LoadSceneCommand(sceneScriptable.gameSceneName).Execute());
            });
            
            exitButton.onClick.AddListener(() =>
            {
                transitionCanvasMove.Show(() => new ExitGameCommand().Execute());
            });

            var command = new LoadDataCommand<PlayerRecords>("Records.json", "App", "Data");
            command.Execute();
            highscoreView.SetValue(command.Data.Highscore);
            
            ShowPanel();
            transitionCanvasMove.Hide();
        }

        public void ShowPanel()
        {
            menuPanel.SetActive(true);
        }
    }
}