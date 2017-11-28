using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCOCreater
{
    public class ConnectionHelper
    {
        private static readonly Dictionary<Type, string> TypeAliases = new Dictionary<Type, string>
        {
            { typeof(int), "int" },
            { typeof(short), "short" },
            { typeof(byte), "byte" },
            { typeof(byte[]), "byte[]" },
            { typeof(long), "long" },
            { typeof(double), "double" },
            { typeof(decimal), "decimal" },
            { typeof(float), "float" },
            { typeof(bool), "bool" },
            { typeof(string), "string" }
        };

        private static readonly HashSet<Type> NullableTypes = new HashSet<Type>
        {
            typeof(int),
            typeof(short),
            typeof(long),
            typeof(double),
            typeof(decimal),
            typeof(float),
            typeof(bool),
            typeof(DateTime)
        };

        public static string PrintClass(IDbConnection connection, string sql, string className, ref DataTable tableSchema)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            IDataReader reader = cmd.ExecuteReader();

            StringBuilder builder = new StringBuilder();
            do
            {
                if (reader.FieldCount <= 1) continue;

                builder.AppendFormat("public class {0}{1}", className, Environment.NewLine);
                builder.AppendLine("{");
                tableSchema = reader.GetSchemaTable();

                foreach (DataRow row in tableSchema.Rows)
                {
                    var type = (Type)row["DataType"];
                    var name = TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
                    var isNullable = (bool)row["AllowDBNull"] && NullableTypes.Contains(type);
                    var collumnName = (string)row["ColumnName"];

                    builder.AppendLine(string.Format("\tpublic {0}{1} {2} {{ get; set; }}", name, isNullable ? "?" : string.Empty, collumnName));
                    builder.AppendLine();
                }

                builder.AppendLine("}");
                builder.AppendLine();
            } while (reader.NextResult());

            return builder.ToString();
        }
    }
}
