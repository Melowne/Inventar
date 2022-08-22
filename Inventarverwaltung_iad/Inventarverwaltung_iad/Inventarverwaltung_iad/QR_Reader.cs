using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Dise Klasse wird für die QR-Reader Funktion verwendet.
    /// </summary>

    public class QR_Reader
    {
        private StackLayout root = new StackLayout();
        private Frame frame = new Frame();
        private ScrollView content = new ScrollView();
        private Controls ctrl;
        private string inventarnummer ;

        //scanner elemente
        private Button scannen = new Button();
        private ZXingScannerView scanview=new ZXingScannerView();
        //controls 
        private StackLayout controls;
        private Button zurueck = new Button();

        public QR_Reader()
        {
            //controlsinitialisieren
            ctrl = new Controls(content, inventarnummer);
            controls = ctrl.getControls();
            //Frame Überschrift
            frame.BackgroundColor = Color.FromHex("#fe0000"); frame.Padding = 24; frame.CornerRadius = 0;
            frame.Content = new Label
            {
                Text = "QR-Reader",
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                FontSize = 36
            };
            root.Children.Add(frame);
            zurueck.Text = "Zurück";
            scannen.Text = "Scannen";
            scanview.IsScanning = true;
            root.Children.Add(scannen);

            scannen.Clicked += Scannen_Clicked;
            scanview.OnScanResult += Scanview_OnScanResult;
            zurueck.Clicked += Zurueck_Clicked;
        
        }

        private void Zurueck_Clicked(object sender, EventArgs e)
        {
            root.Children.Remove(controls);
            root.Children.Remove(content);
            root.Children.Remove(zurueck);
            root.Children.Add(scannen);
        }

        private void Scanview_OnScanResult(ZXing.Result result)
        {
             Device.BeginInvokeOnMainThread( () => 
            {
                if (result.Text != "" && result != null)
                {
                    inventarnummer = result.Text;
                    ctrl.inventarnummer = inventarnummer;
                    root.Children.Remove(scanview);
                    root.Children.Remove(scannen);
                    content.Content = new Objekt(inventarnummer).getObjekt();
                    root.Children.Add(content);
                    root.Children.Add(controls);
                    root.Children.Add(zurueck);

                }
            }
             );

        }

        private void Scannen_Clicked(object sender, EventArgs e)
        {
            root.Children.Add(scanview);
         
        }

        public StackLayout getQR()
        {
            return root;
        }
    }
}
