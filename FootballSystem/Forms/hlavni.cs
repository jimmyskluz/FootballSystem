using System;
using FootballSystem.ORM.mssql;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing;

namespace FootballSystem.ORM.Forms
{
    public partial class hlavni : Form
    {
        private Collection<Zapas> zapasy;
        private Collection<Gol> gols;
        private Collection<Trest> trests;
        private Collection<Ucastnik> ucastnici;

        public hlavni()
        {
            InitializeComponent();
            //zapasy = ZapasTable.Select();
            aktualizaceZapasu();
            aktualizaceHracu();
            aktualizaceTrestu();
            aktualizateTabulky();
        }


        private void aktualizaceHracu()
        {
            gols = GolTable.Select();
            int i = 1;

            foreach (Gol g in gols)
            {
                string[] row = { i.ToString(), g.Hrac.Jmeno.ToString(), HracTable.SelectTym(g.Hrac.IdHrac).TymJmeno, g.PocetGolu.ToString() };
                var lVI = new ListViewItem(row);
                goly.Items.Add(lVI);
                i += 1;
            }
        }

        private void aktualizaceTrestu()
        {
            trests = TrestTable.Select();
            int i = 1;
            foreach (Trest t in trests)
            {
                string[] row = { i.ToString(), t.Hrac.Jmeno.ToString(), HracTable.SelectTym(t.Hrac.IdHrac).TymJmeno, t.Minuty.ToString() };
                var lVI = new ListViewItem(row);
                tresty.Items.Add(lVI);
                i += 1;
            }
        }

        private void aktualizateTabulky()
        {
            ucastnici = UcastnikTable.Select(1);
          int i = 1;
            foreach (Ucastnik u in ucastnici)
            {
                string[] row = { i.ToString(), u.Tym.Jmeno.ToString(), u.PocetZapasu.ToString(), u.Vyhry.ToString(), u.Remizy.ToString(),
                u.Prohry.ToString(), u.Body.ToString()};
                var lVI = new ListViewItem(row);
                tabulka.Items.Add(lVI);
                i += 1;
            }
        }

        private void hlavni_Load(object sender, EventArgs e)
        {

        }

        private void aktualizaceZapasu()
        {
            zapasy = ZapasTable.Select();

            List<Label> labels = new List<Label>();
            int i = 0;

            foreach (Zapas z in zapasy)
            {
                var temp = new Label();

                temp.Location = new Point(150, 120 + i * 35);
                temp.Text = z.Konani + "\n" + TymTable.SelectName(z.IdDomaci).Jmeno + " " +z.Skore_domaci + " : " + z.Skore_hoste + " " + TymTable.SelectName(z.IdHoste).Jmeno;
                temp.Click += new EventHandler(hlavni_Load);
                temp.AutoSize = true;
                temp.BackColor = System.Drawing.Color.LightGray;

                this.Controls.Add(temp);

                temp.Show();
                labels.Add(temp);
                i += 1;
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ZapasForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            PridaniZapasu pr = new PridaniZapasu();
            pr.ShowDialog();
            this.Close();
        }
    }
}
