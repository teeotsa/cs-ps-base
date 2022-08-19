
namespace PowerShell_Project
{
    partial class Form1
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
            this.Execute_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Execute_Button
            // 
            this.Execute_Button.Location = new System.Drawing.Point(35, 30);
            this.Execute_Button.Name = "Execute_Button";
            this.Execute_Button.Size = new System.Drawing.Size(158, 35);
            this.Execute_Button.TabIndex = 0;
            this.Execute_Button.Text = "Execute PowerShell File";
            this.Execute_Button.UseVisualStyleBackColor = true;
            this.Execute_Button.Click += new System.EventHandler(this.Execute_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 230);
            this.Controls.Add(this.Execute_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Execute_Button;
    }
}

