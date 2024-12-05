    using MySqlConnector;
    using System.Windows.Forms;
    using System;

    namespace おみくじ
    {
        public partial class Form1 : Form
        {
            // 接続情報
            private string connectionString;
            private Random random = new Random();

            public Form1()
            {
                connectionString = "Server=localhost;Database=Major;UserID=root;Password=kcsf;";
                InitializeComponent();
            }

            private void btnLottery_Click(object sender, EventArgs e)
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    int randomValue = random.Next(1, 8);

                    //各メッセージのSQL
                    MySqlCommand cmdFortune = new MySqlCommand($"SELECT fortunerole FROM fortune WHERE id = {randomValue};", con);
                    MySqlCommand cmdF = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'F';", con); // 全体運
                    MySqlCommand cmdD = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'D';", con); // 願望
                    MySqlCommand cmdL = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'L';", con); // 恋愛
                    MySqlCommand cmdS = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'S';", con); // 学問
                    MySqlCommand cmdB = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'B';", con); // 商売
                    MySqlCommand cmdI = new MySqlCommand($"SELECT fd.message FROM Fortune f JOIN FortuneDetail fd ON f.id = fd.id WHERE f.id = {randomValue} AND fd.category = 'I';", con); // 病気

                    //結果を表示
                    lblFortune.Text = GetMessageFromCommand(cmdFortune);
                    lblFr.Text = GetMessageFromCommand(cmdF);
                    lblDr.Text = GetMessageFromCommand(cmdD);
                    lblLr.Text = GetMessageFromCommand(cmdL);
                    lblSr.Text = GetMessageFromCommand(cmdS);
                    lblBr.Text = GetMessageFromCommand(cmdB);
                    lblIr.Text = GetMessageFromCommand(cmdI);
                }
            }
            //SQLからメッセージを取得
            private string GetMessageFromCommand(MySqlCommand command)
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
                return "データがありません";
            }
        }
    }
