﻿using System;
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
    enum SqlApplication { ApplicationViewWork, ApplicationTypeWorks, ApplicationCustomers, ApplicationProgreso, ApplicationDrawing, ApplicationPaint, ApplicationSubstrates, ApplicationColor, ApplicationContactCustomers, ApplicationContactsKontinent, ApplicationWorkpieceLength, ApplicationPrint, ApplicationRegister };
    enum SqlSpecification { SpecificationParametersWorkpiece, SpecificationPrametryMachining, SpecificationRotationalSpeed, SpecificationRegistry };
    enum SqlEngraving { EngravingCode, EngravingCompensation, EngravingCutter, EngravingTime, EngravingRegister };
    enum SqlPrinting { TrialPrintingAngle, TrialPrintingMaterial, TrialPrintingPaint, TrialPrintingPantone, TrialPrintingPrintOptions, TrialPrintingPrintSettings, TrialPrintingTime, TrialPrintingRegister };

    class DataSql
    {
        private static string conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\stich.CONTINENT\Source\Repos\WindowsForms\WindowsForms\Resources\Database.mdf;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection(conect);

        public ArrayList GetArrayList(string table)
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

        public DataTable GetDataTable(string table, string column)
        {
            string command = String.Format("SELECT DISTINCT [{0}] FROM [{1}] ORDER BY [{0}]", column, table);
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
}
