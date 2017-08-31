using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// DAL 的摘要说明
/// </summary>
public class DAL
{
    public DAL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static readonly string connection = ConfigUtil.GetConnectionString("form");

    public static int INSERT(string Title,XmlDocument XML)
    {
        string sql = "insert into Teml(Title,XML,CreateTime,IsDelete) VALUES (@Title,@XML,@CreateTime,@IsDelete)";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            return conn.Execute(sql, new { Title = Title, XML = XML, CreateTime = DateTime.Now, IsDelete = 0 });
        }
    }


    public static List<Model> GetXML(int pageSize, int pageIndex)
    {
        string sql = @"SELECT  * FROM(SELECT * , ROW_NUMBER() OVER(ORDER BY CreateTime desc) AS pageIndex FROM  dbo.Teml WHERE IsDelete = 0) AS t WHERE pageIndex BETWEEN(@pageIndex - 1) * @pageSize + 1 AND @pageIndex *@pageSize";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            return conn.Query<Model>(sql, new { pageSize = pageSize, pageIndex = pageIndex}).ToList();
        }
    }

    public static int GetPageCount(string table)
    {
        using (IDbConnection conn = new SqlConnection(connection))
        {
            string sql = "SELECT * FROM " + table + " WHERE IsDelete = 0";
            List<dynamic> datas = conn.Query(sql).ToList();
            return datas.ToArray().Length;
        }
    }

    public static int GetPageCount(string table, int FormId)
    {
        using (IDbConnection conn = new SqlConnection(connection))
        {
            string sql = "SELECT * FROM " + table + " WHERE IsDelete = 0 and FormId=" + FormId + "";
            List<dynamic> datas = conn.Query(sql).ToList();
            return datas.ToArray().Length;
        }
    }

    public static Model GetXmlById(int Id)
    {
        Model model;
        string sql = "select * from Teml where Id=@Id and IsDelete=0";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            model = conn.Query<Model>(sql, new { Id = Id }).SingleOrDefault();
            return model;
        }
    }

    public static Form GetDataXmlById(int Id, int FormId)
    {
        Form model;
        string sql = "select * from Form where Id =@Id and FormId=@FormId and IsDelete=0";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            model = conn.Query<Form>(sql, new { Id = Id, FormId = FormId }).SingleOrDefault();
            return model;
        }
    }

    public static int InsertForm(Form form)
    {
        string sql = "INSERT INTO Form ([FormId], [Name], [Phone], [Email], [Data],[CommitTime],[IsDelete])VALUES (@FormId, @Name, @Phone, @Email, @Data, @CommitTime, @IsDelete)";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            return conn.Execute(sql, form);
        }
    }


    public static List<Form> GetFormListByFormId(int FormId, int pageSize, int pageIndex)
    {
        string sql = "SELECT * FROM (SELECT f.Id, title, FormId, Name, Phone, Email, Data, CommitTime, ROW_NUMBER() OVER (ORDER BY CommitTime DESC) AS pageIndex FROM Form f INNER JOIN dbo.Teml t ON t.Id=f.FormId WHERE FormId=@FormId AND t.IsDelete=0 AND f.IsDelete=0) AS t WHERE pageIndex BETWEEN (@pageIndex - 1) * @pageSize + 1 AND @pageIndex * @pageSize";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            return conn.Query<Form>(sql, new { FormId = FormId, pageSize = pageSize, pageIndex = pageIndex }).ToList();
        }
    }

    public static int Delete(string table, int Id)
    {
        string sql = "update " + table + " set IsDelete=1 where Id=@Id";
        using (IDbConnection conn = new SqlConnection(connection))
        {
            return conn.Execute(sql, new { Id = Id });
        }
    }
}