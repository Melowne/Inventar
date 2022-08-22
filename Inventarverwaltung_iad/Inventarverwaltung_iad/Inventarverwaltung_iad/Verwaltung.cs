 
 using System;
 using System.Data.SqlClient;
 using Xamarin.Forms;
 
 namespace Inventarverwaltung_iad
 {
     /// <summary>
     /// Dise Klasse wird dazu verwendet die ein Staklayout mit Verwaltungsinhalten zu erstellen.
     /// </summary>
 
     public class Verwaltung
     {
         private StackLayout root = new StackLayout();
         private Frame frame = new Frame();
         private StackLayout picker_ort_obj = new StackLayout();
         private Picker objekt = new Picker(), orte = new Picker();
         private Button auswahl = new Button();
         private Picker auswahlraum = new Picker();
         private Button raumerfassen = new Button();
         private ScrollView content = new ScrollView();
         private string[] eigenschaften = new string[] { "Name", "Position", "Raum", "Infos" };
         private Grid headergrid = new Grid();
         private Grid grid;
 
         private StackLayout controls;
         private string inventarnummer;
         private Controls ctrl;
         public Verwaltung()
         {
             ctrl = new Controls(content, inventarnummer);
             controls = ctrl.getControls();
             //Frame Überschrift
             frame.BackgroundColor = Color.FromHex("#fe0000"); frame.Padding = 24; frame.CornerRadius = 0;
             frame.Content = new Label
             {
                 Text = "Inventarverwaltung IAD",
                 HorizontalTextAlignment = TextAlignment.Center,
                 TextColor = Color.White,
                 FontSize = 36
             };
             root.Children.Add(frame);
             //picker Standorte und Kategorieobjekte
             try
             {
                 objekt.Title = "Kategorie"; orte.Title = "Standort";
                 objekt.HorizontalOptions = LayoutOptions.FillAndExpand;
                 orte.HorizontalOptions = LayoutOptions.FillAndExpand;
 
                 //orte
                 SqlCon.sqlConnection.Open();
                 SqlCon.command = new SqlCommand("exec dbo.getOrte", SqlCon.sqlConnection);
                 SqlCon.reader = SqlCon.command.ExecuteReader();
                 while (SqlCon.reader.Read())
                 {
                     orte.Items.Add(SqlCon.reader["Standortname"].ToString());
                 }
                 SqlCon.reader.Close();
                 //Kategorien
                 SqlCon.command = new SqlCommand("exec dbo.getObjekte", SqlCon.sqlConnection);
                 SqlCon.reader = SqlCon.command.ExecuteReader();
                 while (SqlCon.reader.Read())
                 {   
                     objekt.Items.Add(SqlCon.reader["Bezeichnung"].ToString());
                 }
                 SqlCon.reader.Close();
 
                 //button auswahl
                 auswahl.Text = "Auswahl"; auswahl.BackgroundColor = Color.FromHex("#fe0000");
                 auswahl.TextColor = Color.White;
 
                 //button raum
                 raumerfassen.Text = "Raum auswählen";
                 raumerfassen.BackgroundColor = Color.FromHex("#fe0000"); 
                 raumerfassen.TextColor = Color.White;
 
                 //elemente root hinzufügen
                 picker_ort_obj.Orientation = StackOrientation.Horizontal;
                 picker_ort_obj.Children.Add(objekt); picker_ort_obj.Children.Add(orte);
                 root.Children.Add(picker_ort_obj);
                 root.Children.Add(auswahl);
 
 
 
                 auswahl.Clicked += Auswahl_Clicked;
 
                 SqlCon.sqlConnection.Close();
 
             }
             catch (Exception)
             {
 
                 SqlCon.reader.Close();
                 SqlCon.sqlConnection.Close();
             }
             
             //headergrid erstellen
             headergrid.BackgroundColor = Color.Black;
             headergrid.ColumnSpacing = 1; headergrid.RowSpacing = 1.5;
             headergrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
             for (int i = 0; i < eigenschaften.Length; i++)
             {
                 headergrid.ColumnDefinitions.Add(new ColumnDefinition
                 {
                     Width = new GridLength(1, GridUnitType.Star),
                 });
                 headergrid.Children.Add(new Label
                 {
                     Text = eigenschaften[i],
                     FontAttributes = FontAttributes.Bold,
                     HorizontalOptions = LayoutOptions.FillAndExpand,
                     FontSize = 16,
                     BackgroundColor = Color.White,
                     HorizontalTextAlignment = TextAlignment.Center,
                     VerticalTextAlignment = TextAlignment.Center
 
                 }, i, 0);
             }
 
         }
        
         //Content-Klick-Events
         private void Auswahl_Clicked(object sender, EventArgs e)
         {
             try
             {
                 SqlCon.sqlConnection.Open();
                 SqlCon.command = new SqlCommand("exec dbo.getRaum " + orte.SelectedItem.ToString(), SqlCon.sqlConnection); 
                 auswahlraum.Items.Clear();
                 auswahlraum.Title = "Raum";
                 root.Children.Add(auswahlraum);
                 root.Children.Add(raumerfassen);
                 SqlCon.reader = SqlCon.command.ExecuteReader();
                 while (SqlCon.reader.Read())
                 {
                     auswahlraum.Items.Add(SqlCon.reader["raum"].ToString());
                 }
                 auswahlraum.Items.Add("Alles");
                 SqlCon.reader.Close();
                 SqlCon.sqlConnection.Close();
                 raumerfassen.Clicked += Raumerfassen_Clicked;
             }
             catch (Exception)
             {
                 SqlCon.reader.Close();
                 SqlCon.sqlConnection.Close();
 
             }
         }
 
         private void Raumerfassen_Clicked(object sender, EventArgs e)
         {
             try
             {
                 //content grid erstellen
                 grid = new Grid();
                 grid.BackgroundColor = Color.Black;
                 grid.ColumnSpacing = 1; grid.RowSpacing = 1.5;
                 grid.RowDefinitions.Add(new RowDefinition { });
 
 
                 SqlCon.sqlConnection.Open();
                 string auswahl = auswahlraum.SelectedItem.ToString();
                 if (auswahl == "Alles") auswahl = "''";
                 SqlCon.command = new SqlCommand("exec dbo.getInventar " + objekt.SelectedItem.ToString() + ","
                     + orte.SelectedItem.ToString() + "," + auswahl, SqlCon.sqlConnection);
                 string s = "";
                 SqlCon.reader = SqlCon.command.ExecuteReader();
                 int count = 0;
                 while (SqlCon.reader.Read())
                 {
                     string name = "";
                     if (objekt.SelectedItem.ToString() == "Computer")
                         name = SqlCon.reader["Computername"].ToString();
                     else
                         name = objekt.SelectedItem.ToString() + " " + 
                            SqlCon.reader[objekt.SelectedItem.ToString() + "Id"].ToString();
 
                     grid.Children.Add(new Label
                     {
 
                         Text = name,
                         HorizontalOptions = LayoutOptions.FillAndExpand,
                         FontSize = 14,
                         BackgroundColor = Color.White,
                         HorizontalTextAlignment = TextAlignment.Center,
                         VerticalTextAlignment = TextAlignment.Center
 
                     }, 0, count);
                     grid.Children.Add(new Label
                     {
 
                         Text = SqlCon.reader["Position"].ToString(),
                         HorizontalOptions = LayoutOptions.FillAndExpand,
                         FontSize = 14,
                         BackgroundColor = Color.White,
                         HorizontalTextAlignment = TextAlignment.Center,
                         VerticalTextAlignment = TextAlignment.Center
 
                     }, 1, count);
                     grid.Children.Add(new Label
                     {
 
                         Text = SqlCon.reader["Raum"].ToString(),
                         HorizontalOptions = LayoutOptions.FillAndExpand,
                         FontSize = 14,
                         BackgroundColor = Color.White,
                         HorizontalTextAlignment = TextAlignment.Center,
                         VerticalTextAlignment = TextAlignment.Center
 
                     }, 2, count);
 
                     //infobutton für weiterleitung, im Tabindex inventarnummerspeichern
                     var infobutton = new Button();
                     infobutton.Text = "+"; infobutton.BorderColor = Color.White;
                     infobutton.TabIndex = (int)(SqlCon.reader["InventarId"]);
                     grid.Children.Add(infobutton, 3, count);
                     infobutton.Clicked += Infobutton_Clicked;
 
                     count++;
                 }
                 SqlCon.reader.Close();
                 SqlCon.sqlConnection.Close();
                 //Scrollviesw content als Grid setzen
                 content.Content = grid;
                 //entfernen des header und der scrollview für richtige Reihenfolge 
                 root.Children.Remove(headergrid);
                 root.Children.Remove(content);
                 root.Children.Remove(controls);
                 //hinzufügen header und scrollview
                 root.Children.Add(headergrid);
                 root.Children.Add(content);
             }
             catch (Exception)
             {
 
                 SqlCon.reader.Close();
                 SqlCon.sqlConnection.Close();
             }
         }
 
         private void Infobutton_Clicked(object sender, EventArgs e)
         {
             inventarnummer = (sender as Button).TabIndex + "";
             ctrl.inventarnummer = inventarnummer;
             root.Children.Remove(headergrid);
             content.Content = new Objekt(inventarnummer).getObjekt();
             root.Children.Add(controls);
             
         }
       public StackLayout getVerwaltung()
         {
             return root;
         }
     }
 }
