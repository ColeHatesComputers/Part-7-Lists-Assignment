using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_7_Lists_Assignment
{
    public partial class frmLists : Form
    {

        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random generator = new Random();
        int totalremove = 0;

        public frmLists()
        {
            InitializeComponent();
        }

        private void frmLists_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            lstNumbers.DataSource = numbers;
            heroes.Clear();
            heroes.Add("Flash");
            heroes.Add("Mr. Aldworth");
            heroes.Add("Spiderman");
            lstHeroes.DataSource = heroes;
        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            UpdateNumbers();
            lblStatus.Text = ("Status: Numbers Sorted!");
        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            UpdateHeroes();
            lblStatus.Text = ("Status: Heroes Sorted!");
        }

        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            UpdateNumbers();
            lblStatus.Text = ("Status: New Numbers List!");
        }
        
        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("Flash");
            heroes.Add("Mr. Aldworth");
            heroes.Add("Spiderman");
            UpdateHeroes();
            lblStatus.Text = ("Status: New Heroes List!");
        }       
        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex < 0)
                lblStatus.Text = "Status: No Item Selected!";
            else
            {
                numbers.RemoveAt((Int32)lstNumbers.SelectedIndex);
                UpdateNumbers();
                lblStatus.Text = ("Status: Number Removed!");
            }

        }
        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex < 0)
                lblStatus.Text = "Status: No Item Selected!";
            else
                while (numbers.Remove((Int32)lstNumbers.SelectedItem))
                {
                    totalremove = totalremove + 1;
                    lblStatus.Text = ($"Status: Removed a Total of {totalremove}!");
                }
            totalremove = 0;

            UpdateNumbers();
        }

        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            if (heroes.Remove(txtRemoveHero.Text))
            {
                UpdateHeroes();
                lblStatus.Text = ("Status: Heroes Removed!");
            }
            else
                lblStatus.Text = ("Status: Hero is not in the List!");
        }
        
            
        private void UpdateHeroes()
        {
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
        }

        private void UpdateNumbers()
        {
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
        }
        private void btnAddHero_Click(object sender, EventArgs e)
        {
            if (heroes.Contains(txtAddHero.Text))
                lblStatus.Text = ("Status: Hero Already in the List!");
            else
                heroes.Add(txtAddHero.Text);
            lblStatus.Text = ("Status: Heroes added!");
            
            UpdateHeroes();
        }

    }
}
