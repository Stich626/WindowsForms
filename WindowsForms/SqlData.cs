using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    //
    //перечисление всех таблиц
    //
    enum SqlApplication { ApplicationViewWork, ApplicationTypeWorks, ApplicationCustomers, ApplicationProgreso, ApplicationDrawing, ApplicationPaint, ApplicationSubstrates, ApplicationColor, ApplicationContactCustomers, ApplicationContactsKontinent, ApplicationWorkpieceLength, ApplicationPrint, ApplicationRegister };
    enum SqlSpecification { SpecificationParametersWorkpiece, SpecificationPrametryMachining, SpecificationRotationalSpeed, SpecificationRegistry };
    enum SqlEngraving { EngravingCode, EngravingCompensation, EngravingCutter, EngravingTime, EngravingRegister };
    enum SqlPrinting { TrialPrintingAngle, TrialPrintingMaterial, TrialPrintingPaint, TrialPrintingPantone, TrialPrintingPrintOptions, TrialPrintingPrintSettings, TrialPrintingTime, TrialPrintingRegister };

    class SqlData
    {
        //
        //подключения к базе данных
        //
        private static string conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\stich.CONTINENT\Source\Repos\WindowsForms\WindowsForms\Resources\Database.mdf;Integrated Security=True";
        private static SqlConnection sqlConnection = new SqlConnection(conect);
        //
        //Выборка всей таблицы с сотритровкой (убывание) по первому столбцу
        //
        public static ArrayList GetArrayList(string table)
        {
            ArrayList arrayList = new ArrayList();
            string command = String.Format("SELECT * FROM[{0}] ORDER BY[Column1] DESC", table);
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (sqlDataReader.HasRows)
                foreach (DbDataRecord result in sqlDataReader)
                    arrayList.Add(result);
            sqlConnection.Close();
            return arrayList;
        }
        //
        //выборка всей таблицы с разной сортировкой по столбцам
        //
        public static ArrayList GetArrayList(Form form, List<int> column)
        {
            string command = String.Empty;
            if (column.Count != 0)
            {
                command = String.Format("SELECT * FROM {0} ORDER BY", GetTable(form));
                for (int i = 0; i < column.Count; i++)
                {
                    if (i == 0)
                    {
                        if(column[i] > 0)
                            command = String.Format("{0} [Column{1}] DESC", command, column[i]);
                        else
                            command = String.Format("{0} [Column{1}]", command, -(column[i]));
                    }
                    else
                    {
                        if (column[i] > 0)
                            command = String.Format("{0}, [Column{1}] DESC", command, column[i]);
                        else
                            command = String.Format("{0}, [Column{1}]", command, -(column[i]));
                    }
                }
            }
            else
                command = String.Format("SELECT * FROM[{0}] ORDER BY[Column1] DESC", GetTable(form));
            ArrayList arrayList = new ArrayList();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (sqlDataReader.HasRows)
                foreach (DbDataRecord result in sqlDataReader)
                    arrayList.Add(result);
            sqlConnection.Close();
            return arrayList;
        }
        //
        //выборка из таблицы одного столбца с сотритровкой (убывание)
        //
        public static DataTable GetDataTable(Form form, string column)
        {
            string command = String.Format("SELECT DISTINCT [{0}] FROM [{1}] ORDER BY [{0}] DESC", column, GetTable(form));
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        //
        //выбор таблицы в зависимости от формы
        //
        private static string GetTable(Form form)
        {
            string table = String.Empty;
            if (form is Registry)
            {
                Registry registry = form as Registry;
                switch (registry.typeForm)
                {
                    case TypeForm.application: table = SqlApplication.ApplicationRegister.ToString(); break;
                    case TypeForm.specification: table = SqlSpecification.SpecificationRegistry.ToString(); break;
                    case TypeForm.engraving: table = SqlEngraving.EngravingRegister.ToString(); break;
                    case TypeForm.printing: table = SqlPrinting.TrialPrintingRegister.ToString(); break;
                }
            }
            return table;
        }
    }
}
