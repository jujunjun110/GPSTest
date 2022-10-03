using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class GPSManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeStampText;
    [SerializeField] private TextMeshProUGUI isEnabledText;
    [SerializeField] private TextMeshProUGUI isCompassEnabledText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI latText;
    [SerializeField] private TextMeshProUGUI lngText;
    [SerializeField] private TextMeshProUGUI headingText;

    void Start()
    {
        InvokeRepeating(nameof(UpdateDebugTexts), 1f, 1f);
    }

    void UpdateDebugTexts()
    {
        Input.location.Start();
        Input.compass.enabled = true;
        var dt = DateTime.Now;
        var isEnabled = Input.location.isEnabledByUser;
        var status = Input.location.status;
        var isCompassEnabled = Input.compass.enabled;

        timeStampText.SetText(dt.ToString(CultureInfo.CurrentCulture));
        isEnabledText.SetText($"IsEnabled: {isEnabled}");
        isCompassEnabledText.SetText($"IsCompassEnabled: {isCompassEnabled}");
        statusText.SetText($"Status: {status}");

        var latitude = Input.location.lastData.latitude;
        var longitude = Input.location.lastData.longitude;
        var heading = Input.compass.trueHeading;
        latText.SetText($"Latitude: {latitude}");
        lngText.SetText($"Longitude: {longitude}");
        headingText.SetText($"Heading: {heading}");
    }
}