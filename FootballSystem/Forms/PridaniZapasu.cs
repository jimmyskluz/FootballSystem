using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FootballSystem.ORM.mssql;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballSystem.ORM.Forms
{
    public partial class PridaniZapasu : Form
    {
        private Collection<Tym> tym;
        private Collection<Hrac> hraciDomaci;
        private Collection<Hrac> hraciHoste;


        private int domaciID;
        private int hosteID;
        private int zapasID;

        public PridaniZapasu()
        {
            InitializeComponent();
            Comboxs();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void Comboxs()
        {
            tym = TymTable.Select();

            foreach(var t in tym)
            {
                cbDomaci.Items.Add(new ComboboxItem()
                {
                    Text = t.Jmeno,
                    Value = t.IdTym
                });

                cbHoste.Items.Add(new ComboboxItem()
                {
                    Text = t.Jmeno,
                    Value = t.IdTym
                });
            }
        }

        private void aktualizaceDomacich(int idDomaci)
        {
            lbDomaci.Items.Clear();
            hraciDomaci = HracTable.Select(idDomaci);
            domaciID = idDomaci;
            foreach ( var h in hraciDomaci)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(h.Jmeno);
                item.SubItems.Add(h.IdHrac.ToString());
                lbDomaci.Items.Add(item);
                lbDomaci.CheckBoxes = true;
            }
        }


        private void aktualizaceHostu(int idHoste)
        {
            lbHoste.Items.Clear();
            hraciHoste = HracTable.Select(idHoste);
            hosteID = idHoste;
            foreach (var h in hraciHoste)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(h.Jmeno);
                item.SubItems.Add(h.IdHrac.ToString());
                lbHoste.Items.Add(item);
                lbHoste.CheckBoxes = true;
            }

            datum.Text = ZapasTable.Select2(domaciID, hosteID).Konani.ToString();
            zapasID = ZapasTable.Select2(domaciID, hosteID).IdZapas;
        }

        private void cbDomaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ComboboxItem selectedItem = (ComboboxItem)cb.SelectedItem;
            aktualizaceDomacich(selectedItem.Value);
        }

        private void cbHoste_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ComboboxItem selectedItem = (ComboboxItem)cb.SelectedItem;
            aktualizaceHostu(selectedItem.Value);
        }

        private void ulozSestavy_Click(object sender, EventArgs e)
        {
            int domaci = 0;
            int hoste = 0;

            foreach (ListViewItem h in lbDomaci.CheckedItems)
            {
                domaci += 1;
            }

            foreach (ListViewItem h in lbHoste.CheckedItems)
            {
                hoste += 1;
            }

            if(domaci<4)
            {
                MessageBox.Show("Malo domácích hráčů");
                return;
            }
            if (hoste < 4)
            {
                MessageBox.Show("Malo hráčů hostů");
                return;
            }


            foreach (ListViewItem h in lbDomaci.CheckedItems)
            {
                Hrac_HralTable.Insert(zapasID, Int32.Parse(h.SubItems[2].Text));
            }

            foreach (ListViewItem h in lbHoste.CheckedItems)
            {
                Hrac_HralTable.Insert(zapasID, Int32.Parse(h.SubItems[2].Text));
            }


        }

        private void gDomaci_CheckedChanged(object sender, EventArgs e)
        {
            strelec.Items.Clear();
            foreach (var hD in hraciDomaci)
            {
                strelec.Items.Add(new ComboboxItem()
                {
                    Text = hD.Jmeno,
                    Value = hD.IdHrac
                });
            }
        }

        private void pridejGol_Click(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)strelec.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Vloz hrace !");
                return;
            }

            if (string.IsNullOrWhiteSpace(casGolu.Text))
            {
                MessageBox.Show("Vloz cas !");
                return;
            }

            if (GolTable.Insert(zapasID, selectedItem.Value, Int32.Parse(casGolu.Text))<0)
                MessageBox.Show("Hrac nehral !");
        }

        private void gHoste_CheckedChanged(object sender, EventArgs e)
        {
            strelec.Items.Clear();
            foreach (var hH in hraciHoste)
            {
                strelec.Items.Add(new ComboboxItem()
                {
                    Text = hH.Jmeno,
                    Value = hH.IdHrac
                });
            }
        }

        private void ulozZapas_Click(object sender, EventArgs e)
        {
            UcastnikTable.Update(zapasID);
            this.Hide();
            hlavni hl = new hlavni();
            hl.ShowDialog();
            this.Close();
        }

        private void tDomaci_CheckedChanged(object sender, EventArgs e)
        {
            vylouceny.Items.Clear();
            foreach (var hD in hraciDomaci)
            {
                vylouceny.Items.Add(new ComboboxItem()
                {
                    Text = hD.Jmeno,
                    Value = hD.IdHrac
                });
            }
        }

        private void tHoste_CheckedChanged(object sender, EventArgs e)
        {
            vylouceny.Items.Clear();
            foreach (var hH in hraciHoste)
            {
                vylouceny.Items.Add(new ComboboxItem()
                {
                    Text = hH.Jmeno,
                    Value = hH.IdHrac
                });
            }
        }

        private void pridejTrest_Click(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)vylouceny.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Vloz hrace !");
                return;
            }

            if (string.IsNullOrWhiteSpace(tCas.Text))
            {
                MessageBox.Show("Vloz cas !");
                return;
            }

            if (string.IsNullOrWhiteSpace(tDelka.Text))
            {
                MessageBox.Show("Vloz delku trestu !");
                return;
            }

            if (TrestTable.Insert(zapasID, selectedItem.Value, Int32.Parse(tCas.Text), Int32.Parse(tDelka.Text)) < 0)
                MessageBox.Show("Hrac nehral !");
        }
    }
}
