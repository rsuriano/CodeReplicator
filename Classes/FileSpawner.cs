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
                    
            // Adds variables
            for (int a = 0; a < column.Rows.Count; a++)
            {
                if(SPType == "Insert")
                {
                    if (column.Rows[a]["ColName"].ToString() != "Id")
                    {
                        if (a != column.Rows.Count - 1)
                        {
                            if (column.Rows[a]["DataType"].ToString() == "varchar")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL,\n";

                            else if (column.Rows[a]["DataType"].ToString() == "decimal")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL,\n";

                            else if (column.Rows[a]["DataType"].ToString() == "time")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL,\n";

                            else
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL,\n";
                        }
                        else
                        {
                            if (column.Rows[a]["DataType"].ToString() == "varchar")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL\n";

                            else if (column.Rows[a]["DataType"].ToString() == "decimal")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL\n";

                            else if (column.Rows[a]["DataType"].ToString() == "time")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL\n";

                            else
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL\n";
                        }
                    }
                }
                else if (SPType == "Update")
                {
                    if (column.Rows[a]["ColName"].ToString() != "Id")
                    {
                        if (a != column.Rows.Count - 1)
                        {
                            if (column.Rows[a]["DataType"].ToString() == "varchar")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL,\n";

                            else if (column.Rows[a]["DataType"].ToString() == "decimal")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL,\n";

                            else if (column.Rows[a]["DataType"].ToString() == "time")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL,\n";

                            else
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL,\n";
                        }
                        else
                        {
                            if (column.Rows[a]["DataType"].ToString() == "varchar")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL\n";

                            else if (column.Rows[a]["DataType"].ToString() == "decimal")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL\n";

                            else if (column.Rows[a]["DataType"].ToString() == "time")
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL\n";

                            else
                                storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL\n";
                        }
                    }
                    else
                        storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + ",\n";
                }
                else
                {
                    if (a != column.Rows.Count - 1)
                    {
                        if (column.Rows[a]["DataType"].ToString() == "varchar")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL,\n";

                        else if (column.Rows[a]["DataType"].ToString() == "decimal")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL,\n";

                        else if (column.Rows[a]["DataType"].ToString() == "time")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL,\n";

                        else
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL,\n";
                    }
                    else
                    {
                        if (column.Rows[a]["DataType"].ToString() == "varchar")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ") = NULL\n";

                        else if (column.Rows[a]["DataType"].ToString() == "decimal")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0) = NULL\n";

                        else if (column.Rows[a]["DataType"].ToString() == "time")
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2) = NULL\n";

                        else
                            storedProcedure += "\t@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + " = NULL\n";
                    }
                }
                if(SPType == "Get")
                {
                    storedProcedure += "\t@Response bigint = 0\n";
                }
            }

            storedProcedure += "AS\n\n";

            if (SPType == "Insert")
            {
                storedProcedure += "INSERT INTO " + tableName + "(";

                for (int a = 0; a < column.Rows.Count; a++)
                {
                    if (column.Rows[a]["ColName"].ToString() != "Id")
                    {
                        if (a != column.Rows.Count - 1)
                            storedProcedure += "" + column.Rows[a]["ColName"] + ", ";
                        else
                            storedProcedure += "" + column.Rows[a]["ColName"];
                    }
                }

                storedProcedure += ") VALUES (";

                for (int a = 0; a < column.Rows.Count; a++)
                {
                    if(column.Rows[a]["ColName"].ToString() != "Id")
                    {
                        if (column.Rows[a]["DataType"].ToString() == "datetime")
                            storedProcedure += "convert(datetime, @" + column.Rows[a]["ColName"] + ", 120), ";

                        else
                        {
                            if (a != column.Rows.Count - 1)
                                storedProcedure += "@" + column.Rows[a]["ColName"] + ", ";
                            else
                                storedProcedure += "@" + column.Rows[a]["ColName"];
                        }
                    }    
                }

                storedProcedure += ");\n";
                storedProcedure += "SELECT TOP 1 Id FROM " + tableName + " ORDER BY Id DESC";                
            }
            else
            {
                storedProcedure += "DECLARE @sql nvarchar(max);\n\n";

                // Detect the sp's type
                // GET
                if (SPType == "Get")
                {
                    storedProcedure += "SSET @sql = 'SELECT';\n" +
                                        "IF @Response != 0 \n" +
                                        "\tSET @sql = @sql + ' TOP (@Response)'; \n" +
                                        "SET @sql = @sql + ' * FROM [" + tableName + "] WHERE 1=1 ';\n\n";

                }
                // DELETE
                else if (SPType == "Delete")
                {
                    storedProcedure += "SET @sql = 'DELETE FROM " + tableName + " WHERE 1 = 1'\n\n";
                }
                // UPDATE
                else if (SPType == "Update")
                {
                    storedProcedure += "SET @sql = 'UPDATE " + tableName + " SET'\n\n";

                    for (int a = 0; a < column.Rows.Count; a++)
                    {
                        if (column.Rows[a]["ColName"].ToString() != "Id")
                        {
                            storedProcedure += "IF @" + column.Rows[a]["ColName"] + " IS NOT NULL\n\t" +
                                                "SET @sql = @sql + ' " + column.Rows[a]["ColName"] + " = @" + column.Rows[a]["ColName"] + ", ';\n";
                        }
                    }

                    storedProcedure +=  "\n\n" +
                                        "SET @sql = SUBSTRING(@sql, 1, (LEN(@sql) - 1))\n" +
                                        "SET @sql = @sql + ' WHERE Id = @Id';\n\n";
                }

                if (SPType != "Update")
                {
                    for (int a = 0; a < column.Rows.Count; a++)
                        storedProcedure += "IF " + "@" + column.Rows[a]["ColName"] + " IS NOT NULL\n\t" +
                                                "SET @sql = @sql + ' AND " + column.Rows[a]["ColName"] + " = " + "@" + column.Rows[a]["ColName"] + "';\n";
                }                
                if (SPType != "Get")
                {
                    storedProcedure += "\n\nIF NOT(";

                    for (int a = 0; a < column.Rows.Count; a++)
                        if (a != column.Rows.Count - 1)
                            storedProcedure += "@" + column.Rows[a]["ColName"] + " IS NULL AND ";
                        else
                            storedProcedure += "@" + column.Rows[a]["ColName"] + " IS NULL)";                    
                }
                storedProcedure += "\nEXEC sp_executesql @sql, N'\n\t";
                
                for (int a = 0; a < column.Rows.Count; a++)
                {                    
                    if (column.Rows[a]["DataType"].ToString() == "varchar")
                        storedProcedure += "@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(" + column.Rows[a]["Length"] + ")";

                    else if (column.Rows[a]["DataType"].ToString() == "decimal")
                        storedProcedure += "@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(18,0)";

                    else if (column.Rows[a]["DataType"].ToString() == "time")
                        storedProcedure += "@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"] + "(2)";

                    else
                        storedProcedure += "@" + column.Rows[a]["ColName"] + " " + column.Rows[a]["DataType"];

                    if (a != column.Rows.Count - 1)
                        storedProcedure += ",\n\t";
                    else
                    {
                        //GET Response modifier
                        if (SPType == "Get")
                        {
                            storedProcedure += ",\n\t";
                            storedProcedure += "@Response bigint";
                        }
                        else
                        {
                            storedProcedure += "\n\t";
                        }
                    }
                        
                }
                

                storedProcedure += "',\n\t";

                for (int a = 0; a < column.Rows.Count; a++)
                {
                    if ( a != column.Rows.Count - 1)
                        storedProcedure += "@" + column.Rows[a]["ColName"] + ", ";
                    else
                    {
                        //GET Response modifier
                        if (SPType == "Get")
                        {
                            storedProcedure += "@" + column.Rows[a]["ColName"] + ", ";
                            storedProcedure += "@Response;";
                        }
                        else
                        {
                            storedProcedure += "@" + column.Rows[a]["ColName"] + ";";
                        }
                    }
                }
            }
            storedProcedure += "\n\nGO";
            return storedProcedure;
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
                    if (varType == "varchar") varType = "string";
                    if (varType == "bigint") varType = "int?";
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

    }
}
