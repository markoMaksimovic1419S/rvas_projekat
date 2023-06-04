using Microsoft.Data.SqlClient;

namespace rvas_projekat.Models
{
    public class Poruka
    {
        public int id { get; set; }
        public string poruku_poslao { get; set; }
        public string text_poruke { get; set; }
        public int id_sobe { get; set; }
        public void SaveDetails()
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=rvas_projekat;Trusted_Connection=True;MultipleActiveResultSets=true");
            string query = "INSERT INTO Poruka(poruku_poslao, text_poruke, id_sobe) values ('" + poruku_poslao + "','" + text_poruke + "','" + id_sobe.ToString() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Poruka()
        {

        }
    }
}
