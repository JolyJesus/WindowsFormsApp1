namespace WindowsFormsApp1
{
    partial class Form36
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.myAiroportDataSet = new WindowsFormsApp1.MyAiroportDataSet();
            this.viewPosadaPersonalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_PosadaPersonalTableAdapter = new WindowsFormsApp1.MyAiroportDataSetTableAdapters.View_PosadaPersonalTableAdapter();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazvaPosadyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAiroportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPosadaPersonalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.surnameDataGridViewTextBoxColumn,
            this.nazvaPosadyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.viewPosadaPersonalBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(34, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(270, 102);
            this.dataGridView1.TabIndex = 0;
            // 
            // myAiroportDataSet
            // 
            this.myAiroportDataSet.DataSetName = "MyAiroportDataSet";
            this.myAiroportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewPosadaPersonalBindingSource
            // 
            this.viewPosadaPersonalBindingSource.DataMember = "View_PosadaPersonal";
            this.viewPosadaPersonalBindingSource.DataSource = this.myAiroportDataSet;
            // 
            // view_PosadaPersonalTableAdapter
            // 
            this.view_PosadaPersonalTableAdapter.ClearBeforeFill = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            // 
            // nazvaPosadyDataGridViewTextBoxColumn
            // 
            this.nazvaPosadyDataGridViewTextBoxColumn.DataPropertyName = "NazvaPosady";
            this.nazvaPosadyDataGridViewTextBoxColumn.HeaderText = "NazvaPosady";
            this.nazvaPosadyDataGridViewTextBoxColumn.Name = "nazvaPosadyDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(90, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form36
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form36";
            this.Text = "Form36";
            this.Load += new System.EventHandler(this.Form36_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAiroportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPosadaPersonalBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MyAiroportDataSet myAiroportDataSet;
        private System.Windows.Forms.BindingSource viewPosadaPersonalBindingSource;
        private MyAiroportDataSetTableAdapters.View_PosadaPersonalTableAdapter view_PosadaPersonalTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazvaPosadyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}