using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AGRIBANKHD.DAL
{
    class DataAccess_old
    {
        #region 1. Khai báo các thành viên dữ liệu
        SqlConnection conn;
        SqlCommand cmd;
        #endregion

        #region 2. Các phương thức khởi tạo
        public DataAccess_old()
        {
            conn = new SqlConnection(@"Server=127.0.0.1;Database=AGRIBANKHDDB;User Id=sa;
Password=123456a@;");

        }
        #endregion

        #region 3. Các phương thức thao tác với CSDL

        /// <summary>
        /// Phương thức mở kết nối tới CSDL
        /// </summary>
        private void Open()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        /// <summary>
        /// Phương thức ngắt kết nối với CSDL
        /// </summary>
        private void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        /// <summary>
        /// Phương thức lấy về một giá trị từ mệnh đề SELECT
        /// </summary>
        /// <param name="query">Câu lệnh SELECT</param>
        /// <returns>Một đối tượng</returns>
        public object GetValue(string query)
        {
            Open();
            cmd = new SqlCommand(query, conn);
            return cmd.ExecuteScalar();
        }

        public DataTable GetDataTable(string select)
        {
            SqlDataAdapter da = new SqlDataAdapter(select, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public int ExecuteNonQuery(string query, SqlCommand cmd)
        {
            Open();
            cmd = new SqlCommand(query, conn);
            return cmd.ExecuteNonQuery();
        }

        #endregion

    }

}