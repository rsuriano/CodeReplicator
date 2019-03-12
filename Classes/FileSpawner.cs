using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace CodeReplicator
{
    class FileSpawner
    {
        string folderName;
        string pathString;
        string fileName;
        string dataSetName;

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

        public FileSpawner(string layername, string tablename, string DSname, string path, string filename, List<string> selected_sp, List<bool> returnDTinfo)
        {
            FolderName = @"" + path;
            PathString = FolderName;
            //PathString = Path.Combine(FolderName, "TestCode");
            FileName = filename + ".cs";
            PathString = Path.Combine(PathString, FileName);
            DataSetName = DSname;

            ////Start assembling the code
            string TradeMark = "////\tCode generated via CodeReplicator v1.0. By Ramiro Suriano, for Olympus Software.\t////\n";
            TradeMark += "////\tDate of this code: " + DateTime.Now.ToShortDateString() +"\t\t\t\t\t\t\t////\n\n";
            CodeHeader = "using System;\nusing System.Collections.Generic;\nusing System.Data;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\n\n";
            CodeHeader += TradeMark;
            CodeHeader += "namespace " + layername + "\n{\n" + "\tpublic class Con_" + tablename + "\n\t{\n";
            CodeFooter = "\n\t}\n}";

            //Call to the MethodGenerator
            string finishedMethods = "";
            int index = 0;
            foreach (string method in selected_sp)
            {
                index++;
                finishedMethods += (NewMethod(method, returnDTinfo[index]));
            }

            if (!File.Exists(PathString))
            {
                EndGame = CodeHeader + finishedMethods + CodeFooter;
                File.WriteAllText(PathString, endGame);
            }
            else
            {
                EndGame = "The file already exists. Please delete it or choose another directory.";
            }


        }

        public string NewMethod(string methodName, bool returnsDataTable)
        {
            string auxChain;
            string paramNames="";
            DataTable parameters = Classes.SQLConnection.GetParameters(methodName);
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
                auxChain += "System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;\n\t\t\tTableAdapterManager.ChangeConnection(ref SQLCONN);\n\t\t\t";
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
                    if (varType == "bigint") varType = "int";
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
