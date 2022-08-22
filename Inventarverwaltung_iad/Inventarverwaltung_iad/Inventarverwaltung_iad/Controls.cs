using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Dise Klasse wird dazu verwendet Kontrollelemente für die Veränderung von Inventar zu erstellen, es wird ein Stacklayout zurückgegeben.
    /// </summary>

    public class Controls
    {
        private StackLayout controls = new StackLayout();
        private Button position = new Button();
        private Button raum = new Button();
        private Button delete = new Button();
        private ScrollView content;
        public string inventarnummer { get; set; }
        public Controls(ScrollView content,string inventarnummer)
        {
            this.content = content;
            this.inventarnummer = inventarnummer;
            position.Text = "Position ändern";
            raum.Text = "Raum ändern";
            delete.Text = "Löschen";
            controls.Children.Add(position);
            controls.Children.Add(raum);
            controls.Children.Add(delete);

            position.Clicked += Position_Clicked;
            raum.Clicked += Raum_Clicked;
            delete.Clicked += Delete_Clicked;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.Confirm(new ConfirmConfig
            {
                Message = "Wirklich löschen ?",
                OkText = "Ja",
                CancelText = "Nein",
                OnAction = (x) =>
                {
                    if (x)
                    {
                        SqlCon.sqlConnection.Open();
                        SqlCon.command = new SqlCommand("exec dbo.deleteObject @invid", SqlCon.sqlConnection);
                        SqlCon.command.Parameters.Add(new SqlParameter("invid", inventarnummer));
                        SqlCon.command.ExecuteNonQuery();
                        SqlCon.sqlConnection.Close();
                        content.Content = null;
                    }
                }
            });
        }

        private void Raum_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.Prompt(new PromptConfig
            {
                Message = "Raum ändern:",
                Placeholder = "Raum",
                OnAction = (x) =>
                {

                    if ( x.Ok)
                    {
                        SqlCon.sqlConnection.Open();
                        SqlCon.command = new SqlCommand("exec dbo.updateRaum @invid,@raum", SqlCon.sqlConnection);
                        SqlCon.command.Parameters.Add(new SqlParameter("invid", inventarnummer));
                        SqlCon.command.Parameters.Add(new SqlParameter("raum", x.Value));
                        SqlCon.command.ExecuteNonQuery();
                        SqlCon.sqlConnection.Close();
                        content.Content = new Objekt(inventarnummer).getObjekt();
                    }
                },
            });
        }

        private void Position_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.Prompt(new PromptConfig
            {
                Message = "Position ändern:",
                Placeholder = "Position",
                InputType = InputType.Phone,
                OnAction = (x) =>
                {
                    if (x.Ok && x.Value != "")
                    {
                        SqlCon.sqlConnection.Open();
                        SqlCon.command = new SqlCommand("exec dbo.updatePos @invid,@pos", SqlCon.sqlConnection);
                        SqlCon.command.Parameters.Add(new SqlParameter("invid", inventarnummer));
                        SqlCon.command.Parameters.Add(new SqlParameter("pos", x.Value));
                        SqlCon.command.ExecuteNonQuery();
                        SqlCon.sqlConnection.Close();
                        content.Content = new Objekt(inventarnummer).getObjekt();
                    }

                },

            });
        }

        public StackLayout getControls()
        {
            return controls;
        }
    }

}
