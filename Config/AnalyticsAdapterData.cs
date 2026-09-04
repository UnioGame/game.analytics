namespace UniGame.Runtime.Analytics.Runtime
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using UnityEngine;

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, sourceNamespace: "Game.Runtime.Services.Analytics.Runtime", sourceAssembly: "game.service.analytics", sourceClassName: "AnalyticsAdapterData")]
    [Serializable]
    public class AnalyticsAdapterData
    {
        public string name;
        public bool isEnabled = true;
        public List<string> enabledPlatforms = new();
        public List<string> disabledPlatforms = new();
        [SerializeReference]
        public IAnalyticsAdapter adapter;

        public bool IsPlatformAllowed(string platformId)
        {
            return AnalyticsPlatformPolicy.IsPlatformAllowed(platformId, enabledPlatforms, disabledPlatforms);
        }
    }
}