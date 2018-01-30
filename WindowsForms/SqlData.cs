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

//SELECT [Column1], [Column3]
//FROM[ApplicationRegister]
//WHERE[Column1] = '3580' AND[Column3] = 'ООО "Светпринт"'
//ORDER BY[Column1] DESC;

namespace WindowsForms
{
    //
    //етаблицы
    //
    enum SqlApplication { ApplicationViewWork, ApplicationTypeWorks, ApplicationCustomers, ApplicationProgreso, ApplicationDrawing, ApplicationPaint, ApplicationSubstrates, ApplicationColor, ApplicationContactCustomers, ApplicationContactsKontinent, ApplicationWorkpieceLength, ApplicationPrint, ApplicationRegister };
    enum SqlSpecification { SpecificationParametersWorkpiece, SpecificationPrametryMachining, SpecificationRotationalSpeed, SpecificationRegistry };
    enum SqlEngraving { EngravingCode, EngravingCompensation, EngravingCutter, EngravingTime, EngravingRegister };
    enum SqlPrinting { TrialPrintingAngle, TrialPrintingMaterial, TrialPrintingPaint, TrialPrintingPantone, TrialPrintingPrintOptions, TrialPrintingPrintSettings, TrialPrintingTime, TrialPrintingRegister };

    class SqlData
    {
        //
        //подключение
        //
        private static string conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\stich.CONTINENT\Source\Repos\WindowsForms\WindowsForms\Resources\Database.mdf;Integrated Security=True";
        private static SqlConnection sqlConnection = new SqlConnection(conect);
        //
        //выборка всей таблицы (настройки)
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
        //выборка всей таблицы (фильтр)
        //
        public static ArrayList GetArrayList(Form form, List<int> column_data, List<string> data, List<int> column_order, List<int> order)
        {
            string command = String.Format("SELECT * FROM [{0}] ", GetTable(form));
            command = String.Format("{0} {1}", command, GetWhere(column_data, data));
            command = String.Format("{0} {1}", command, GetOrderBy(column_order, order));
            //string temp = command;



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
        //выборка по значению
        //
        private static string GetWhere(List<int> column_data, List<string> data)
        {
            string command = String.Empty;
            if (column_data.Count != 0)
            {
                for (int i = 0; i < column_data.Count; i++)
                {
                    if (i == 0)
                        command = String.Format("WHERE[Column{0}] = '{1}'", column_data[i], data[i]);
                    else
                        command = String.Format("{0} AND[Column{1}] = '{2}'", command, column_data[i], data[i]);
                }
            }
            return command;
        }
        //
        //сортировка по столбцам
        //
        private static string GetOrderBy(List<int> column_order, List<int> order)
        {
            string command = String.Empty;
            if (column_order.Count != 0)
            {
                command = String.Format("ORDER BY");
                for (int i = 0; i < column_order.Count; i++)
                {
                    if (i == 0)
                    {
                        if (order[i] == 1)
                            command = String.Format("{0} [Column{1}] DESC", command, column_order[i]);
                        if (order[i] == -1)
                            command = String.Format("{0} [Column{1}]", command, column_order[i]);
                    }
                    else
                    {
                        if (order[i] == 1)
                            command = String.Format("{0}, [Column{1}] DESC", command, column_order[i]);
                        if (order[i] == -1)
                            command = String.Format("{0}, [Column{1}]", command, column_order[i]);
                    }
                }
            }
            //else
            //    command = String.Format("ORDER BY [Column1] DESC");
            return command;
        }
        //
        //выборка одного столбца
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
        //выбор таблицы
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
