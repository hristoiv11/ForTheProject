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

        static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

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
            AddPhone(newP1);
            AddPhone(newP2);
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

                string table = "create table PhoneNumber (PhoneNumberId integer primary key, Number text, Type text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        public int AddPhone(PhoneNumber phoneNumber)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO PhoneNumber (Number,Type) VALUES (@Number, @Type)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Number", phoneNumber.Number);
                insertcom.Parameters.AddWithValue("@Type", phoneNumber.Type);

                try
                {
                    rows = insertcom.ExecuteNonQuery();

                    // Get the rowid inserted
                    insertcom.CommandText = "select last_insert_rowid()";
                    long LastRowID64 = Convert.ToInt64(insertcom.ExecuteScalar());

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

                string query = "UPDATE PhoneNumber SET Number = @Number , Type = @Type, ResumeId = @ResumeId WHERE Id = @Id";


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
        public List<PhoneNumber> ReadAllPhoneNumbers()
        {
            List<PhoneNumber> listPhoneNumbers = new List<PhoneNumber>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from PhoneNumber", conn);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhoneNumber phoneNumber = new PhoneNumber();
                        if (int.TryParse(reader["Id"].ToString(), out int id2))
                        {
                            phoneNumber.PhoneNumberId = id2;
                        }

                        phoneNumber.Number = reader["Number"].ToString();
                        phoneNumber.Type = reader["Type"].ToString();




                        listPhoneNumbers.Add(phoneNumber);
                    }
                }

            }

            return listPhoneNumbers;

        }
    }

}

