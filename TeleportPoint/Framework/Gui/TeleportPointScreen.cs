﻿using System.Collections.Generic;
using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;

namespace TeleportPoint.Framework.Gui
{
    public class TeleportPointScreen : ScreenGui
    {
        public TeleportPointScreen()
        {
            AddElement(new Button(ModEntry.GetTranslation("teleportPoint.button.record"),
                ModEntry.GetTranslation("teleportPoint.button.record"))
            {
                OnLeftClicked = () =>
                {
                    Game1.activeClickableMenu =
                        new NamingScreen(name =>
                            {
                                ModEntry.Config.TeleportData.Add(new TeleportData(name,
                                    Game1.player.currentLocation.Name,
                                    Game1.player.Tile.X, Game1.player.Tile.Y));
                                ModEntry.ConfigReload();
                                Game1.exitActiveMenu();
                            },
                            ModEntry.GetTranslation("teleportPoint.title.naming"));
                }
            });
            AddElement(new Button($"{ModEntry.GetTranslation("teleportPoint.button.teleport")}",
                $"{ModEntry.GetTranslation("teleportPoint.button.teleport")}")
            {
                OnLeftClicked = () => { Game1.activeClickableMenu = new TeleportPointTeleportScreen(); }
            });

            AddElement(new Button($"{ModEntry.GetTranslation("teleportPoint.button.delete")}",
                $"{ModEntry.GetTranslation("teleportPoint.button.delete")}")
            {
                OnLeftClicked = () => { Game1.activeClickableMenu = new TeleportPointDeleteScreen(); }
            });
        }
    }
}