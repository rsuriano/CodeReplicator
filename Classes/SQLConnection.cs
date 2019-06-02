using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReplicator.Classes
{
    public static class TableAdapterManager
    {
        public static void ChangeConnection(ref System.Data.SqlClient.SqlConnection MyConnection, string newConnection)
        {

            //string connection = WebConfigurationManager.AppSettings["ConnectionString"];
            MyConnection.ConnectionString = newConnection;

        }
    }

    public class SQLConnection
    {
        public static List<string> GetTableNames(string DBstring)
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetTableNamesTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetTableNamesTableAdapter();
            GenesisDataSet.CodeReplicator_GetTableNamesDataTable DT = new GenesisDataSet.CodeReplicator_GetTableNamesDataTable();
            //Choose the database (with the connection string provided in form1
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            TableAdapterManager.ChangeConnection(ref SQLCONN, DBstring);

            TA.Fill(DT);

            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> aux = new List<string>();
                foreach (DataRow row in DT)
                {
                    aux.Add(row[0].ToString());
                }
                return aux;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetSPNames(string DBstring)
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetSPsTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetSPsTableAdapter();
            GenesisDataSet.CodeReplicator_GetSPsDataTable DT = new GenesisDataSet.CodeReplicator_GetSPsDataTable();
            //Choose the database (with the connection string provided in form1
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            TableAdapterManager.ChangeConnection(ref SQLCONN, DBstring);

            TA.Fill(DT);

            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> aux = new List<string>();
                foreach (DataRow row in DT)
                {
                    aux.Add(row[0].ToString());
                }
                return aux;
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetTableInfo(string TableName, string DBstring)
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetTableInfoTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetTableInfoTableAdapter();
            GenesisDataSet.CodeReplicator_GetTableInfoDataTable DT = new GenesisDataSet.CodeReplicator_GetTableInfoDataTable();
            //Choose the database (with the connection string provided in form1
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            TableAdapterManager.ChangeConnection(ref SQLCONN, DBstring);

            TA.Fill(DT, TableName);

            if (DT != null && DT.Rows.Count > 0)
            {
                return DT;
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetParameters(string SPname, string DBstring)
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetParametersTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetParametersTableAdapter();
            GenesisDataSet.CodeReplicator_GetParametersDataTable DT = new GenesisDataSet.CodeReplicator_GetParametersDataTable();
            //Choose the database (with the connection string provided in form1
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            TableAdapterManager.ChangeConnection(ref SQLCONN, DBstring);

            TA.Fill(DT, SPname);

            if (DT != null && DT.Rows.Count > 0)
            {
                DataTable AuxTable = new DataTable("Params");
                AuxTable.Columns.Add("Type", typeof(String));
                AuxTable.Columns.Add("Name", typeof(String));
                AuxTable.Columns.Add("Length", typeof(int));

                foreach (DataRow row in DT)
                {
                    string varTypeValue = row[0].ToString();
                    varTypeValue = varTypeValue.Substring(1);

                    row[0] = varTypeValue;
                    AuxTable.Rows.Add(row.ItemArray);
                }
                return AuxTable;
            }
            else
            {
                return null;
            }
        }
    }
}
