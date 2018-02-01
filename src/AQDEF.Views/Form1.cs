using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQDEF.Models;

namespace AQDEF.Views {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            InitControls();
        }

        private void InitControls() {
            this.toolStrip_Transform.Click += (s, e) => {
                Transform(this.sourceEditor.Text);
            };
            this.toolStrip_OpenFile.Click += (s, e) => {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    using (var reader = new StreamReader(dialog.OpenFile())) {
                        this.sourceEditor.Text = reader.ReadToEnd();
                    }
                }
            };
        }

        private void Transform(string source) {
            var enties = EntryParser.Parse(source);
            transResult.Clear();
            foreach (var entry in enties) {
                var identy = new string('\t', (int)entry.Key.Level);
                transResult.AppendText(
                    $"{entry.Key} {entry.Index} {identy} {entry.TextValue}  -- {entry.Key.DisplayName} \t{entry.Key.Level} \r\n");
            }
        }
    }
}
