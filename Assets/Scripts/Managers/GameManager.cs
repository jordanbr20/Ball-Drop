using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string steamUsername;
    public ulong steamID;
    public Texture2D avatarTexture;

    public List<Level> levelsUnlocked;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        GetSteamUserInfo();
    }

    public void GetSteamUserInfo()
    {
        steamUsername = SteamFriends.GetPersonaName();
        steamID = SteamUser.GetSteamID().m_SteamID;
        int avatarID = SteamFriends.GetLargeFriendAvatar(SteamUser.GetSteamID());

        if (avatarID != -1)
        {
            uint avatarWidth, avatarHeight;
            SteamUtils.GetImageSize(avatarID, out avatarWidth, out avatarHeight);
            
            byte[] avatarData = new byte[4 * (int)avatarWidth * (int)avatarHeight];
            SteamUtils.GetImageRGBA(avatarID, avatarData, 4 * (int)avatarWidth * (int)avatarHeight);

            avatarTexture = new Texture2D((int)avatarWidth, (int)avatarHeight, TextureFormat.RGBA32, false);
            avatarTexture.LoadRawTextureData(avatarData);
            avatarTexture.Apply();
        }
    }
}
