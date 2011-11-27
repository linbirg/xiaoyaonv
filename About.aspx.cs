using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;



public partial class About : System.Web.UI.Page
{
    MySqlConnection objConn;
    MySqlCommand objCmd;
    String strSQL;

    protected void Page_Load(object sender, EventArgs e)
    {
        String strConnString;
        strConnString = "Server=localhost;User Id=root; Password=root; Database=xiaoyaonv; Pooling=false";
        objConn = new MySqlConnection(strConnString);
        objConn.Open();

        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        String strSQL;
        strSQL = "SELECT * FROM products";

        MySqlDataReader dtReader;
        objCmd = new MySqlCommand(strSQL, objConn);
        dtReader = objCmd.ExecuteReader();

        //*** BindData to DataList ***//
        DlNewGoods.DataSource = dtReader;
        DlNewGoods.DataBind();

        dtReader.Close();
        dtReader = null;
    }

    protected void Page_UnLoad()
    {
        objConn.Close();
        objConn = null;
    }

    protected void DlNewGoods_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //*** Image ***//
        Image img = (Image)(e.Item.FindControl("imgPicture"));
        if (img != null)
        {
            img.ImageUrl = (string)DataBinder.Eval(e.Item.DataItem, "Picture");
            //img.Attributes.Add("OnClick","window.location='http://www.thaicreate.com?Cateid=" + 
            //DataBinder.Eval(e.Item.DataItem, "CategoryID").ToString() + "'");
            //img.Style.Add("cursor","hand");
        }

        //*** HyperLink ***//		
        HyperLink hplCate = (HyperLink)(e.Item.FindControl("hplCategory"));
        if (hplCate != null)
        {
            hplCate.Text = (string)DataBinder.Eval(e.Item.DataItem, "CategoryName");
            hplCate.ToolTip = (string)DataBinder.Eval(e.Item.DataItem, "CategoryName");
            hplCate.NavigateUrl = "http://www.thaicreate.com?Cateid=" + DataBinder.Eval(e.Item.DataItem, "CategoryID").ToString();
        }	

    }

    protected void DlNewGoods_EditCommand(object source, DataListCommandEventArgs e)
    {
        DlNewGoods.EditItemIndex = e.Item.ItemIndex;
        BindData();	
    }

    protected void DlNewGoods_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DlNewGoods.EditItemIndex = -1;
        BindData();	
    }

    protected void DlNewGoods_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        //*** CategoryID ***//
        Label lblCateID = (Label)(e.Item.FindControl("lblCateID"));
        //*** Category ***//
        TextBox txtCategory = (TextBox)(e.Item.FindControl("txtCategory"));


        strSQL = "UPDATE category SET CategoryName = '" + txtCategory.Text + "' " +
            " WHERE CategoryID = " + lblCateID.Text + " ";
        objCmd = new MySqlCommand(strSQL, objConn);
        objCmd.ExecuteNonQuery();

        //*** If Select File Upload ***//
        HtmlInputFile filPicture = (HtmlInputFile)(e.Item.FindControl("filPicture"));
        String strFileName;
        if (filPicture.PostedFile.FileName != "")
        {
            strFileName = System.IO.Path.GetFileName(filPicture.Value);
            filPicture.PostedFile.SaveAs(Server.MapPath("images/" + strFileName));
            strSQL = "UPDATE category SET Picture = 'images/" + strFileName + "' " +
                " WHERE CategoryID = " + lblCateID.Text + " ";
            objCmd = new MySqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();
        }

        DlNewGoods.EditItemIndex = -1;
        BindData();	
    }
}

