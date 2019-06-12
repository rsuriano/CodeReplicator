using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using CodeReplicator.Classes;

namespace CodeReplicator
{
    class FileSpawner
    {
        string folderName;
        string pathString;
        string fileName;
        string dataSetName;
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Genesis;User ID=sa;Password=olympussoftware";
        bool dynamicConnection;

        string trademark;
        string codeHeader;
        string codeFooter;
        string endGame;

        private enum ProcedureZone { Variables, Exec }


        public string FolderName { get => folderName; set => folderName = value; }
        public string PathString { get => pathString; set => pathString = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string CodeHeader { get => codeHeader; set => codeHeader = value; }
        public string CodeFooter { get => codeFooter; set => codeFooter = value; }
        public string EndGame { get => endGame; set => endGame = value; }
        public string DataSetName { get => dataSetName; set => dataSetName = value; }
        public string Trademark { get => trademark; set => trademark = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool DynamicConnection { get => dynamicConnection; set => dynamicConnection = value; }

        //Connection layer file constructor
        public FileSpawner(string layername, string tablename, string DSname, string path, 
                            string filename, List<string> selected_sp, List<bool> returnDTinfo, 
                            string connection, bool isDynamic)
        {
            FolderName = @"" + path;
            PathString = FolderName;
            FileName = filename + ".cs";
            PathString = Path.Combine(PathString, FileName);
            DataSetName = DSname;
            ConnectionString = connection;
            DynamicConnection = isDynamic;

            ////Start assembling the code
            string TradeMark = "////\tCode generated via CodeReplicator v" + Utils.ProgramVersion + " by Ramiro Suriano, for Olympus Software.\t////\n";
            TradeMark += "////\tDate of this code: " + DateTime.Now.ToShortDateString() +"\t\t\t\t\t\t\t\t\t\t////\n\n";
            CodeHeader = "using System;\nusing System.Collections.Generic;\nusing System.Data;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\n\n";
            CodeHeader += TradeMark;
            CodeHeader += "namespace " + layername + "\n{\n" + "\tpublic class Con_" + tablename + "\n\t{\n";
            CodeFooter = "\n\t}\n}";

            //Call to the MethodGenerator
            string finishedMethods = "";
            int index = 0;
            foreach (string method in selected_sp)
            {
                finishedMethods += (NewMethod(method, returnDTinfo[index]));
                index++;
            }

            if (!File.Exists(PathString))
            {
                EndGame = CodeHeader + finishedMethods + CodeFooter;
                File.WriteAllText(PathString, EndGame);
            }
            else
            {
                EndGame = "The file already exists. Please delete it or choose another directory.";
            }


        }

        //SQL Stored Procedures file constructor
        public FileSpawner(string dataBaseName, string tableName, List<string> SPType, string path, string fileName)
        {
            FolderName = @"" + path;
            PathString = FolderName;

            //Creation of date based file name
            string today = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month < 10) today += "0";
            today += DateTime.Now.Month.ToString();

            if (DateTime.Now.Day < 10) today += "0";
            today += DateTime.Now.Day.ToString() + "-";

            if (DateTime.Now.Hour < 10) today += "0";
            today += DateTime.Now.Hour.ToString();

            if (DateTime.Now.Minute < 10) today += "0";
            today += DateTime.Now.Minute.ToString();
            //end of date part


            FileName = today + "-[CodeRep]" + tableName + "SPs.sql";
            PathString = Path.Combine(PathString, FileName);
            DataSetName = dataBaseName;
            
            DataTable column = SQLConnection.GetTableInfo(tableName, ConnectionString);

            ////Start assembling the code
            Trademark =     "/*\tCode generated via CodeReplicator v" + Utils.ProgramVersion + " by Ramiro Suriano & Luciano Lapenna, for Olympus Software.\t*/\n" +
                            "/*\tDate of this code: " + DateTime.Now.ToShortDateString() + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*/\n\n";

            CodeHeader +=   "USE [" + dataBaseName + "]\n" +
                            "GO\n\n" +
                            "" +
                            "SET ANSI_NULLS ON\n" +
                            "GO\n" +
                            "SET QUOTED_IDENTIFIER ON\n" +
                            "GO\n\n";

            string storedProcedure = "";

            for (int a = 0; a < SPType.Count; a++)
            {
                storedProcedure +=  "CREATE PROCEDURE [dbo].[" + SPType[a] + "_" + tableName + "]\n" +
                                    SPGenerator(column, SPType[a], tableName) + "\n\n\n";
            }

            if (!File.Exists(PathString))
            {
                EndGame = Trademark + CodeHeader + storedProcedure;
                File.WriteAllText(PathString, EndGame);
            }
            else
                EndGame = "The file already exists. Please delete it or choose another directory.";

        }

        public string SPGenerator(DataTable column, string SPType, string tableName)
        {
            string storedProcedure = "";
            int rowsCount = column.Rows.Count;
            // Start SQL CODE

            // Common to every procedure: variables

            #region AddVariables

            foreach (DataRow r in column.Rows)
            {
                string colName = r["ColName"].ToString();
                string dataType = r["DataType"].ToString();

                switch (SPType)
                {
                    case "Insert":
                        {
                            // Insert doesn't need "Id" variable
                            if (colName != "Id")
                            {
                                // Differentiate between data types                                    
                                storedProcedure += SwitchVariables(ProcedureZone.Variables, colName, dataType, r["Length"].ToString());
                            }
                            break;
                        }
                    case "Update":
                        {
                            storedProcedure += SwitchVariables(ProcedureZone.Variables, colName, dataType, r["Length"].ToString());

                            break;
                        }
                    case "Get":
                        {
                            storedProcedure += SwitchVariables(ProcedureZone.Variables, colName, dataType, r["Length"].ToString());

                            break;
                        }
                    case "Delete":
                        {
                            storedProcedure += SwitchVariables(ProcedureZone.Variables, colName, dataType, r["Length"].ToString());

                            break;
                        }
                }
            }

            // Removes last 3 digits to prevent SQL syntax errors on Insert, Delete and Update procedures
            if (SPType != "Get")
                storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 2) + "\n";

            else
            {
                // Adds obligatory "response" variable
                storedProcedure += "\t@Response bigint = 0\n";
            }


            storedProcedure += "AS\n\n";

            #endregion

            // Differentiate between procedures
            #region AddProcedure

            switch (SPType)
            {
                case "Insert":
                    {
                        storedProcedure += "INSERT INTO " + tableName + " VALUES(";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();
                            string dataType = r["DataType"].ToString();

                            if (colName != "Id")
                            {
                                if (dataType == "datetime")
                                    storedProcedure += "convert(datetime, @" + colName + ", 120), ";
                                else
                                    storedProcedure += "@" + colName + ", ";
                            }
                                

                        }

                        // Removes last 2 chars to prevent syntax errors
                        storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 2);

                        storedProcedure += ");\n" +
                                            "SELECT TOP 1 Id FROM " + tableName + " ORDER BY Id DESC";                        
                        break;
                    }
                case "Update":
                    {
                        storedProcedure +=  "DECLARE @sql nvarchar(max);\n\n" +
                                            "SET @sql = 'UPDATE " + tableName + " SET'\n\n";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();
                            string dataType = r["DataType"].ToString();

                            if (colName != "Id")
                            {
                                if (dataType == "datetime")
                                {
                                    storedProcedure += "IF @" + colName + " IS NOT NULL\n\t" +
                                                    "SET @sql = @sql + ' " + colName + " = " + "convert(datetime, @" + colName + ", 120),';\n";
                                }
                                else
                                {
                                    storedProcedure += "IF @" + colName + " IS NOT NULL\n\t" +
                                                    "SET @sql = @sql + ' " + colName + " = " + "@" + colName + ",';\n";
                                }
                                
                            }                                
                        }

                        storedProcedure += "\nSET @sql = SUBSTRING(@sql, 1, (LEN(@sql) - 1))\n" +
                                            "SET @sql = @sql + ' WHERE Id = @Id';\n\n";

                        {
                            storedProcedure += "IF NOT(";

                            foreach (DataRow r in column.Rows)
                            {
                                string colName = r["ColName"].ToString();

                                if (colName != "Id")
                                    storedProcedure += "@" + colName + " IS NULL AND ";
                            }

                            storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 5);

                            storedProcedure += ")\n\t" +
                                                "EXEC sp_executesql @sql, N'\n";

                            foreach (DataRow r in column.Rows)
                            {
                                string colName = r["ColName"].ToString();
                                string dataType = r["DataType"].ToString();

                                storedProcedure += SwitchVariables(ProcedureZone.Exec, colName, dataType, r["Length"].ToString());
                            }
                            storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 2);

                            storedProcedure += "',\n\t\t\t";

                            foreach (DataRow r in column.Rows)
                            {
                                string colName = r["ColName"].ToString();
                                string dataType = r["DataType"].ToString();

                                storedProcedure += "@" + colName + ", ";

                                
                            }

                            storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 2);

                            storedProcedure += ";";
                        }
                        break;
                    }
                case "Get":
                    {
                        storedProcedure +=  "DECLARE @sql nvarchar(max);\n" +
                                            "SET @sql = 'SELECT';\n\n" +
                                            "IF @Response != 0\n\t" +
                                                "SET @sql = @sql + ' TOP (@Response)';\n\n" +
                                            "SET @sql = @sql + ' * FROM [" + tableName + "] WHERE 1=1 ';\n\n";



                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();

                            if (colName == "Id" ||
                                colName == "Password" ||
                                colName == "AccessCode")
                            {
                                storedProcedure += "IF @" + colName + " IS NOT NULL\n\t" +
                                                    "SET @sql = @sql + ' AND " + colName + " = @" + colName + "';\n";
                            }
                            else
                            {
                                storedProcedure += "IF @" + colName + " IS NOT NULL\n\t" +
                                                    "SET @sql = @sql + ' AND " + colName + " like @" + colName + "';\n";
                            }

                            
                                                        
                        }

                        storedProcedure += "\nEXEC sp_executesql @sql, N'\n";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();
                            string dataType = r["DataType"].ToString();

                            storedProcedure += SwitchVariables(ProcedureZone.Exec, colName, dataType, r["Length"].ToString());
                        }

                        storedProcedure += "\t\t@Response bigint',\n\t\t";
                        
                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();

                            storedProcedure += "@" + colName + ", ";
                        }

                        storedProcedure += "@Response;";

                        break;
                    }
                case "Delete":
                    {
                        storedProcedure +=  "DECLARE @sql nvarchar(max);\n\n" +
                                            "SET @sql = 'DELETE FROM " + tableName + " WHERE 1=1'\n\n";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();

                            storedProcedure +=  "IF @" + colName + " IS NOT NULL\n\t" +
                                                    "SET @sql = @sql + ' AND " + colName + " = @" + colName + "';\n\n\t" +
                                                    "ELSE ";
                        }

                        storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 8);

                        storedProcedure += "\n\nIF NOT (";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();

                            storedProcedure += "@" + colName + " IS NULL AND ";
                        }

                        storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 5);

                        storedProcedure +=  ")\n\t" +
                                            "EXEC sp_executesql @sql, N'\n";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();
                            string dataType = r["DataType"].ToString();

                            storedProcedure += SwitchVariables(ProcedureZone.Exec, colName, dataType, r["Length"].ToString());
                        }

                        storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 5);

                        storedProcedure += "',\n\t\t";

                        foreach (DataRow r in column.Rows)
                        {
                            string colName = r["ColName"].ToString();

                            storedProcedure += "@" + colName + ", ";
                        }

                        storedProcedure = storedProcedure.Substring(0, storedProcedure.Length - 2);

                        storedProcedure += ";";

                        break;
                    }
            }

            storedProcedure += "\n\n\nGO";
            return storedProcedure;

            #endregion

        }


        public string NewMethod(string methodName, bool returnsDataTable)
        {
            string auxChain;
            string paramNames="";
            DataTable parameters = SQLConnection.GetParameters(methodName, ConnectionString);
            //constructs the datatable type of method
            if (returnsDataTable)
            {
                auxChain = "\n\t\tpublic static DataTable " + methodName+"(";
                //crear funcion
                foreach (DataRow row in parameters.Rows)
                {
                    string varType = row[1].ToString();
                    paramNames += row[0].ToString();
                    paramNames += ", ";
                    if (varType == "varchar" || varType == "datetime") varType = "string";
                    if (varType == "bigint") varType = "int?";
                    if (varType == "bit") varType = "bool";
                    auxChain += varType + " ";
                    auxChain += row[0] + ", ";
                }
                auxChain = auxChain.Remove(auxChain.Length - 2);
                paramNames = paramNames.Remove(paramNames.Length - 2);
                auxChain += ")\n\t\t{\n\t\t\t";
                auxChain += DataSetName + "TableAdapters." + methodName + "TableAdapter TA = new " + DataSetName + "TableAdapters." + methodName + "TableAdapter();\n\t\t\t";
                auxChain += DataSetName + "." + methodName + "DataTable DT = new " + DataSetName + "." + methodName + "DataTable();\n\t\t\t";
                if (DynamicConnection) auxChain += "System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;\n\t\t\tTableAdapterManager.ChangeConnection(ref SQLCONN);\n\t\t\t";
                auxChain += "TA.Fill(DT, " + paramNames + ");\n\t\t\t";
                auxChain += "if (DT != null && DT.Rows.Count > 0) { return DT; } else { return null; }\n\t\t}\n";
            }
            //constructs the bool type of method
            else
            {
                auxChain = "\n\t\tpublic static bool " + methodName + "(";
                foreach (DataRow row in parameters.Rows)
                {
                    string varType = row[1].ToString();
                    paramNames += row[0].ToString();
                    paramNames += ", ";
                    if (varType == "varchar") varType = "string";
                    if (varType == "bigint") varType = "int?";
                    auxChain += varType + " ";
                    auxChain += row[0] + ", ";
                }
                auxChain = auxChain.Remove(auxChain.Length - 2);
                paramNames = paramNames.Remove(paramNames.Length - 2);
                auxChain += ")\n\t\t{\n\t\t\t";
                auxChain += "QTACustomized QTA = new QTACustomized();\n\t\t\tint response = QTA." + methodName + "(" + paramNames + ");\n\t\t\tif (response > 0) { return true; } else { return false; }\n\t\t}\n";
            }
            
            return auxChain;
        }

        private string SwitchVariables(
            ProcedureZone procedureZone,
            string colName,
            string dataType,
            string dataSize)
        {
            string procedure = "";

            switch (procedureZone)
            {
                case ProcedureZone.Variables:
                    {
                        switch (dataType)
                        {
                            case "varchar":
                                {
                                    procedure += "\t@" + colName + " " + dataType + "(" + dataSize + ") = NULL,\n";
                                    break;
                                }
                            case "decimal":
                                {
                                    procedure += "\t@" + colName + " " + dataType + "(18,0) = NULL,\n";
                                    break;
                                }
                            case "time":
                                {
                                    procedure += "\t@" + colName + " " + dataType + "(2) = NULL,\n";
                                    break;
                                }
                            default:
                                {
                                    procedure += "\t@" + colName + " " + dataType + " = NULL,\n";
                                    break;
                                }
                        }

                        break; ;
                    }
                case ProcedureZone.Exec:
                    {
                        switch (dataType)
                        {
                            case "varchar":
                                {
                                    procedure += "\t\t@" + colName + " " + dataType + "(" + dataSize + "),\n";
                                    break;
                                }
                            case "decimal":
                                {
                                    procedure += "\t\t@" + colName + " " + dataType + "(18,0),\n";
                                    break;
                                }
                            case "time":
                                {
                                    procedure += "\t\t@" + colName + " " + dataType + "(2),\n";
                                    break;
                                }
                            default:
                                {
                                    procedure += "\t\t@" + colName + " " + dataType + ",\n";
                                    break;
                                }
                        }

                        break;
                    }
            }

            return procedure;
        }

    }
}