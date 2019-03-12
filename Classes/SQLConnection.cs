using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReplicator.Classes
{
    public class SQLConnection
    {
        public static List<string> GetTableNames()
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetTableNamesTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetTableNamesTableAdapter();
            GenesisDataSet.CodeReplicator_GetTableNamesDataTable DT = new GenesisDataSet.CodeReplicator_GetTableNamesDataTable();
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

        public static List<string> GetSPNames()
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetSPsTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetSPsTableAdapter();
            GenesisDataSet.CodeReplicator_GetSPsDataTable DT = new GenesisDataSet.CodeReplicator_GetSPsDataTable();
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

        public static DataTable GetParameters(string SPname)
        {
            GenesisDataSetTableAdapters.CodeReplicator_GetParametersTableAdapter TA = new GenesisDataSetTableAdapters.CodeReplicator_GetParametersTableAdapter();
            GenesisDataSet.CodeReplicator_GetParametersDataTable DT = new GenesisDataSet.CodeReplicator_GetParametersDataTable();
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
