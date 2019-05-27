using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CarRentRestApi.Models;
using Newtonsoft.Json;
using CarRentRestApi.BLL;

namespace CarRentRestApi.WinUI
{
    public partial class CalisanAnaSayfa : Form
    {
        public CalisanAnaSayfa()
        {
            InitializeComponent();
        }
        Araclar araclars;
        private async void btnAracListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:52009/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Get Request from the URI
                    using (var result = await client.GetAsync("api/Araclar"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dataGrid_Araclar.DataSource =
                                JsonConvert.DeserializeObject<ResponseContent<Araclar>>(value).Data.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Inform user if an error occurs
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private async void btnAracEkle_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:52009/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create post body object
                    Araclar arac = new Araclar()
                    {
                        Marka = txtMarka.Text,
                        Model = txtModel.Text,
                        MinYasSiniri = Convert.ToInt32(txtMinYasSiniri.Text),
                        EhliyetYasi = Convert.ToInt32(txtEhliyetYasi.Text),
                        GunukKm = Convert.ToInt32(txtGunlukKm.Text),
                        AnlikKm = Convert.ToInt32(txtAnlikKm.Text),
                        Airbag = byte.Parse(txtAirbag.Text),
                        BagajHacmi = Convert.ToInt32(txtBagajHacmi.Text),
                        GunlukKiralikFiyati = decimal.Parse(txtGunlukKiralikFiyati.Text),
                        Durum = bool.Parse(txtDurum.Text)
                    };

                    // Serialize C# object to Json Object
                    var serializedProduct = JsonConvert.SerializeObject(arac);
                    // Json object to System.Net.Http content type
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    // Post Request to the URI
                    var result = await client.PostAsync("api/Araclar", content);
                    // Check for result
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                // Set message depend on success info
                var message = success ? "done" : "failed";
                // Inform user
                MessageBox.Show("Operation " + message);
            }
            catch (Exception ex)
            {
                // Inform user
                MessageBox.Show("Error happened: " + ex.Message);
            }
            
        }

        private async void btnAracSil_Click(object sender, EventArgs e)
        {
            /*try
            {
                bool success = false;
                // Check for textboxes are okay?
                if (txtAracID.Text != "" || txtAracID.Text != null ||
                    !txtAracID.Text.ToCharArray().Any(x => Char.IsLetter(x)))
                {
                    // Create HttpClient object
                    using (var client = new HttpClient())
                    {
                        // Setup basics
                        client.BaseAddress = new Uri("http://localhost:52009/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

                        // Create an object (normal/basic/plain/non typed/json object)
                        Araclar requestObject = new Araclar()
                        {
                            AracID = Convert.ToInt16(txtAracID.Text)
                        };

                        // Serialize object to Json Object
                        var serializedProduct = JsonConvert.SerializeObject(requestObject);
                        // Convert the json object to System.Net content
                        var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                        // DELETE request to the URI with the content
                        var result = await client.DeleteAsync("api/Araclar", content);
                        // Check the result
                        if (result.IsSuccessStatusCode)
                        {
                            // Update the success info
                            success = true;
                        }
                    }
                }
                // Setup the message info depend on success
                var message = success ? "successfully done" : "failed";
                // Inform the User
                MessageBox.Show("Transaction is " + message);
                // Update the Transaction list
                //btn_transactionList_Click(sender, e);
            }
            catch (Exception ex)
            {
                // Inform the user if an error occurs
                MessageBox.Show("Error happened: " + ex.Message);
            }*/
        }

        private async void btnKiralikBilgiListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:52009/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Get Request from the URI
                    using (var result = await client.GetAsync("api/KiralikBilgi"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dataGrid_KiralikBilgiListe.DataSource =
                                JsonConvert.DeserializeObject<ResponseContent<KiralikBilgi>>(value).Data.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Inform user if an error occurs
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private async void btnKiralikBilgiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:52009/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    decimal ucret = ((Convert.ToInt32(txtSon.Text) - Convert.ToInt32(txtAnlikKm.Text)) * 100);
                    // Create post body object
                    KiralikBilgi kiralik = new KiralikBilgi()
                    {
                        AracID = Convert.ToInt16(txtAracID.Text),
                        KiralikID = Convert.ToInt16(txtAracID.Text),
                        MusteriID = Convert.ToInt16(txtMusteriID.Text),
                        BaslangicTarihi = Convert.ToDateTime(dateTimePicker1),
                        TeslimTarihi = Convert.ToDateTime(dateTimePicker2),
                        AnlikKm = Convert.ToInt32(txtAnlikKm.Text),
                        SonKm = Convert.ToInt32(txtSon.Text),
                        AlinanUcret = ucret
                    };
                
                    // Serialize C# object to Json Object
                    var serializedProduct = JsonConvert.SerializeObject(kiralik);
                    // Json object to System.Net.Http content type
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    // Post Request to the URI
                    var result = await client.PostAsync("api/KiralikBilgi", content);
                    // Check for result
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                // Set message depend on success info
                var message = success ? "done" : "failed";
                // Inform user
                MessageBox.Show("Operation " + message);
            }
            catch (Exception ex)
            {
                // Inform user
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }
    }
}
