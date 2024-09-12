﻿namespace Game.Runtime.Services.Analytics.Messages
{
    using Runtime;

    public class SceneIdleStartMessage : AnalyticsEventMessage
    {
        public int PlayerCoins
        {
            set
            {
                this[AnalyticsEventsNames.player_coins] = value.ToString();
                SetParameter(AnalyticsEventsNames.player_coins, value);
            } 
        }

        public SceneIdleStartMessage(string name) : base(name, name)
        {
        }
    }
}