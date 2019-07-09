using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSharp.Models.Tables;
using System.Data;
using System.Data.SqlClient;

namespace BlogSharp.Data
{
    public class UserRepository
    {
        public List<User> SelectAll()
        {
            List<User> users = new List<User>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User currentRow = new User();

                        currentRow.UserId = (int)dr["UserId"];
                        currentRow.UserName = dr["FirstName"].ToString();
                        currentRow.Password = dr["LastName"].ToString();

                        users.Add(currentRow);
                    }
                }
            }

            return users;
        }

        public List<Post> SelectAllPosts()
        {
            List<Post> posts = new List<Post>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllPosts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post currentRow = new Post();

                        currentRow.PostId = (int)dr["UserId"];
                        currentRow.Title = dr["FirstName"].ToString();
                        currentRow.Message = dr["LastName"].ToString();
                        currentRow.DateTime = (DateTime)dr["FirstName"];
                        currentRow.UserId = (int)dr["LastName"];

                        posts.Add(currentRow);
                    }
                }
            }

            return posts;
        }
    }
}
