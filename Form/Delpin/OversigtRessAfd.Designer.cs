namespace Delpin
{
    partial class OversigtRessAfd
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.VisLedigeRessourcer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(136, 44);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(528, 255);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // VisLedigeRessourcer
            // 
            this.VisLedigeRessourcer.Location = new System.Drawing.Point(9, 268);
            this.VisLedigeRessourcer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VisLedigeRessourcer.Name = "VisLedigeRessourcer";
            this.VisLedigeRessourcer.Size = new System.Drawing.Size(122, 30);
            this.VisLedigeRessourcer.TabIndex = 1;
            this.VisLedigeRessourcer.Text = "VisLedigeRessourcer";
            this.VisLedigeRessourcer.UseVisualStyleBackColor = true;
            this.VisLedigeRessourcer.Click += new System.EventHandler(this.button1_Click);
            // 
            // OversigtRessAfd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 366);
            this.Controls.Add(this.VisLedigeRessourcer);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OversigtRessAfd";
            this.Text = "Oversigt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button VisLedigeRessourcer;
    }
}