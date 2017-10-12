using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    enum SqlApplication { ApplicationViewWork, ApplicationTypeWorks, ApplicationCustomers, ApplicationProgreso, ApplicationDrawing, ApplicationPaint, ApplicationSubstrates, ApplicationColor, ApplicationContactCustomers, ApplicationContactsKontinent, ApplicationWorkpieceLength };

    class SqlQuery
    {
        private static string conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\stich.CONTINENT\Source\Repos\WindowsForms\WindowsForms\Database.mdf;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection(conect);

        public ArrayList GetArrayList(string table)
        {
            ArrayList arrayList = new ArrayList();
            string command = String.Format("SELECT * FROM[{0}] ORDER BY[Column1]", table);
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (sqlDataReader.HasRows)
                foreach (DbDataRecord result in sqlDataReader)
                    arrayList.Add(result);
            sqlConnection.Close();
            return arrayList;
        }
    }
}
