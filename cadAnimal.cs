using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace singgle.Forms
{
    public partial class cadAnimal : Form
    {
        public cadAnimal()
        {
            InitializeComponent();
        }

        Classes.Animal cls = new Classes.Animal();

        private void cadAnimal_Load(object sender, EventArgs e)
        {
            nomeAnimalTextBox.Enabled = false;
            brincoAnimalTextBox.Enabled = false;
            motObitoAnimalTextBox.Enabled = false;
            pesoAnimalTextBox.Enabled = false;
            paiAnimalComboBox.Enabled = false;
            maeAnimalComboBox.Enabled = false;
            sexoAnimalComboBox.Enabled = false;
            motBaixaAnimalComboBox.Enabled = false;
            idRacaAnimalComboBox.Enabled = false;
            idPropAnimalComboBox.Enabled = false;
            dtNascAnimalDateTimePicker.Enabled = false;
            dtBaixaAnimalDateTimePicker.Enabled = false;
            dt1repAnimalDateTimePicker.Enabled = false;

            carregaCombobox();
        }

        private void carregaCombobox()
        {
            MySqlConnection Conn = new MySqlConnection("server=69.64.33.121;user id=mnettec1_sing;password=poucasombra10;persistsecurityinfo=True;database=mnettec1_singgle");
            Conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "select paiAnimal, maeAnimal from animal";
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            paiAnimalComboBox.DisplayMember = "paiAnimal";
            paiAnimalComboBox.DataSource = dt;
            maeAnimalComboBox.DisplayMember = "maeAnimal";
            maeAnimalComboBox.DataSource = dt;
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            nomeAnimalTextBox.Enabled = true;
            brincoAnimalTextBox.Enabled = true;
            motObitoAnimalTextBox.Enabled = true;
            pesoAnimalTextBox.Enabled = true;
            paiAnimalComboBox.Enabled = true;
            maeAnimalComboBox.Enabled = true;
            sexoAnimalComboBox.Enabled = true;
            motBaixaAnimalComboBox.Enabled = true;
            idRacaAnimalComboBox.Enabled = true;
            idPropAnimalComboBox.Enabled = true;
            dtNascAnimalDateTimePicker.Enabled = true;
            dtBaixaAnimalDateTimePicker.Enabled = true;
            dt1repAnimalDateTimePicker.Enabled = true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            cls.NomeAnimal = nomeAnimalTextBox.Text;
            cls.Dt_nascAnimal = dtNascAnimalDateTimePicker.Text;
            MessageBox.Show("Nome: " + cls.NomeAnimal + "\nNascimento: " + cls.Dt_nascAnimal + "\nRaça: "+cls.IdRaca+".");
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            cls.NomeAnimal = nomeAnimalTextBox.Text;
            cls.cadastrarAnimal();
        }
    }
}
