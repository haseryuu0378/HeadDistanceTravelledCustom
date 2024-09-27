using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace HeadDistanceTravelled.Jsons
{
    internal class CustomConfig
    {

        private  static readonly string configurationFile = Path.Combine(Application.dataPath, @"..\UserData\HeadDistanceTravelledCustom.json");
        public ConfigData ConfData = new ConfigData();

        public CustomConfig():this(DateTime.Now)
        {
        }

        public CustomConfig(DateTime dateDt) {

            if (File.Exists(configurationFile)) {
                string jsonData = File.ReadAllText(configurationFile);
                ConfData = JsonConvert.DeserializeObject<ConfigData>(jsonData);

                var jsonWriteData = JsonConvert.SerializeObject(ConfData, Formatting.Indented);
                File.WriteAllText(configurationFile, jsonWriteData);

                if (ConfData.StartDt is null) {
                    ConfData.StartDt = dateDt;
                }
            }
            else 
            {
                ConfData.StartDt = null;
                ConfData.ResultFormat = "前プレイの距離：{1}m　今回の総距離：{0}m";
                ConfData.HDTPosFix = false;
                ConfData.HDTPosX = 0;
                ConfData.HDTPosY = 0.1f;
                ConfData.HDTPosZ = 1.2f;
                ConfData.HiddenPlaying = false;
                var jsonWriteData = JsonConvert.SerializeObject(ConfData ,Formatting.Indented);
                File.WriteAllText(configurationFile, jsonWriteData);

                ConfData.StartDt = dateDt;
            }


        }

        [JsonObject("ConfigData")]
        public class ConfigData
        {
            [JsonProperty("StartDt")]
            public DateTime? StartDt { get; set; }

            [JsonProperty("ResultFormat")]
            public string ResultFormat { get; set; }

            [JsonProperty("HiddenPlaying")]
            public bool HiddenPlaying { get; set; }

            [JsonProperty("HDTPosFix")]
            public bool HDTPosFix { get; set; }

            [JsonProperty("HDTPosX")]
            public float HDTPosX { get; set; }

            [JsonProperty("HDTPosY")]
            public float HDTPosY { get; set; }

            [JsonProperty("HDTPosZ")]
            public float HDTPosZ { get; set; }



        }

    }
}
