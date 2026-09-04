namespace UniGame.Runtime.Analytics.Adapters
{
    using System;
    using Cysharp.Threading.Tasks;
    using Interfaces;
    using Unity.Services.Core;

#if ANALYTICS_UNITY

    using Unity.Services.Analytics;

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, sourceNamespace: "Game.Runtime.Services.Analytics.Adapters.UnityAnalytics", sourceAssembly: "game.analytics.adapter.unity", sourceClassName: "UnityAnalyticsHandler")]
    [Serializable]
    public class UnityAnalyticsHandler : IAnalyticsAdapter
    {
        public async UniTask InitializeAsync()
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();
        }

        public void TrackEvent(IAnalyticsMessage message)
        {
            var unityEvent = new UnityEventMessage(message.Name);
            foreach (var parameter in message.Parameters)
                unityEvent[parameter.Key] = parameter.Value;
            
            AnalyticsService.Instance.RecordEvent(unityEvent);
        }

        public void Dispose()
        {
            
        }
    }

#else

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, sourceNamespace: "Game.Runtime.Services.Analytics.Adapters.UnityAnalytics", sourceAssembly: "game.analytics.adapter.unity", sourceClassName: "UnityAnalyticsHandler")]
    [Serializable]
    public class UnityAnalyticsHandler : IAnalyticsAdapter
    {
        public void Dispose()
        {
            
        }

        public UniTask InitializeAsync()
        {
            return UniTask.CompletedTask;
        }

        public void TrackEvent(IAnalyticsMessage message)
        {
            
        }
    }
#endif    
}