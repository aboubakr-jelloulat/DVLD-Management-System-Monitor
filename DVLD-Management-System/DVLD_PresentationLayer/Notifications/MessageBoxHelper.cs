using System;
using Guna.UI2.WinForms;

namespace DVLD_PresentationLayer.Notifications
{


    internal static class clsMessageBoxHelper
    {
        public static void ShowMessage(string title, string message, MessageDialogIcon icon = MessageDialogIcon.Information)
        {
            var msg = new Guna2MessageDialog
            {
                Caption = title,
                Text = message,
                Icon = icon,
                Buttons = MessageDialogButtons.OK,
                Style = MessageDialogStyle.Dark
            };


            msg.Show();
        }

        public static void ShowError(string title, string message)
            => ShowMessage(title, message, MessageDialogIcon.Error);

        public static void ShowWarning(string title, string message)
            => ShowMessage(title, message, MessageDialogIcon.Warning);

        public static void ShowInfo(string title, string message)
            => ShowMessage(title, message, MessageDialogIcon.Information);

        public static void ShowSuccess(string title, string message)
            => ShowMessage(title, message, MessageDialogIcon.None);
    }

}

