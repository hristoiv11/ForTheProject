using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTheProject
{
    public sealed class HandlerPhoneNumber
    {
        static readonly HandlerPhoneNumber instance = new HandlerPhoneNumber();

        public static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        private HandlerPhoneNumber()
        {
            CreateTable();

            PhoneNumber newP1 = new PhoneNumber()
            {
                Number = "450-444-2312",
                Type = "Work",




            };
            PhoneNumber newP2 = new PhoneNumber()
            {
                Number = "450-312-444",
                Type = "Home",



            };



            //seed the table
            AddPhone(newP1.Number,newP1.Type);
            AddPhone(newP2.Number, newP2.Type);
        }

        public static HandlerPhoneNumber Instance
        {
            get { return instance; }
        }

        public void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(Constring))


            {
                con.Open();
                string drop = "drop table if exists PhoneNumber;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table PERSONS (PhoneNumberId integer primary key, Number text, Type text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        private int AddPhone(string phoneNumber, string phoneType)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO PERSONS (Number,Type) VALUES (@Number, @Type)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Number", phoneNumber);
                insertcom.Parameters.AddWithValue("@Type", phoneType);

                try
                {
                    rows = insertcom.ExecuteNonQuery();

                    // Get the rowid inserted
                    insertcom.CommandText = "select last_insert_rowid()";
                    Int64 LastRowID64 = Convert.ToInt64(insertcom.ExecuteScalar());

                    // Grab the bottom 32 bits as the unique id of the row
                    newId = Convert.ToInt32(LastRowID64);
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newId;
        }

        public int UpdatePhone(PhoneNumber phoneNumber)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "UPDATE Phone SET Number = @Number , Type = @Type, ResumeId = @ResumeId WHERE Id = @Id";


                SQLiteCommand updatecom = new SQLiteCommand(query, conn);
                updatecom.Parameters.AddWithValue("@Id", phoneNumber.PhoneNumberId);
                updatecom.Parameters.AddWithValue("@Number", phoneNumber.Number);
                updatecom.Parameters.AddWithValue("@Type", phoneNumber.Type);
                updatecom.Parameters.AddWithValue("@ResumeId", phoneNumber.ResumeId);
                
                try
                {
                    row = updatecom.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Error Generated. Details:" + e.ToString());
                }

            }
            return row;
        }

    }
}
