using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace NicePlayTestTask.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        private const string DefaultColor        = "#e3e3e3";
        private const string InfrastructureColor = "#e38d46";
        private const string ServicesColor       = "#46e372";
        private const string MetaColor           = "#e346b4";
        private const string GameplayColor       = "#4697e3";
        
        public void LogMessage(string message, object sender = null) =>
            Debug.Log(GetString(message, sender ?? this));

        public void LogWarning(string message, object sender = null) =>
            Debug.LogWarning(GetString(message, sender ?? this));

        public void LogError(string message, object sender = null) =>
            Debug.LogError(GetString(message, sender ?? this));

        private static string GetString(string message, object sender) =>
            $"<b><color={GetHexColor(sender.GetType())}>{sender.GetType().Name}:</color></b> {message}";

        private static string GetHexColor(Type sender) =>
            sender.Namespace switch
            {
                var x when Regex.IsMatch(x, @".*Infrastructure.*") => InfrastructureColor,
                var x when Regex.IsMatch(x, @".*Meta.*")           => MetaColor,
                var x when Regex.IsMatch(x, @".*Services.*")       => ServicesColor,
                var x when Regex.IsMatch(x, @".*Gameplay.*")       => GameplayColor,
                _                                                                  => DefaultColor
            };
    }
}