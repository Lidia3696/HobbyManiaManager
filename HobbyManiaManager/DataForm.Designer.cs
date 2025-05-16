namespace HobbyManiaManager
{
    partial class DataForm
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
            this.DataAppWeb = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.DataAppWeb)).BeginInit();
            this.SuspendLayout();
            // 
            // DataAppWeb
            // 
            this.DataAppWeb.AllowExternalDrop = true;
            this.DataAppWeb.CreationProperties = null;
            this.DataAppWeb.DefaultBackgroundColor = System.Drawing.Color.White;
            this.DataAppWeb.Location = new System.Drawing.Point(12, 13);
            this.DataAppWeb.Name = "DataAppWeb";
            this.DataAppWeb.Size = new System.Drawing.Size(776, 425);
            this.DataAppWeb.TabIndex = 0;
            this.DataAppWeb.ZoomFactor = 1D;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataAppWeb);
            this.Name = "DataForm";
            this.Text = "DataForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataAppWeb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 DataAppWeb;
    }
}