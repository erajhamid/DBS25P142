namespace MidProjectDb
{
    partial class facultydashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(facultydashboard));
            label2 = new Label();
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(393, 39);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(486, 81);
            label2.TabIndex = 1;
            label2.Text = "FACULTY DASHBOARD";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 633);
            panel1.TabIndex = 2;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonShadow;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(32, 471);
            button4.Name = "button4";
            button4.Size = new Size(212, 62);
            button4.TabIndex = 3;
            button4.Text = "Assign Duties";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonShadow;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(32, 329);
            button3.Name = "button3";
            button3.Size = new Size(212, 65);
            button3.TabIndex = 2;
            button3.Text = "Check Results";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonShadow;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(32, 184);
            button2.Name = "button2";
            button2.Size = new Size(212, 60);
            button2.TabIndex = 1;
            button2.Text = "View Participants";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonShadow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(32, 49);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(212, 58);
            button1.TabIndex = 0;
            button1.Text = "Manage Events";
            button1.UseVisualStyleBackColor = false;
            // 
            // facultydashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1029, 630);
            Controls.Add(panel1);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4);
            Name = "facultydashboard";
            Text = "facultydashboard";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Button button4;
        private Button button3;
    }
}