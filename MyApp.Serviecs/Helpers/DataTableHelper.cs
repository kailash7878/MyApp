using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace MyApp.Serviecs.Helpers
{
    public static class DataTableHelper
    {
        /// <summary>
        /// Converts a generic objects to a DataTable <see cref="DataTableHelper"/>
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="list">Generic list</param>
        /// <returns>the DataTable</returns>
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable();
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Converts a DataTable to a list with generic objects <see cref="DataTableHelper"/>
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The DataRow.</param>
        /// <returns>DataRow</returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
