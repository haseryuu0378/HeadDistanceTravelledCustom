using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

namespace HeadDistanceTravelled
{
    internal class TextOutResultController
    {
        private static readonly string outPath = Path.Combine(Application.persistentDataPath, "HMDDistanceResult.txt");

        public static bool HiddenPlaying = false;
        private static bool HidenCallFlg = false;


        public static void TextOutResult(string TotalDistance, string PreDistance, string ResultFormat)
        {
            try {

                var text = string.Format(ResultFormat, TotalDistance, PreDistance);
                File.WriteAllText(outPath, text);
            }
            catch (Exception e) {
                Plugin.Log.Error(e);
            }

            HidenCallFlg = false;

        }
        public static void TextOutResultHiddenPlaying() {

            if (HidenCallFlg) 
            {
                return;
            }

            if (!HiddenPlaying) 
            {
                return;
            }

            try {
                File.WriteAllText(outPath, string.Empty);
            }
            catch (Exception e) {
                Plugin.Log.Error(e);
            }

            HidenCallFlg = true;

        }

        public static string TextOutResultCheck(string TotalDistance, string PreDistance, string ResultFormat)
        {
            return string.Format(ResultFormat, TotalDistance, PreDistance);
            
        }
        public static string GetTextOutOath()
        {
            return outPath;
        }

    }   
}
