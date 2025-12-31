using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;
using Arcade.Progression;
using HarmonyLib;
using UNBEATAP;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace unbeatAP.Patches
{
    public class HUDManager : MonoBehaviour
    {
        
        [HarmonyPatch(typeof(Arcade.UI.UISceneManager), "GetHUD")]
        [HarmonyPrefix]
        static bool GetHudPatch(ref bool __result)
            {
                if(!Plugin.Client.Connected)
                {
                    return true;
                }

                GameObject.Instantiate(Resources.Load("UI/Archipelago_Connected_UI.prefab"));
                return false;
             }
    }
}
