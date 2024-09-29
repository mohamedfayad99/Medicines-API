using System.Data;

namespace EMedicineBE.Models
{
    public class DAL
    {
        public Response register(Users users)
        {
            Response response=new Response();
            //SqlCommand cmd=new SqlCommand("sq_register", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            //cmd.Parameters.AddWithValue("@LastName", users.LastName);
            //cmd.Parameters.AddWithValue("@Email", users.Email);
            //cmd.Parameters.AddWithValue("@Password", users.Password);
            //cmd.Parameters.AddWithValue("@Fund", 0);
            //cmd.Parameters.AddWithValue("@Type", "Users");
            //cmd.Parameters.AddWithValue("@Type", "Pending");
            //sqlConnection.Open();
            //int i=cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //if (i > 0)
            //{
            //    response.StatusCode= 200;
            //    response.StatusMessage = "Users Registerd Successufully";
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Users Registerd faild";
            //}
            return response;
        }

        public Response login(Users users)
        {
            //SqlDataAdapter sqldata=new SqlDataAdapter("sp_login",sqlConnection);
            //sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqldata.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            //sqldata.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            //DataTable dt=new DataTable();
            //sqldata.Fill(dt);
            //Response response  = new Response();
            //Users user= new Users();
            //if(dt.Rows.Count > 0)
            //{
            //    user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
            //    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            //    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            //    user.Email = Convert.ToString(dt.Rows[0]["Email"]);
            //    user.Type = Convert.ToString(dt.Rows[0]["Type"]);
            //    response.StatusCode= 200;
            //    response.StatusMessage = "User is Valid";
            //    response.user = user;
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "User is InVlaid";
            //    response.user = user;
            //}
            Response response = new Response();

            return response;
        }

        public Response viewUser(Users users)
        {
            //SqlDataAdapter sqldata = new SqlDataAdapter("sp_viewUser", sqlConnection);
            //sqldata.SelectCommand.CommandType= CommandType.StoredProcedure;
            //sqldata.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            //DataTable dt=new DataTable();
            //sqldata.Fill(dt);
            //Response response = new Response();
            //Users user = new Users();
            //if (dt.Rows.Count > 0)
            //{
            //    user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
            //    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            //    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            //    user.Email = Convert.ToString(dt.Rows[0]["Email"]);
            //    user.Type = Convert.ToString(dt.Rows[0]["Type"]);
            //    user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
            //    user.createdon = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
            //    user.Password = Convert.ToString(dt.Rows[0]["Passsword"]);
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Users  Exist";
            //    response.user = user;
            //}
            //else
            //{

            //    response.StatusCode = 100;
            //    response.StatusMessage = "Users not Exist";
            //    response.user = user;
            //}
            Response response = new Response();

            return response;
        }

        public Response updateProfile(Users users)
        {
            Response response=new Response();
            //SqlCommand cmd = new SqlCommand("sp_updateProfile",sqlConnection);
            //cmd.CommandType= CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            //cmd.Parameters.AddWithValue("@LastName", users.LastName);
            //cmd.Parameters.AddWithValue("@Email", users.Email);
            //cmd.Parameters.AddWithValue("@Password", users.Password);
            //sqlConnection.Open();
            //int i = cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //if(i>0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Record Updated Successfully";
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Record Updated Faild";
            //}
            return response;
        }

        public Response addToCart(Cart cart)
        {
            Response response=new Response();
            //SqlCommand cmd = new SqlCommand("sp_addToCart", sqlConnection);
            //cmd.Parameters.AddWithValue("@UserId", cart.UserId);
            //cmd.Parameters.AddWithValue("@MedicineId", cart.MedicineId);
            //cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            //cmd.Parameters.AddWithValue("@Dicount", cart.Dicount);
            //cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            //cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);

            //sqlConnection.Open();
            //int i = cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //if (i > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Item added Successufully";
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Item added  faild";
            //}
            return response;
        }

        public Response placeOrder(Users user)
        {
            Response response = new Response();
            //SqlCommand cmd = new SqlCommand("sp_PlaceOrder", sqlConnection);
            //cmd.Parameters.AddWithValue("@ID", user.ID);
            //sqlConnection.Open();
            //int i = cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //if (i > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Order has been placed Successufully";
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Order has been placed  faild";
            //}
            return response;
        }
        public Response orderList(Users users)
        {
            Response response = new Response();
            //List<Orders> listorders = new List<Orders>();
            //SqlDataAdapter sqldata = new SqlDataAdapter("sp_OrderList", sqlConnection);
            //sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqldata.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            //sqldata.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            //DataTable dt = new DataTable();
            //sqldata.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    for(int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        Orders order = new Orders();
            //        order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            //        order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
            //        order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
            //        order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
            //        listorders.Add(order);
            //    }
            //    if (listorders.Count > 0)
            //    {
            //        response.StatusCode = 200;
            //        response.StatusMessage = "Order Details Fetched";
            //        response.listorders = listorders;
            //    }
            //    else
            //    {
            //        response.StatusCode = 100;
            //        response.StatusMessage = "Order Details not Fetched";
            //        response.listorders = null;
            //    }

            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Order Details not Fetched";
            //    response.listorders = null;

            //}
            return response;
        }

        public Response upsertMedicine(Medicines medicines)
        {
            Response response = new Response();
            //SqlCommand cmd = new SqlCommand("sp_upsertMedicine", sqlConnection);
            //cmd.Parameters.AddWithValue("@ID", medicines.ID);
            //cmd.Parameters.AddWithValue("@Name", medicines.Name);
            //cmd.Parameters.AddWithValue("@Manufuctarer", medicines.Manufuctarer);
            //cmd.Parameters.AddWithValue("@UnitPrice", medicines.UnitPrice);
            //cmd.Parameters.AddWithValue("@Quantity", medicines.Quantity);
            //cmd.Parameters.AddWithValue("@Status", medicines.Status);
            //cmd.Parameters.AddWithValue("@Discount", medicines.Discount);
            //cmd.Parameters.AddWithValue("@ImageUrl", medicines.ImageUrl);
            //cmd.Parameters.AddWithValue("@Type", medicines.Type);
            //sqlConnection.Open();
            //int i = cmd.ExecuteNonQuery();
            //sqlConnection.Close();
            //if (i > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Medicine Upsert Successufully";
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Medicine Upsert faild";
            //}
            return response;

        }
        public Response userList()
        {
            Response response = new Response();
            //List<Users> listusers = new List<Users>();
            //SqlDataAdapter sqldata = new SqlDataAdapter("sp_UserList", sqlConnection);
            //sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //sqldata.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        Users user = new Users();
            //    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            //    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
            //    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
            //    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
            //    user.status = Convert.ToInt32(dt.Rows[i]["status"]);
            //    user.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
            //    user.Password = Convert.ToString(dt.Rows[i]["Passsword"]);
            //    user.createdon = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
            //        listusers.Add(user);
            //    }
            //    if (listusers.Count > 0)
            //    {
            //        response.StatusCode = 200;
            //        response.StatusMessage = "Users Details Fetched";
            //        response.listusers = listusers;
            //    }
            //    else
            //    {
            //        response.StatusCode = 100;
            //        response.StatusMessage = "Users Details not Fetched";
            //        response.listusers = null;
            //    }

            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Users Details not Fetched";
            //    response.listusers = null;

            //}
            return response;
        }

    }
}
