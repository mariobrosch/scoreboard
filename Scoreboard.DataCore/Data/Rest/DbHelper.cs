using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

// Copied from: https://stackoverflow.com/a/47273/1343546 Credits to: FlySwat (https://stackoverflow.com/users/1965/flyswat)

namespace Scoreboard.DataCore.Data.Rest
{
    internal class DbHelper
    {
        private static void Main(string[] args)
        {
            List<TableClass> tables = new List<TableClass>();

            // Pass assembly name via argument
            Assembly a = Assembly.LoadFile(args[0]);

            Type[] types = a.GetTypes();

            // Get Types in the assembly.
            foreach (Type t in types)
            {
                TableClass tc = new TableClass(t);
                tables.Add(tc);
            }

            // Create SQL for each table
            foreach (TableClass table in tables)
            {
                Console.WriteLine(table.CreateTableScript());
                Console.WriteLine();
            }

            // Total Hacked way to find FK relationships! Too lazy to fix right now
            foreach (TableClass table in tables)
            {
                foreach (KeyValuePair<string, Type> field in table.Fields)
                {
                    foreach (TableClass t2 in tables)
                    {
                        if (field.Value.Name == t2.ClassName)
                        {
                            // We have a FK Relationship!
                            Console.WriteLine("GO");
                            Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
                            Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
                            Console.WriteLine("GO");

                        }
                    }
                }
            }
        }
    }

    public class TableClass
    {
        private Dictionary<Type, string> DataMapper
        {
            get
            {
                // Add the rest of your CLR Types to SQL Types mapping here
                Dictionary<Type, string> dataMapper = new Dictionary<Type, string>
                {
                    { typeof(int), "BIGINT" },
                    { typeof(string), "NVARCHAR(500)" },
                    { typeof(bool), "BIT" },
                    { typeof(DateTime), "DATETIME" },
                    { typeof(float), "FLOAT" },
                    { typeof(decimal), "DECIMAL(18,0)" },
                    { typeof(Guid), "UNIQUEIDENTIFIER" }
                };

                return dataMapper;
            }
        }

        public List<KeyValuePair<string, Type>> Fields { get; set; } = new List<KeyValuePair<string, Type>>();

        public string ClassName { get; set; } = string.Empty;

        public TableClass(Type t)
        {
            ClassName = t.Name;

            foreach (PropertyInfo p in t.GetProperties())
            {
                KeyValuePair<string, Type> field = new KeyValuePair<string, Type>(p.Name, p.PropertyType);

                Fields.Add(field);
            }
        }

        public string CreateTableScript()
        {
            StringBuilder script = new StringBuilder();

            _ = script.AppendLine("CREATE TABLE " + ClassName);
            _ = script.AppendLine("(");
            _ = script.AppendLine("\t ID BIGINT,");
            for (int i = 0; i < Fields.Count; i++)
            {
                KeyValuePair<string, Type> field = Fields[i];

                if (DataMapper.ContainsKey(field.Value))
                {
                    _ = script.Append("\t " + field.Key + " " + DataMapper[field.Value]);
                }
                else
                {
                    // Complex Type? 
                    _ = script.Append("\t " + field.Key + " BIGINT");
                }

                if (i != Fields.Count - 1)
                {
                    _ = script.Append(",");
                }

                _ = script.Append(Environment.NewLine);
            }

            _ = script.AppendLine(")");

            return script.ToString();
        }
    }
}