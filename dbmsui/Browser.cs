using System;
using System.IO;
using System.Windows.Forms;
using WebKit;

namespace dbmsui {
    public class Browser : WebKitBrowser {
        public Browser() {
            //AllowWebBrowserDrop = false;
            IsWebBrowserContextMenuEnabled = false;
            Url = new Uri(string.Format("file:///{0}/../../template.html", Directory.GetCurrentDirectory()));

            Dock = DockStyle.Fill;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Escape:
                    Application.Exit();
                    return true;
            }

            return false;
        }

        //protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e) {
        //    Document.Click += new HtmlElementEventHandler(DocumentClick);
        //}

        private void DocumentClick(object sender, HtmlElementEventArgs e) {
            //MessageBox.Show(Document.ActiveElement.Id);
        }
    }
}
