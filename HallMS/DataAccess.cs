using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMS
{
   public class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Movietms");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }



        public DataTable Loginm(Login l)
        {

            string query = string.Format("Select * from Manager where id= '" + l.Userid + "' and password='" + l.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable Logine(Login l)
        {

            string query = string.Format("Select * from Employee where id= '" + l.Userid + "' and password='" + l.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable managerinfo(Login u)
        {
            string query = string.Format("Select * from Manager ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }
      

        public DataTable managerinfosearch(Login u)
        {
            string query = string.Format("select * from Manager where name='" + u.name + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public int Addmovie(movie u)
        {
            int i = 0;
            string query = "INSERT INTO Ticket(showname,type,price,date,start,ending,status,slot,position) VALUES ('" + u.showname + "','" + u.type + "','" + u.price + "','" + u.date + "','" + u.start + "','" + u.end + "','Active','" + u.slot + "','" + u.position + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            i = cmd.ExecuteNonQuery();

            return i;

        }


        public DataTable moviesearch(movie u)
        {
            string query = string.Format("select * from Ticket where showname like '" + u.showname + "%';");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable movielist(movie u)
        {
            string query = string.Format("select * from Ticket where status ='Active'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public void sellticket(Ticket u)
        {

            string query = "INSERT INTO soldticket(showname,type,price,date,start,ending,slot,position,Buyer,Buyerphonno,ticket,status) VALUES ('" + u.showname + "','" + u.type + "','" + u.price + "','" + u.date + "','" + u.start + "','" + u.end + "','" + u.slot + "','" + u.position + "','" + u.bname + "','" + u.bphone + "','" + u.ticket + "','sold')";
            string query1 = "UPDATE Ticket SET slot= '" + u.updateslot + "' Where sl='" + u.sl + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd1 = new SqlCommand(query1, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();


        }



        public int updateslot(Ticket u)
        {
            int i = 0;
            string query = String.Format("UPDATE Ticket SET status='Full' where sl='{0}'", u.sl);
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }


        public DataTable sellinfo(Ticket u)
        {
            string query = string.Format("select * from Soldticket where status ='sold'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable housefulllist(movie u)
        {
            string query = string.Format("select * from Ticket where status ='Full'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable sellinfosearch(Ticket u)
        {
            string query = string.Format("select * from Soldticket where status ='sold' and showname like '" + u.showname + "%';");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable housefulllistsearch(movie u)
        {
            string query = string.Format("select * from Ticket where status ='Full' and showname like '" + u.showname + "%';");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable profiledata(Login u)
        {
            string query = string.Format("Select * from Employee where id='"+u.Userid+"'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public int employeeupdate(Login u)
        {
            int i = 0;
            string query = String.Format("UPDATE Employee SET phone='" + u.phone + "',password='" + u.Password + "',address='" + u.address + "',squestion='" + u.ques + "',sans='" + u.ans + "' where id='{0}'", u.Userid);
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }


        public int updatemovie(movie u)
        {
            int i = 0;
            string query = String.Format("UPDATE Ticket SET showname='" + u.showname + "',type='" + u.type + "',price='" + u.price + "',date='" + u.date + "',start='" + u.start + "' ,ending='" + u.end + "' ,status='Active' ,slot='" + u.slot + "' ,position='" + u.position + "'  where sl='{0}'", u.sl);
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int CreateAccountemployee(Login u)
        {
            int i = 0;
            string query = "INSERT INTO Employee(name,phone,password,address,email,squestion,sans) VALUES ('" + u.name + "','" + u.phone + "', '" + u.Password + "', '" + u.address + "','" + u.email + "','" + u.ques + "','" + u.ans + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            i = cmd.ExecuteNonQuery();

            return i;

        }


        public DataTable fetchid(Login u)
        {
            string query = string.Format("Select id from Employee where name='{0}' and password='{1}' and squestion='{2}' and phone='{3}'", u.name, u.Password, u.ques, u.phone);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            //con.Close();
            return dt;
        }

        public DataTable allmovie(movie u)
        {
            string query = string.Format("Select * from Ticket");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public int Deletemovei(movie u)
        {
            int i = 0;
            string query = String.Format("Delete from Ticket where sl='" + u.sl + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }


        public int UpdateAnouncement(movie u)
        {
            int i = 0;
            string query = String.Format("UPDATE Anouncement SET text='" + u.text + "' where sl='1'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }


        public DataTable Anouncement(movie u)
        {
            string query = string.Format("Select text from Anouncement where sl='1' ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable forgetem(Login l)
        {

            string query = string.Format("Select * from Employee where id= '" + l.Userid + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable forgetman(Login l)
        {

            string query = string.Format("Select * from Manager where id= '" + l.Userid + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;

        }



    }
}
