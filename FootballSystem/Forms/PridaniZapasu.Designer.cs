namespace FootballSystem.ORM.Forms
{
    partial class PridaniZapasu
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
            this.cbDomaci = new System.Windows.Forms.ComboBox();
            this.cbHoste = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDomaci = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbHoste = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ulozSestavy = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.casGolu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gHoste = new System.Windows.Forms.CheckBox();
            this.gDomaci = new System.Windows.Forms.CheckBox();
            this.strelec = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tDelka = new System.Windows.Forms.TextBox();
            this.tCas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tHoste = new System.Windows.Forms.CheckBox();
            this.tDomaci = new System.Windows.Forms.CheckBox();
            this.vylouceny = new System.Windows.Forms.ComboBox();
            this.pridejGol = new System.Windows.Forms.Button();
            this.pridejTrest = new System.Windows.Forms.Button();
            this.ulozZapas = new System.Windows.Forms.Button();
            this.datum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDomaci
            // 
            this.cbDomaci.FormattingEnabled = true;
            this.cbDomaci.Location = new System.Drawing.Point(460, 94);
            this.cbDomaci.Name = "cbDomaci";
            this.cbDomaci.Size = new System.Drawing.Size(121, 24);
            this.cbDomaci.TabIndex = 1;
            this.cbDomaci.SelectedIndexChanged += new System.EventHandler(this.cbDomaci_SelectedIndexChanged);
            // 
            // cbHoste
            // 
            this.cbHoste.FormattingEnabled = true;
            this.cbHoste.Location = new System.Drawing.Point(763, 95);
            this.cbHoste.Name = "cbHoste";
            this.cbHoste.Size = new System.Drawing.Size(121, 24);
            this.cbHoste.TabIndex = 2;
            this.cbHoste.SelectedIndexChanged += new System.EventHandler(this.cbHoste_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(664, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = ":";
            // 
            // lbDomaci
            // 
            this.lbDomaci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.lbDomaci.Location = new System.Drawing.Point(345, 170);
            this.lbDomaci.Name = "lbDomaci";
            this.lbDomaci.Size = new System.Drawing.Size(230, 265);
            this.lbDomaci.TabIndex = 4;
            this.lbDomaci.UseCompatibleStateImageBehavior = false;
            this.lbDomaci.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Absence";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Jmeno";
            this.columnHeader1.Width = 100;
            // 
            // lbHoste
            // 
            this.lbHoste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3});
            this.lbHoste.Location = new System.Drawing.Point(763, 170);
            this.lbHoste.Name = "lbHoste";
            this.lbHoste.Size = new System.Drawing.Size(230, 265);
            this.lbHoste.TabIndex = 5;
            this.lbHoste.UseCompatibleStateImageBehavior = false;
            this.lbHoste.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Absence";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Jmeno";
            this.columnHeader3.Width = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(420, 523);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gól";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(874, 523);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trest";
            // 
            // ulozSestavy
            // 
            this.ulozSestavy.Location = new System.Drawing.Point(620, 473);
            this.ulozSestavy.Name = "ulozSestavy";
            this.ulozSestavy.Size = new System.Drawing.Size(110, 28);
            this.ulozSestavy.TabIndex = 8;
            this.ulozSestavy.Text = "Uložit sestavy";
            this.ulozSestavy.UseVisualStyleBackColor = true;
            this.ulozSestavy.Click += new System.EventHandler(this.ulozSestavy_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.casGolu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gHoste);
            this.panel1.Controls.Add(this.gDomaci);
            this.panel1.Controls.Add(this.strelec);
            this.panel1.Location = new System.Drawing.Point(291, 561);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 201);
            this.panel1.TabIndex = 9;
            // 
            // casGolu
            // 
            this.casGolu.Location = new System.Drawing.Point(161, 117);
            this.casGolu.Name = "casGolu";
            this.casGolu.Size = new System.Drawing.Size(121, 22);
            this.casGolu.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(51, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Čas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(51, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Střelec";
            // 
            // gHoste
            // 
            this.gHoste.AutoSize = true;
            this.gHoste.Location = new System.Drawing.Point(190, 24);
            this.gHoste.Name = "gHoste";
            this.gHoste.Size = new System.Drawing.Size(67, 21);
            this.gHoste.TabIndex = 2;
            this.gHoste.Text = "Hosté";
            this.gHoste.UseVisualStyleBackColor = true;
            this.gHoste.CheckedChanged += new System.EventHandler(this.gHoste_CheckedChanged);
            // 
            // gDomaci
            // 
            this.gDomaci.AutoSize = true;
            this.gDomaci.Location = new System.Drawing.Point(41, 24);
            this.gDomaci.Name = "gDomaci";
            this.gDomaci.Size = new System.Drawing.Size(77, 21);
            this.gDomaci.TabIndex = 1;
            this.gDomaci.Text = "Domácí";
            this.gDomaci.UseVisualStyleBackColor = true;
            this.gDomaci.CheckedChanged += new System.EventHandler(this.gDomaci_CheckedChanged);
            // 
            // strelec
            // 
            this.strelec.FormattingEnabled = true;
            this.strelec.Location = new System.Drawing.Point(161, 59);
            this.strelec.Name = "strelec";
            this.strelec.Size = new System.Drawing.Size(121, 24);
            this.strelec.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tDelka);
            this.panel2.Controls.Add(this.tCas);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tHoste);
            this.panel2.Controls.Add(this.tDomaci);
            this.panel2.Controls.Add(this.vylouceny);
            this.panel2.Location = new System.Drawing.Point(749, 561);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 201);
            this.panel2.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(51, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dělka";
            // 
            // tDelka
            // 
            this.tDelka.Location = new System.Drawing.Point(161, 155);
            this.tDelka.Name = "tDelka";
            this.tDelka.Size = new System.Drawing.Size(121, 22);
            this.tDelka.TabIndex = 6;
            // 
            // tCas
            // 
            this.tCas.Location = new System.Drawing.Point(161, 112);
            this.tCas.Name = "tCas";
            this.tCas.Size = new System.Drawing.Size(121, 22);
            this.tCas.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(51, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Čas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(51, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Vyloučený";
            // 
            // tHoste
            // 
            this.tHoste.AutoSize = true;
            this.tHoste.Location = new System.Drawing.Point(190, 24);
            this.tHoste.Name = "tHoste";
            this.tHoste.Size = new System.Drawing.Size(67, 21);
            this.tHoste.TabIndex = 2;
            this.tHoste.Text = "Hosté";
            this.tHoste.UseVisualStyleBackColor = true;
            this.tHoste.CheckedChanged += new System.EventHandler(this.tHoste_CheckedChanged);
            // 
            // tDomaci
            // 
            this.tDomaci.AutoSize = true;
            this.tDomaci.Location = new System.Drawing.Point(41, 24);
            this.tDomaci.Name = "tDomaci";
            this.tDomaci.Size = new System.Drawing.Size(77, 21);
            this.tDomaci.TabIndex = 1;
            this.tDomaci.Text = "Domácí";
            this.tDomaci.UseVisualStyleBackColor = true;
            this.tDomaci.CheckedChanged += new System.EventHandler(this.tDomaci_CheckedChanged);
            // 
            // vylouceny
            // 
            this.vylouceny.FormattingEnabled = true;
            this.vylouceny.Location = new System.Drawing.Point(161, 59);
            this.vylouceny.Name = "vylouceny";
            this.vylouceny.Size = new System.Drawing.Size(121, 24);
            this.vylouceny.TabIndex = 0;
            // 
            // pridejGol
            // 
            this.pridejGol.Location = new System.Drawing.Point(384, 785);
            this.pridejGol.Name = "pridejGol";
            this.pridejGol.Size = new System.Drawing.Size(93, 28);
            this.pridejGol.TabIndex = 11;
            this.pridejGol.Text = "Přidat gól";
            this.pridejGol.UseVisualStyleBackColor = true;
            this.pridejGol.Click += new System.EventHandler(this.pridejGol_Click);
            // 
            // pridejTrest
            // 
            this.pridejTrest.Location = new System.Drawing.Point(845, 785);
            this.pridejTrest.Name = "pridejTrest";
            this.pridejTrest.Size = new System.Drawing.Size(110, 28);
            this.pridejTrest.TabIndex = 12;
            this.pridejTrest.Text = "Přidat trest";
            this.pridejTrest.UseVisualStyleBackColor = true;
            this.pridejTrest.Click += new System.EventHandler(this.pridejTrest_Click);
            // 
            // ulozZapas
            // 
            this.ulozZapas.Location = new System.Drawing.Point(620, 823);
            this.ulozZapas.Name = "ulozZapas";
            this.ulozZapas.Size = new System.Drawing.Size(93, 28);
            this.ulozZapas.TabIndex = 13;
            this.ulozZapas.Text = "Uložit zápas";
            this.ulozZapas.UseVisualStyleBackColor = true;
            this.ulozZapas.Click += new System.EventHandler(this.ulozZapas_Click);
            // 
            // datum
            // 
            this.datum.AutoSize = true;
            this.datum.Location = new System.Drawing.Point(598, 142);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(0, 17);
            this.datum.TabIndex = 14;
            // 
            // PridaniZapasu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1421, 863);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.ulozZapas);
            this.Controls.Add(this.pridejTrest);
            this.Controls.Add(this.pridejGol);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ulozSestavy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHoste);
            this.Controls.Add(this.lbDomaci);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHoste);
            this.Controls.Add(this.cbDomaci);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PridaniZapasu";
            this.Text = "ProdaniZapasu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDomaci;
        private System.Windows.Forms.ComboBox cbHoste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lbDomaci;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lbHoste;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ulozSestavy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox casGolu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox gHoste;
        private System.Windows.Forms.CheckBox gDomaci;
        private System.Windows.Forms.ComboBox strelec;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tDelka;
        private System.Windows.Forms.TextBox tCas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox tHoste;
        private System.Windows.Forms.CheckBox tDomaci;
        private System.Windows.Forms.ComboBox vylouceny;
        private System.Windows.Forms.Button pridejGol;
        private System.Windows.Forms.Button pridejTrest;
        private System.Windows.Forms.Button ulozZapas;
        private System.Windows.Forms.Label datum;
    }
}