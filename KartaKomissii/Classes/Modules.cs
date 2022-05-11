using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.ComponentModel;

namespace Commission_map.Classes
{
    public class Modules : IDisposable
    {
        private IntPtr handle;
        private Component component = new Component();
        private bool disposed = false;

        public Modules(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    component.Dispose();
                }

                CloseHandle(handle);
                handle = IntPtr.Zero;

                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~Modules()
        {
            Dispose(disposing: false);
        }

        // ////////////////////////////////
        
        readonly string Sql = Classes.PassLogin.connectionString[0].ToString();

        public void Command(string _command)
        {
            using (SqlConnection _connection = new SqlConnection(Sql))
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand(_command, _connection))
                {
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Reader(string _command, out SqlDataReader _reader)
        {
            using (SqlConnection _connection = new SqlConnection(Sql))
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand(_command, _connection))
                {
                    _reader = command.ExecuteReader();
                }
            }
        }

        public SqlDataReader Reader1(string _command)
        {
            SqlDataReader _reader;
            using (SqlConnection _connection = new SqlConnection(Sql))
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand(_command, _connection))
                {
                    _reader = command.ExecuteReader();
                    return _reader;
                }
            }
        }

        public void Close()
        {
            using (SqlConnection _connection = new SqlConnection(Sql))
            {
                _connection.Close();
            }
        }
        public void AddToGrid(string command, string lastIdCheck, string getTableName, DataGridView dataGridView)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Sql))
            {
                int value;
                int i;
                int lastId = 0;
                SqlDataReader reader;
                List<string[]> data = new List<string[]>();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                sqlConnection.Open();
                using (SqlCommand sqlLastIdCheck = new SqlCommand(lastIdCheck, sqlConnection))
                {
                    SqlDataReader readerId = sqlLastIdCheck.ExecuteReader();
                    readerId.Read();
                    if (int.TryParse(readerId[0].ToString(), out value))
                    {
                        lastId = value;
                    }
                    readerId.Close();
                }
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        data.Add(new string[lastId]);
                        for (i = 0; i < lastId; i++)
                        {
                            data[data.Count - 1][i] = reader[i].ToString().Trim();
                        }
                    }
                    reader.Close();
                }
                using (SqlCommand getName = new SqlCommand(getTableName, sqlConnection))
                {
                    reader = getName.ExecuteReader();
                    i = 0;
                    while (reader.Read())
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        dataGridView.Columns.Add(column);
                        dataGridView.Columns[i].HeaderText = reader[0].ToString().Trim();
                        i++;
                    }
                    reader.Close();
                    foreach (string[] s in data)
                    {
                        dataGridView.Rows.Add(s);
                    }
                    sqlConnection.Close();
                }
            }            
        }
    }
}
