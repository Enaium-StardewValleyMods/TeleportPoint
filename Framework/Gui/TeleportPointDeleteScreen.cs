﻿using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;

namespace TeleportPoint.Framework.Gui
{
    public class TeleportPointDeleteScreen : ScreenGui
    {
        public TeleportPointDeleteScreen()
        {
            AddElement(new Label(ModEntry.GetTranslation("teleportPoint.label.teleportPointList"),
                ModEntry.GetTranslation("teleportPoint.label.teleportPointList")));

            foreach (var variable in ModEntry.Config.TeleportData)
            {
                Button delete = new Button($"{ModEntry.GetTranslation("teleportPoint.button.delete")}:{variable.Name}",
                    $"{ModEntry.GetTranslation("teleportPoint.button.delete")}:{variable.Name}");
                delete.OnLeftClicked = () =>
                {
                    ModEntry.Config.TeleportData.Remove(variable);
                    RemoveElement(delete);
                };
                AddElement(delete);
            }
        }
    }
}