using System;
using System.Collections.Generic;
using UnityEngine;

public static class Progress
{
    public static string DefaultWeaponsBought;
    public static string DefaultWeaponsSelected;

    readonly static string weaponsSelected = nameof(weaponsSelected);
    readonly static string weaponsBought = nameof(weaponsBought);
    readonly static string money = nameof(money);
    readonly static string level = nameof(level);
    readonly static string battlePass = nameof(battlePass);
    readonly static string grenades = nameof(grenades);
    readonly static string superGrenades = nameof(superGrenades);
    readonly static string sensitivity = nameof(sensitivity);
    readonly static string soundVolume = nameof(soundVolume);
    readonly static string musicVolume = nameof(musicVolume);

    public static void SaveWeaponsSelected(WeaponsSelected weapons)
    {
        Debug.Log(weapons);
        Debug.Log(JsonUtility.ToJson(weapons));

        GSPrefs.SetString(weaponsSelected, JsonUtility.ToJson(weapons).ToString());
        GSPrefs.Save();
    }

    public static WeaponsSelected LoadWeaponsSelected()
    {
        Debug.Log(GSPrefs.GetString(weaponsSelected, DefaultWeaponsSelected));

        return JsonUtility.FromJson<WeaponsSelected>(GSPrefs.GetString(weaponsSelected, DefaultWeaponsSelected));
    }

    public static void SaveWeaponsBought(WeaponsBought weapons)
    {
        Debug.Log(weapons);
        Debug.Log(JsonUtility.ToJson(weapons));

        GSPrefs.SetString(weaponsBought, JsonUtility.ToJson(weapons).ToString());
        GSPrefs.Save();
    }

    public static WeaponsBought LoadWeaponsBought()
    {
        Debug.Log(GSPrefs.GetString(weaponsBought, DefaultWeaponsBought));

        return JsonUtility.FromJson<WeaponsBought>(GSPrefs.GetString(weaponsBought, DefaultWeaponsBought));
    }

    public static void SaveMoney(int value)
    {
        GSPrefs.SetInt(money, value);
        GSPrefs.Save();
    }

    public static int LoadMoney()
    {
        return GSPrefs.GetInt(money, 0);
    }

    public static void SaveLevel(int value)
    {
        GSPrefs.SetInt(level, value);
        GSPrefs.Save();
    }

    public static int LoadLevel()
    {
        return GSPrefs.GetInt(level, 1);
    }

    public static void SaveBattlePass()
    {
        GSPrefs.SetInt(battlePass, 1);
        GSPrefs.Save();
    }

    public static bool LoadBattlePass()
    {
        return GSPrefs.GetInt(battlePass, 0) == 1;
    }

    public static void SaveGrenades(int value)
    {
        GSPrefs.SetInt(grenades, value);
        GSPrefs.Save();
    }

    public static int LoadGrenades()
    {
        return GSPrefs.GetInt(grenades, 0);
    }
    
    public static void SaveSuperGrenades(int value)
    {
        GSPrefs.SetInt(superGrenades, value);
        GSPrefs.Save();
    }

    public static int LoadSuperGrenades()
    {
        return GSPrefs.GetInt(superGrenades, 1);
    }

    public static void SaveSensitivity(float value)
    {
        PlayerPrefs.SetFloat(sensitivity, value);
    }

    public static float LoadSensitivity()
    {
        return PlayerPrefs.GetFloat(sensitivity, 1);
    }

    public static void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat(soundVolume, value);
    }

    public static float LoadVolume()
    {
        return PlayerPrefs.GetFloat(soundVolume, 1);
    }

    public static void SaveMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(musicVolume, value);
    }

    public static float LoadMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolume, 1);
    }

    [Serializable]
    public class WeaponsSelected
    {
        public TFG.Generic.Dictionary<string, WeaponAttachmentSelected> WeaponsAttachmentsSelected;
    }

    [Serializable]
    public class WeaponAttachmentSelected
    {
        public int ScopeIndex;
        public int MuzzleIndex;
        public int LaserIndex;
        public int GripIndex;
    }

    [Serializable]
    public class WeaponsBought
    {
        public TFG.Generic.Dictionary<string, WeaponAttachmentsBought> WeaponsAttachmentsBought;
    }

    [Serializable]
    public class WeaponAttachmentsBought
    {
        public bool IsBoughtWeapon;
        public List<int> ScopeIndex;
        public List<int> MuzzleIndex;
        public List<int> LaserIndex;
        public List<int> GripIndex;
        public int AmmunitionSum;
    }
}