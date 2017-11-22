using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PrintingWebService
{
    /// <summary>
    /// MCU_WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MCU_WebService : System.Web.Services.WebService
    {
        DataOperator dataOper = new DataOperator();//创建数据操作类的对象
        SearchDataTable TableOper = new SearchDataTable();
        //public DataSet ds;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Add(int x, int y)
        {
            return (x + y);
        }
        [WebMethod]
        public DataSet GetRequest(string PrintingId)
        {
            TableOper.Init();
            TableOper.ds.Clear();
            TableOper.cmd.CommandText = "select * from dbo.tb_User";
            TableOper.sda.SelectCommand = TableOper.cmd;
            TableOper.sda.Fill(TableOper.ds);
            //dgvPrint.DataSource = ds.Tables[0];
            TableOper.scn.Close();
            return (TableOper.ds);
        }
        [WebMethod]
        public bool CheckCertification(string x, string y)
        {
            string x1, y1;
            bool CheckResult = false;
            //TableOper.Init();
            x1 = x.Trim();
            y1 = y.Trim();
           // string sql = "select count(*) from dbo.tb_User where UserName='" + x1 + "' and Password= '" + y1 + "'";
            string sql = "EXECUTE CheckID @pUserName = '" + x1 + "',@pPassword = '" + y1 + "'";
            

            int num = 0;
            //"select text, password from myusertable where text='" + UserName + "' and password='" + Password + "'";

            try         //调用try…catch语句
            {
                //建立连接数据库字符串
                num = dataOper.ExecSQL(sql);
            }
            catch (Exception)
            {
                CheckResult = false;
            }
            if (num == 1)
            { CheckResult = true; }
            return (CheckResult);
        }
    }
}
