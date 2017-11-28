using ICSharpCode.TextEditor.Document;
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

namespace POCOCreater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadFileSyntax();
        }
        private void ReadFileSyntax()
        {
            string syntaxfileDirectory = Path.Combine(Application.StartupPath, "Syntax");
            if (Directory.Exists(syntaxfileDirectory))
            {
                FileSyntaxModeProvider syntaxProvider = new FileSyntaxModeProvider(syntaxfileDirectory);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(syntaxProvider);
                TextEditorControlQuerySQL.SetHighlighting("SQL");
                TextEditorControlResultCSharp.SetHighlighting("C#");
                TextEditorControlResultCSharp.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show(syntaxfileDirectory + " doesn't exist");
            }         
        }
        private void ButtonAction_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
