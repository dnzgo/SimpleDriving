using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID

    private const string channelId = "notification_channel";

    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = channelId,
            Name = "Notification Channel",
            Description = "Some description",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification
        {
            Title = "Energy Charged!",
            Text = "Your energy charged! Come back to play again!",
            SmallIcon = "default",                                                // project settings -> mobile notifications -> android -> 
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);

    }
#endif
}
