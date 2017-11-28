using ICSharpCode.TextEditor.Document;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
            InitializeComboBox();
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
        private void InitializeComboBox()
        {
            try
            {
                IList<ConnectionTypeComboBoxItem> connections = new List<ConnectionTypeComboBoxItem>
                {
                    new ConnectionTypeComboBoxItem
                    {
                        Name="Oracle OracleConnection",
                        Connection=new OracleConnection()
                    },
                     new ConnectionTypeComboBoxItem
                    {
                        Name="Microsoft SqlConnection",
                        Connection=new SqlConnection()
                    },
                };
                ComboBoxConnType.DataSource = connections;
                ComboBoxConnType.DisplayMember = "Name";
                ComboBoxConnType.ValueMember = "Connection";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ButtonAction_Click(object sender, EventArgs e)
        {
            try
            {
                IDbConnection connection = (ComboBoxConnType.SelectedItem as ConnectionTypeComboBoxItem).Connection;
                connection.ConnectionString = TextBoxConnString.Text;
                string sql = TextEditorControlQuerySQL.Text;
                string className = TextBoxClassName.Text;
                DataTable tableSchema = new DataTable();
                string result = ConnectionHelper.PrintClass(connection, sql, className, ref tableSchema);
                TextEditorControlResultCSharp.Text = result;
                dataGridViewSchema.DataSource = tableSchema;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
