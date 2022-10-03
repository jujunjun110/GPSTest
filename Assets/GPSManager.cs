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
    [SerializeField] private TextMeshProUGUI trueHeadingText;
    [SerializeField] private TextMeshProUGUI magneticHeadingText;
    [SerializeField] private TextMeshProUGUI errorMessage;

    void Start()
    {
        InvokeRepeating(nameof(UpdateDebugTexts), 1f, 1f);
    }

    void UpdateDebugTexts()
    {
        try
        {
            Input.location.Start();
            Input.compass.enabled = true;

            var dt = DateTime.Now;
            var status = Input.location.status;
            var isEnabled = Input.location.isEnabledByUser;
            var isCompassEnabled = Input.compass.enabled;

            // var latitude = Input.location.lastData.latitude;
            // var longitude = Input.location.lastData.longitude;

            var lastData = Input.location.lastData;
            System.Globalization.CultureInfo invariantCulture = System.Globalization.CultureInfo.InvariantCulture;
            double latitude = double.Parse(lastData.latitude.ToString("R", invariantCulture), invariantCulture);
            double longitude = double.Parse(lastData.longitude.ToString("R", invariantCulture), invariantCulture);

            var trueHeading = Input.compass.trueHeading;
            var magneticHeading = Input.compass.magneticHeading;

            timeStampText.SetText(dt.ToString(CultureInfo.CurrentCulture));
            isEnabledText.SetText($"IsEnabled: {isEnabled}");
            isCompassEnabledText.SetText($"IsCompassEnabled: {isCompassEnabled}");
            statusText.SetText($"Status: {status}");

            latText.SetText($"Latitude: {latitude}");
            lngText.SetText($"Longitude: {longitude}");
            trueHeadingText.SetText($"Heading: {trueHeading}");
            magneticHeadingText.SetText($"Heading: {magneticHeading}");
            errorMessage.SetText($"Error: No Error");
        }
        catch (Exception e)
        {
            errorMessage.SetText($"Error: {e.Message}");
        }
    }
}