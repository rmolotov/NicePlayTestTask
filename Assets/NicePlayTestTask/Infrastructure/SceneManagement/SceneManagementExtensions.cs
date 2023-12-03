using System;

namespace NicePlayTestTask.Infrastructure.SceneManagement
{
    public static class SceneManagementExtensions
    {
        public static SceneName ToSceneName(this string sceneName) =>
            sceneName switch
            {
                "Bootstrap" => SceneName.Bootstrap,
                "Meta"      => SceneName.Meta,
                "Core"      => SceneName.Core,
                _           => throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null)
            };

        public static string ToSceneString(this SceneName sceneName) =>
            sceneName switch
            {
                SceneName.Bootstrap => "Bootstrap",
                SceneName.Meta      => "Meta",
                SceneName.Core      => "Core",
                _                   => throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null)
            };

        public static bool IsGamePlayScene(this SceneName sceneName) =>
            sceneName
                is SceneName.Core;
    }
}