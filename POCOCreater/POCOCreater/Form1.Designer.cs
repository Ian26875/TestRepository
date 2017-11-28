namespace POCOCreater
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TextEditorControlQuerySQL = new ICSharpCode.TextEditor.TextEditorControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TextEditorControlResultCSharp = new ICSharpCode.TextEditor.TextEditorControl();
            this.ComboBoxConnType = new System.Windows.Forms.ComboBox();
            this.TextBoxConnString = new System.Windows.Forms.TextBox();
            this.buttonAction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxClassName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextEditorControlQuerySQL
            // 
            this.TextEditorControlQuerySQL.IsReadOnly = false;
            this.TextEditorControlQuerySQL.Location = new System.Drawing.Point(10, 165);
            this.TextEditorControlQuerySQL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextEditorControlQuerySQL.Name = "TextEditorControlQuerySQL";
            this.TextEditorControlQuerySQL.Size = new System.Drawing.Size(608, 174);
            this.TextEditorControlQuerySQL.TabIndex = 0;
            this.TextEditorControlQuerySQL.Text = "SELECT * FROM TABLE";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 364);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(610, 146);
            this.dataGridView1.TabIndex = 1;
            // 
            // TextEditorControlResultCSharp
            // 
            this.TextEditorControlResultCSharp.IsReadOnly = false;
            this.TextEditorControlResultCSharp.Location = new System.Drawing.Point(8, 535);
            this.TextEditorControlResultCSharp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextEditorControlResultCSharp.Name = "TextEditorControlResultCSharp";
            this.TextEditorControlResultCSharp.Size = new System.Drawing.Size(610, 218);
            this.TextEditorControlResultCSharp.TabIndex = 2;
            this.TextEditorControlResultCSharp.Text = "public class ClassName\r\n{\r\n  public string PropertyNameString{get;set;}\r\n  public" +
    " int PropertyNameInt{get;set;}\r\n}";
            // 
            // ComboBoxConnType
            // 
            this.ComboBoxConnType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxConnType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxConnType.FormattingEnabled = true;
            this.ComboBoxConnType.Location = new System.Drawing.Point(10, 29);
            this.ComboBoxConnType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBoxConnType.Name = "ComboBoxConnType";
            this.ComboBoxConnType.Size = new System.Drawing.Size(608, 25);
            this.ComboBoxConnType.TabIndex = 3;
            // 
            // TextBoxConnString
            // 
            this.TextBoxConnString.Location = new System.Drawing.Point(8, 78);
            this.TextBoxConnString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxConnString.Multiline = true;
            this.TextBoxConnString.Name = "TextBoxConnString";
            this.TextBoxConnString.Size = new System.Drawing.Size(610, 62);
            this.TextBoxConnString.TabIndex = 4;
            // 
            // buttonAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(486, 760);
            this.buttonAction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(132, 25);
            this.buttonAction.TabIndex = 5;
            this.buttonAction.Text = "Action";
            this.buttonAction.UseVisualStyleBackColor = true;
            this.buttonAction.Click += new System.EventHandler(this.ButtonAction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ConnectionString:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "QueryCommandSQL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "ConnectionType:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Result POCO Class:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "SchemaTable:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 764);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Class Name :";
            // 
            // TextBoxClassName
            // 
            this.TextBoxClassName.Location = new System.Drawing.Point(103, 761);
            this.TextBoxClassName.Name = "TextBoxClassName";
            this.TextBoxClassName.Size = new System.Drawing.Size(266, 25);
            this.TextBoxClassName.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 788);
            this.Controls.Add(this.TextBoxClassName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.TextBoxConnString);
            this.Controls.Add(this.ComboBoxConnType);
            this.Controls.Add(this.TextEditorControlResultCSharp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TextEditorControlQuerySQL);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create POCO CSharp Class";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl TextEditorControlQuerySQL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ICSharpCode.TextEditor.TextEditorControl TextEditorControlResultCSharp;
        private System.Windows.Forms.ComboBox ComboBoxConnType;
        private System.Windows.Forms.TextBox TextBoxConnString;
        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxClassName;
    }
}

