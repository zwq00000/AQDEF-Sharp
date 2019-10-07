using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            this.sourceEditor.MouseClick += (s, e) => {
                this.label1.Text = GetParseLine();
            };
            this.sourceEditor.KeyUp += (s, e) => {
                this.label1.Text = GetParseLine();
            };
        }
        
        private string GetParseLine() {
            var lineNum = sourceEditor.GetLineFromCharIndex(sourceEditor.GetFirstCharIndexOfCurrentLine());
            if (lineNum >= sourceEditor.Lines.Length) {
                return lineNum.ToString();
            }
            var line = sourceEditor.Lines[lineNum];
            string displayText;
            IKKeyEntry entry;
            if (EntryParser.ParseKKeyLine(line, out entry)) {
                displayText = $"{entry.Key.Key} {entry.Index} {entry.Key.DisplayName} {entry.Key.Level}";
            } else {
                var datas = EntryParser.ParseBinaryDataLine(line);
                displayText = string.Join("\r\n", datas.Select(d => d.ToString()));
            }
            return displayText;
        }

        private IEnumerable<string> Parse(string content) {
            using (var reader = new StringReader(content)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (string.IsNullOrWhiteSpace(line)) {
                        continue;
                    }
                        IKKeyEntry entry;
                        if (EntryParser.ParseKKeyLine(line, out entry)) {
                            var identy = new string('\t', (int)entry.Key.Level);
                           yield return $"{entry.Key} {entry.Index} {identy} {entry.Text}  -- {entry.Key.DisplayName} \t{entry.Key.Level}";
                        } else  {
                        var values = EntryParser.ParseBinaryDataLine(line);
                        foreach (var data in values) {
                            yield return data.ToString();
                        }
                    }
                }
            }
        }

        private void Transform(string source) {
            var enties = Parse(source);
            transResult.Clear();
            transResult.Text = string.Join("\r\n", enties);
        }
    }
}
