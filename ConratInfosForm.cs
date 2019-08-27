using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Drawing.Drawing2D; // si on veut ajouter une photo"logo"
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.IO;




namespace ajoutxt
{
    public partial class ConratInfosForm : Form
    {
        public ConratInfosForm()
        {
            InitializeComponent();

            // Pour ajouter du texte
            var ci = new CultureInfo("ar-AR");

            Thread.CurrentThread.CurrentCulture = ci;

            List<string> partenaires = new List<string>()
            {
                "عمالة مكناس", "عمالة ويسلان"
            };
        }
 
        private void FindAndReplace( object pattern, object replacementText)
        {
            object missing = Missing.Value;

            object matchCase = true;
               object matchWholeWord = true;
               object matchWildCards = false;
               object matchSoundLike = false;
               object nmatchAllForms = false;
               object forward = true;
               object format = false;
               object matchKashida = false;
               object matchDiactitics = false;
               object matchAlefHamza = false;
               object matchControl = false;
               object read_only = false;
               object visible = true;
               object replace = 2;
               object wrap = 1;

            int intFound = 0;
            object findText = pattern;
                    var wdApp = Globals.ThisAddIn.Application;
                    findText = wdApp.Selection.Find;
                    wdApp.Selection.Find.ClearFormatting();
                    bool isFound = wdApp.Selection.Find.Execute(FindText: findText, ref missing);

                    if (!isFound)
                      Debug.Print("Searched Text \"{0}\" not found !", pattern);

                   while (wdApp.Selection.Find.Found)
            {
                intFound++;
                wdApp.Selection.Find.Execute(
                          ref missing, ref missing, ref missing, ref missing, ref missing,
                          ref missing, ref missing, ref missing, ref missing, ref missing,
                          ref missing, ref missing, ref missing, ref missing, ref missing);
            }
            MessageBox.Show("Strings found: " + intFound.ToString());
        }
   
        private void Txt_premiers_partenaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox1 = new ComboBox();
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

            MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                            "Index: " + selectedIndex.ToString());

        }
    

        private void Txt_intitule_projet_TextChanged(object sender, EventArgs e)
        {
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Textobjectif_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          
        }

        private void ConratInfosForm_Load(object sender, EventArgs e)
        {
        }

        private void Premiers_partenaires_Click(object sender, EventArgs e)
        {

        }

        //Load the Template Document:
        private void Button2_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Open_existingdoc();
            object readOnly = false; //default
            object isVisible = false;
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;
           // tEnabled(false); // Bloquer ou débloquer la saisie des données jusqu'au l'ouverture du Doc
        }

        private void BnApplyData_Click(object sender, EventArgs e)
        {

            string intutuleprojet = txt_intitule_projet.Text;
            decimal montantGlobal = num_montant.Value;
            string  obj= txt_intitule_projet.Text;

            this.FindAndReplace("{{intitule_projet}}", intutuleprojet);
            this.FindAndReplace( "{{intitule_projet}}", intutuleprojet);
            this.FindAndReplace("{{montant}}", montantGlobal.ToString());
            this.FindAndReplace("{{intitule_projet}}", obj);

         //   list_partenaires1.Items.Add(ThisAddIn.Open_existingdoc.SelectedItem);


        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "*";
            dlg.DefaultExt = "pdf";
            dlg.ValidateNames = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

               Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(dlg.FileName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, OpenAfterExport: true);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  System.Object[] ItemObject = new System.Object[10];
            for (int i = 0; i <= 9; i++)
            {
                ItemObject[i] = "Item" + i;
            }
            listBox1.Items.AddRange(ItemObject);*/
        }
    }
}
