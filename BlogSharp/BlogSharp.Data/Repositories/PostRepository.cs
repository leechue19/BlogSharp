using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSharp.Models.Tables;
using System.Data;
using System.Data.SqlClient;

namespace BlogSharp.Data.Repositories
{
    public class PostRepository
    {
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
                        currentRow.Date = (DateTime)dr["FirstName"];
                        currentRow.UserId = (int)dr["LastName"];

                        posts.Add(currentRow);
                    }
                }
            }

            return posts;
        }

        public Post SelectPostById()
        {
            Post post = new Post();

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
                        currentRow.Date = (DateTime)dr["FirstName"];
                        currentRow.UserId = (int)dr["LastName"];

                        post = currentRow;
                    }
                }
            }

            return post;
        }

        public void InsertPost(Post post)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertPost", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostId", post.PostId);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Message", post.Message);
                cmd.Parameters.AddWithValue("@Date", post.Date);
                cmd.Parameters.AddWithValue("@UserId", post.UserId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePost(Post post)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdatePost", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostId", post.PostId);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Message", post.Message);
                cmd.Parameters.AddWithValue("@Date", post.Date);
                cmd.Parameters.AddWithValue("@UserId", post.UserId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePost(int postId)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeletePost", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostId", postId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
