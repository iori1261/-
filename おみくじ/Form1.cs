using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace おみくじ
{
    public partial class Form1 : Form
    {
        //接続情報
        String connection;
        Random random = new Random();

        public Form1()
        {
            String connection = "Server=localhost;Database=Major;UserID=root;Password=kcsf;Poolng=true;";
            InitializeComponent();
        }

        private void btnLottery_Click(object sender, EventArgs e)
        {
            
            int randomValue3 = random.Next(1, 8);
            
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmdFortune = new MySqlCommand("SELECT * FROM fortune;", con);
            MySqlCommand cmdF = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
            MySqlCommand cmdD = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
            MySqlCommand cmdL = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
            MySqlCommand cmdS = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
            MySqlCommand cmdB = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
            MySqlCommand cmdI = new MySqlCommand("SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = 1 AND fd.category = 'A';", con);
        }
    }
}
