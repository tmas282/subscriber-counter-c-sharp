using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SubscriberCounterCsharp
{
    public partial class SubscriberCounter : Form
    {
        public SubscriberCounter()
        {
            InitializeComponent();
        }
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            //UCUfP26mozkiTLZj5eBpFPeQ
            string api_sub = String.Format("https://www.googleapis.com/youtube/v3/channels?part=statistics&id={0}&key=AIzaSyAIGiSI7O4YubN7RO9DwiqWQdu4l-OGD4Q", txtId.Text);
            HttpWebRequest getInfo = (HttpWebRequest)WebRequest.Create(api_sub);
            HttpWebResponse resposta = (HttpWebResponse)getInfo.GetResponse();
            Stream stream = resposta.GetResponseStream();
            var jsonEncodificado = new StreamReader(stream);
            JObject json = JObject.Parse(jsonEncodificado.ReadToEnd());
            var subs = json["items"][0]["statistics"]["subscriberCount"];
            lblResultado.Text = String.Format("{0}", subs);
        }
    }
}
